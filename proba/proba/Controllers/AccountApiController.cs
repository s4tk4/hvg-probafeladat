﻿using proba.Helpers.Accounts;
using proba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using proba.Extensions;

namespace proba.Controllers
{
    public class AccountApiController : ApiController
    {
        [Route("api/AccountApi/CreateNewAccount")]
        [HttpPost]
        public HttpResponseMessage CreateNewAccount(proba.Models.Accounts.AbstractAccount data)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            JsonFEResult jsonResult = new JsonFEResult();
            if (AccountHelper.IsValidDataForCreation(data, jsonResult))
            {
                AccountHelper.CreateNewAccount(data);
                response.StatusCode = HttpStatusCode.OK;
            }
            string jsondataresultstring = jsonResult.GetDataString();
            response.Content = new StringContent(jsondataresultstring);
            return response;
        }
    }
}
