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
    
    public class SampleTableDeleteQuery : IQuery<bool>
    {
    	public int Id { get; set; }
    }
    
    public class SampleTableDeleteQueryHandler :  IQueryHandler<Dalyan.Domain.Query.SampleTableDeleteQuery, bool>
    {
    	private readonly DbEntities _db;
    	public SampleTableDeleteQueryHandler()
    	{
    		_db = new DbEntities();
    	}
    
    	    
    	public bool Handler(Dalyan.Domain.Query.SampleTableDeleteQuery query)
    	{
    		try
    		{
    			var obj = new Dalyan.Db.SampleTable();
    			obj = _db.SampleTable.FirstOrDefault(x => x.Id == query.Id);
    
    			obj.IsDeleted = true;
    			_db.SaveChanges();
    			return true;
    		}
    		catch (Exception ex)
    		{
    			throw new ExceptionLog(LogType.DATABASE_DELETE, LogLevel.ERROR, ex, "DeleteQueryHandler");
    		}
    	}
    }
    
}
