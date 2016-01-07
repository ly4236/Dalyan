//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dalyan.Domain.Query
{
    using System;
    using Dalyan.Domain;
    using System.Linq;
    using System.Text;
    using Dalyan.Domain.Query;
    using System.Data;
    using System.Xml;
    using Dalyan.Db;
    using Entities.Models;
    using Dalyan.Entities.Enumerations;
    using AutoMapper;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    public class CommonUserTypeAddQuery : IQuery<Dalyan.Entities.Models.CommonUserType>
    {
    	public Dalyan.Entities.Models.CommonUserType CommonUserType{ get; set; }
    }
    
    public class CommonUserTypeAddQueryHandler : IQueryHandler<CommonUserTypeAddQuery,Dalyan.Entities.Models.CommonUserType>
    {
    	private readonly DbEntities _db;
    	public CommonUserTypeAddQueryHandler()
    	{
    		_db = new DbEntities();
    	}
    
    	    
    	public Dalyan.Entities.Models.CommonUserType Handler(CommonUserTypeAddQuery query)
    	{
    		try
    		{
    			var obj = new Dalyan.Db.CommonUserType();
    			obj.Id = query.CommonUserType.Id;
    			obj.Name = query.CommonUserType.Name;
    			obj.IsDeleted = query.CommonUserType.IsDeleted;
    			_db.CommonUserType.Add(obj);
    			_db.SaveChanges();
    			query.CommonUserType.Id = obj.Id;
    			return query.CommonUserType;
    
    		}
    		catch (Exception ex)
    		{
    			throw new ExceptionLog(LogType.DATABASE_INSERT, LogLevel.ERROR, ex, "AddQueryHandler");
    		}
    	}
    }
    
    
}