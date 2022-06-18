﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Localization;

namespace Kanban.Controllers
{
    public class CultureController : Controller
    {
        [Route("[controller]/[action]")]
        public IActionResult SetCulture(string culture, string redirectUri)
        {

            if (culture != null)
            {
                HttpContext.Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
            }

            return LocalRedirect(redirectUri);
        }
    }
}
