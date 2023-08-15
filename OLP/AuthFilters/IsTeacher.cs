﻿using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace OLP.AuthFilters
{
    public class IsTeacher:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var key = actionContext.Request.Headers.Authorization;
            if (key == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { msg = "Please insert your token" });
            }
            else
            {
                var token = key.ToString();
                if (token != null && !TeacherAuth.isTeacher(token))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { msg = "Access denied" });
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}