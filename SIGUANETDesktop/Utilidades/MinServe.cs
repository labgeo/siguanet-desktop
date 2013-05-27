using System;
using System.Reflection;
using System.Net;
using System.IO;

namespace SIGUANETDesktop.Utilidades
{
	/// <summary>
	/// MinServe is an embedable mini server for serving plain text files over HTTP.
	/// MinServe is derived from the work of Rick Strahl's reachable at:
	/// http://www.west-wind.com/weblog/posts/2005/Dec/04/Add-a-Web-Server-to-your-NET-20-app-with-a-few-lines-of-code
	/// Minserve allows your localhost to listen HTTP GET requests of files stored 
	/// on a predefined folder which is located under the current executable folder ($bindir$/minserve/).
	/// MinServe is a "one-file" HTTP Server that can be easily integrated into any other project.
	/// Using MinServe is easy:
	///   MinServe minserve = new MinServe();
	///   minserve.Start();
	///   //... do your awesomeness
	///   minserve.Stop();
	/// </summary>
	public sealed class MinServe
	{
		string _urlBase;
		string _folderBase;
        HttpListener _listener;
 
		public string UrlBase {
			get { return _urlBase; }
		}
        
		public MinServe(int port)
		{
			if (port < 1024 || port > 49151)
				port = 8082;
			_urlBase = string.Format("http://127.0.0.1:{0}/minserve/", port);
			_folderBase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    		_folderBase = Path.Combine(_folderBase, "minserve");
		}
		
		public MinServe() : this(8082)
		{
		}
 
		public void Start()
		{
			if (this._listener == null) {
				this._listener = new HttpListener();
			    this._listener.Prefixes.Add(_urlBase);	
			    this._listener.Start();	
			    IAsyncResult result = this._listener.BeginGetContext( new AsyncCallback(RequestCallback), this._listener );
			}
		}
 
        public void Stop()
        {
            if (_listener != null)
            {
                this._listener.Close();
                this._listener = null;
            }
        }
  
        void RequestCallback(IAsyncResult result)
        {
            if (this._listener == null)
                return;
            HttpListenerContext context = this._listener.EndGetContext(result); 
            // *** Immediately set up the next context
            this._listener.BeginGetContext(new AsyncCallback(RequestCallback), this._listener);
            this.Process(context);
        }
 
        void Process(HttpListenerContext Context)
        {
        	string[] path = Context.Request.RawUrl.Split(new char[] {'/'});
        	string resource = path[path.GetUpperBound(0)];
        	string fileName = Path.Combine(_folderBase, resource);
        	if (!File.Exists(fileName)) {
        		Context.Response.StatusCode = (int) HttpStatusCode.NotFound;
        		Context.Response.Close();
        		return;
        	}
        	Context.Response.ContentType = "text/plain";
        	Context.Response.ContentLength64 = File.ReadAllBytes(fileName).Length;
        	using (Stream input = File.Open(fileName, FileMode.Open)) 
        		CopyStream (input, Context.Response.OutputStream);
        }
        
		void CopyStream(Stream input, Stream output)
		{
		    byte[] buffer = new byte[4096];
		    int read;
		    while ((read = input.Read(buffer, 0, buffer.Length)) > 0) {
		    	try {
		    		output.Write (buffer, 0, read);
		    	}
		    	catch (HttpListenerException ex) {
		    		if (ex.ErrorCode != 1229)
		    			throw ex;
		    	}
		    }
		    output.Flush();
		}
	}
}
