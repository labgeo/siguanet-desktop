/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 13/07/2006
 * Time: 9:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace SIGUANETDesktop.DB
{
	/// <summary>
	/// Description of IDBEntity.
	/// </summary>
	public interface IDBEntity
	{
		int Insert();
		int Delete();
		int Update();
		bool CanQuery
		{get;}
		bool CanInsert
		{get;}
		bool CanDelete
		{get;}
		bool CanUpdate
		{get;}
		bool AllowInsert
		{get;set;}
		bool AllowDelete
		{get;set;}			
		bool AllowUpdate
		{get;set;}
	}
}
