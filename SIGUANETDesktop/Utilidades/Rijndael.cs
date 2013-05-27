/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tom�s
 * Fecha: 14/03/2008
 * Hora: 14:19
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificaci�n | Editar Encabezados Est�ndar
 */

//Basado en c�digo de ejemplo de Obviex (http://www.obviex.com/samples/Encryption.aspx)
//Symmetric key encryption and decryption using Rijndael algorithm.

using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using SIGUANETDesktop.Preferencias;

namespace SIGUANETDesktop.Utilidades
{
	/// <summary>
	/// This class uses a symmetric key algorithm (Rijndael/AES) to encrypt and 
	/// decrypt data. As long as encryption and decryption routines use the same
	/// parameters to generate the keys, the keys are guaranteed to be the same.
	/// </summary>
	public class Rijndael
	{
		private string _hashAlgorithm = string.Empty;
		private string _initVector = string.Empty;
		private int _keySize = 256;
		private string _passPhrase = string.Empty;
		private int _passwordIterations = 2;
		private string _saltValue = string.Empty;
		
		public Rijndael()
		{
			_hashAlgorithm = AdministradorPreferencias.Read(PrefsGlobal.RIJHashAlgorithm);
			_initVector = AdministradorPreferencias.Read(PrefsGlobal.RIJInitVector);
			_keySize = int.Parse(AdministradorPreferencias.Read(PrefsGlobal.RIJKeySize));
			_passPhrase = AdministradorPreferencias.Read(PrefsGlobal.RIJPassPhrase);
			_passwordIterations = int.Parse(AdministradorPreferencias.Read(PrefsGlobal.RIJPasswordIterations));
			_saltValue = AdministradorPreferencias.Read(PrefsGlobal.RIJSaltValue);
		}
	    /// <summary>
	    /// Encrypts specified plaintext using Rijndael symmetric key algorithm
	    /// and returns a base64-encoded result.
	    /// </summary>
	    /// <param name="plainText">
	    /// Plaintext value to be encrypted.
	    /// </param>
	    /// <param name="passPhrase">
	    /// Passphrase from which a pseudo-random password will be derived. The
	    /// derived password will be used to generate the encryption key.
	    /// Passphrase can be any string. In this example we assume that this
	    /// passphrase is an ASCII string.
	    /// </param>
	    /// <param name="saltValue">
	    /// Salt value used along with passphrase to generate password. Salt can
	    /// be any string. In this example we assume that salt is an ASCII string.
	    /// </param>
	    /// <param name="hashAlgorithm">
	    /// Hash algorithm used to generate password. Allowed values are: "MD5" and
	    /// "SHA1". SHA1 hashes are a bit slower, but more secure than MD5 hashes.
	    /// </param>
	    /// <param name="passwordIterations">
	    /// Number of iterations used to generate password. One or two iterations
	    /// should be enough.
	    /// </param>
	    /// <param name="initVector">
	    /// Initialization vector (or IV). This value is required to encrypt the
	    /// first block of plaintext data. For RijndaelManaged class IV must be 
	    /// exactly 16 ASCII characters long.
	    /// </param>
	    /// <param name="keySize">
	    /// Size of encryption key in bits. Allowed values are: 128, 192, and 256. 
	    /// Longer keys are more secure than shorter keys.
	    /// </param>
	    /// <returns>
	    /// Encrypted value formatted as a base64-encoded string.
	    /// </returns>
	    public string Encrypt(string plainText)
	    {
	        // Convert strings into byte arrays.
	        // Let us assume that strings only contain ASCII codes.
	        // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
	        // encoding.
	        byte[] initVectorBytes = Encoding.ASCII.GetBytes(this._initVector);
	        byte[] saltValueBytes  = Encoding.ASCII.GetBytes(this._saltValue);
	        
	        // Convert our plaintext into a byte array.
	        // Let us assume that plaintext contains UTF8-encoded characters.
	        byte[] plainTextBytes  = Encoding.UTF8.GetBytes(plainText);
	        
	        // First, we must create a password, from which the key will be derived.
	        // This password will be generated from the specified passphrase and 
	        // salt value. The password will be created using the specified hash 
	        // algorithm. Password creation can be done in several iterations.
	        PasswordDeriveBytes password = new PasswordDeriveBytes(
	                                                        this._passPhrase, 
	                                                        saltValueBytes, 
	                                                        this._hashAlgorithm, 
	                                                        this._passwordIterations);
	        
	        // Use the password to generate pseudo-random bytes for the encryption
	        // key. Specify the size of the key in bytes (instead of bits).
	        byte[] keyBytes = password.GetBytes(this._keySize / 8);
	        
	        // Create uninitialized Rijndael encryption object.
	        RijndaelManaged symmetricKey = new RijndaelManaged();
	        
	        // It is reasonable to set encryption mode to Cipher Block Chaining
	        // (CBC). Use default options for other symmetric key parameters.
	        symmetricKey.Mode = CipherMode.CBC;        
	        
	        // Generate encryptor from the existing key bytes and initialization 
	        // vector. Key size will be defined based on the number of the key 
	        // bytes.
	        ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
	                                                         keyBytes, 
	                                                         initVectorBytes);
	        
	        // Define memory stream which will be used to hold encrypted data.
	        MemoryStream memoryStream = new MemoryStream();        
	                
	        // Define cryptographic stream (always use Write mode for encryption).
	        CryptoStream cryptoStream = new CryptoStream(memoryStream, 
	                                                     encryptor,
	                                                     CryptoStreamMode.Write);
	        // Start encrypting.
	        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
	                
	        // Finish encrypting.
	        cryptoStream.FlushFinalBlock();
	
	        // Convert our encrypted data from a memory stream into a byte array.
	        byte[] cipherTextBytes = memoryStream.ToArray();
	                
	        // Close both streams.
	        //cryptoStream.Close();	        
	        memoryStream.Close();

	        
	        // Convert encrypted data into a base64-encoded string.
	        string cipherText = Convert.ToBase64String(cipherTextBytes);
	        
	        // Return encrypted string.
	        return cipherText;
	    }
	    
	    /// <summary>
	    /// Decrypts specified ciphertext using Rijndael symmetric key algorithm.
	    /// </summary>
	    /// <param name="cipherText">
	    /// Base64-formatted ciphertext value.
	    /// </param>
	    /// <param name="passPhrase">
	    /// Passphrase from which a pseudo-random password will be derived. The
	    /// derived password will be used to generate the encryption key.
	    /// Passphrase can be any string. In this example we assume that this
	    /// passphrase is an ASCII string.
	    /// </param>
	    /// <param name="saltValue">
	    /// Salt value used along with passphrase to generate password. Salt can
	    /// be any string. In this example we assume that salt is an ASCII string.
	    /// </param>
	    /// <param name="hashAlgorithm">
	    /// Hash algorithm used to generate password. Allowed values are: "MD5" and
	    /// "SHA1". SHA1 hashes are a bit slower, but more secure than MD5 hashes.
	    /// </param>
	    /// <param name="passwordIterations">
	    /// Number of iterations used to generate password. One or two iterations
	    /// should be enough.
	    /// </param>
	    /// <param name="initVector">
	    /// Initialization vector (or IV). This value is required to encrypt the
	    /// first block of plaintext data. For RijndaelManaged class IV must be
	    /// exactly 16 ASCII characters long.
	    /// </param>
	    /// <param name="keySize">
	    /// Size of encryption key in bits. Allowed values are: 128, 192, and 256.
	    /// Longer keys are more secure than shorter keys.
	    /// </param>
	    /// <returns>
	    /// Decrypted string value.
	    /// </returns>
	    /// <remarks>
	    /// Most of the logic in this function is similar to the Encrypt
	    /// logic. In order for decryption to work, all parameters of this function
	    /// - except cipherText value - must match the corresponding parameters of
	    /// the Encrypt function which was called to generate the
	    /// ciphertext.
	    /// </remarks>
	    public string Decrypt(string cipherText)
	    {
	        // Convert strings defining encryption key characteristics into byte
	        // arrays. Let us assume that strings only contain ASCII codes.
	        // If strings include Unicode characters, use Unicode, UTF7, or UTF8
	        // encoding.
	        byte[] initVectorBytes = Encoding.ASCII.GetBytes(this._initVector);
	        byte[] saltValueBytes  = Encoding.ASCII.GetBytes(this._saltValue);
	        
	        // Convert our ciphertext into a byte array.
	        byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
	        
	        // First, we must create a password, from which the key will be 
	        // derived. This password will be generated from the specified 
	        // passphrase and salt value. The password will be created using
	        // the specified hash algorithm. Password creation can be done in
	        // several iterations.
	        PasswordDeriveBytes password = new PasswordDeriveBytes(
	                                                        this._passPhrase, 
	                                                        saltValueBytes, 
	                                                        this._hashAlgorithm, 
	                                                        this._passwordIterations);
	        
	        // Use the password to generate pseudo-random bytes for the encryption
	        // key. Specify the size of the key in bytes (instead of bits).
	        byte[] keyBytes = password.GetBytes(this._keySize / 8);
	        
	        // Create uninitialized Rijndael encryption object.
	        RijndaelManaged    symmetricKey = new RijndaelManaged();
	        
	        // It is reasonable to set encryption mode to Cipher Block Chaining
	        // (CBC). Use default options for other symmetric key parameters.
	        symmetricKey.Mode = CipherMode.CBC;
	        
	        // Generate decryptor from the existing key bytes and initialization 
	        // vector. Key size will be defined based on the number of the key 
	        // bytes.
	        ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
	                                                         keyBytes, 
	                                                         initVectorBytes);
	        
	        // Define memory stream which will be used to hold encrypted data.
	        MemoryStream  memoryStream = new MemoryStream(cipherTextBytes);
	                
	        // Define cryptographic stream (always use Read mode for encryption).
	        CryptoStream  cryptoStream = new CryptoStream(memoryStream, 
	                                                      decryptor,
	                                                      CryptoStreamMode.Read);
	
	        // Since at this point we don't know what the size of decrypted data
	        // will be, allocate the buffer long enough to hold ciphertext;
	        // plaintext is never longer than ciphertext.
	        byte[] plainTextBytes = new byte[cipherTextBytes.Length];
	        
	        // Start decrypting.
	        int decryptedByteCount = cryptoStream.Read(plainTextBytes, 
	                                                   0, 
	                                                   plainTextBytes.Length);
	                
	        // Close both streams.
	        //cryptoStream.Close();
	        memoryStream.Close();
	        
	        
	        
	        // Convert decrypted data into a string. 
	        // Let us assume that the original plaintext string was UTF8-encoded.
	        string plainText = Encoding.UTF8.GetString(plainTextBytes, 
	                                                   0, 
	                                                   decryptedByteCount);
	        
	        // Return decrypted string.   
	        return plainText;
	    }
	}
}

/*
/// <summary>
/// Illustrates the use of RijndaelSimple class to encrypt and decrypt data.
/// </summary>
public class RijndaelSimpleTest
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        string   plainText          = "Hello, World!";    // original plaintext
        
        string   passPhrase         = "Pas5pr@se";        // can be any string
        string   saltValue          = "s@1tValue";        // can be any string
        string   hashAlgorithm      = "SHA1";             // can be "MD5"
        int      passwordIterations = 2;                  // can be any number
        string   initVector         = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        int      keySize            = 256;                // can be 192 or 128
        
        Console.WriteLine(String.Format("Plaintext : {0}", plainText));

        string  cipherText = RijndaelSimple.Encrypt(plainText,
                                                    passPhrase,
                                                    saltValue,
                                                    hashAlgorithm,
                                                    passwordIterations,
                                                    initVector,
                                                    keySize);

        Console.WriteLine(String.Format("Encrypted : {0}", cipherText));
        
        plainText          = RijndaelSimple.Decrypt(cipherText,
                                                    passPhrase,
                                                    saltValue,
                                                    hashAlgorithm,
                                                    passwordIterations,
                                                    initVector,
                                                    keySize);

        Console.WriteLine(String.Format("Decrypted : {0}", plainText));
    }
}*/
