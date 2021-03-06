﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dalyan.WebApi.Controllers
{
    using System;
    using SimpleInjector;
    using Dalyan.Entities;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Net.Http;
    using Dalyan.Entities.Models;
    using Dalyan.Service;
    using Dalyan.WebApi.Attributes;
    using Dalyan.Service.Services;
    using System.Collections.Generic;
    using Security;
    using Entities.Interfaces;
    using Entities.Contracts;

    public class UserController : ApiController
    {
        private readonly Container _container;
        private readonly UserContext _userContext;
        public UserController(Container container)
             : base()
        {
            _container = container;
            _userContext = new UserContext();
        }


        [UserAuthorize]
        [HttpPost]
        public ServiceResult<User> Add(User obj)
        {
            UserService service = new UserService(_container);
            return service.Add(obj);
        }
        [UserAuthorize]
        [HttpPost]
        public ServiceResult<User> Edit(User obj)
        {
            UserService service = new UserService(_container);
            return service.Edit(obj);
        }
        [UserAuthorize]
        [HttpPost]
        public ServiceResult<User> Retrieve(int Id)
        {
            UserService service = new UserService(_container);
            return service.Retrieve(Id);
        }
        [UserAuthorize]
        [HttpPost]
        public ServiceResult<IList<User>> GetAll()
        {
            UserService service = new UserService(_container);
            return service.GetAll();
        }
        [UserAuthorize]
        [HttpPost]
        public ServiceResult<string> Delete(int Id)
        {
            UserService service = new UserService(_container);
            return service.Delete(Id);
        }

        [ClientAuthorize]
        [HttpPost]
        public ServiceResult<string> ChangePassword(string password)
        {
            ChangePasswordService service = new ChangePasswordService(_container);
            IUserContext currentUser = _container.GetInstance<IUserContext>();
            return service.ChangePassword(currentUser.CurrentUserIdentity.UserID, password);
        }
    }
}
