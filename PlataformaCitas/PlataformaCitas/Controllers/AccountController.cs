using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Facebook;
using System.Text.RegularExpressions;
using PlataformaCitas.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;

namespace PlataformaCitas.Controllers
{
    [AllowAnonymous, Route("account")]
    public class AccountController : Controller
    {
        [Route("facebook-login")]
        public IActionResult FacebookLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("FacebookResponse", "Account") };
            return Challenge(properties, FacebookDefaults.AuthenticationScheme);
        }

        [Route("signin-facebook")]
        public async Task<IActionResult> FacebookResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var fb = new FacebookClient();            
            var token = result.Properties.GetTokenValue("access_token");            
            fb.AccessToken = token;
            HttpContext.Session.SetString("LoginToken",token);
            dynamic data = fb.Get("me?fields=link,picture");
            var claims = result.Principal.Identities
                .FirstOrDefault().Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });
            var res = claims.ToArray();
            var Correo = res[1].Value;
            var Nombre = res[2].Value;
 
            if(Correo != "")
            {
                var repo = new APIRequest();
                var resp = repo.saveLogin(Correo, Nombre);
                if (resp != 0)
                {
                    HttpContext.Session.SetString("LoginSession", resp.ToString());
                    HttpContext.Session.SetString("LoginName", Nombre);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Logon", "Auth");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult FacebookLogout()
        {
            try
            {
                var token = HttpContext.Session.GetString("LoginToken");
                var fb = new FacebookClient();
                Uri logoutUrl = fb.GetLogoutUrl(new
                {
                    access_token = token,
                    next = "https://www.facebook.com/connect/login_success.html"
                });

                System.Net.WebClient client = new WebClient();
                client.DownloadString(logoutUrl);            

                return RedirectToAction("Logon", "Auth");

            }
            catch(Exception)
            {
                return RedirectToAction("Index", "Home");
            }            
        }
    }
}


//WebClient client = new WebClient();
//client.DownloadString(logoutUrl);

//_accessToken = null;