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
                }
            }
            return RedirectToAction("Index", "Home");
            /*return Json(claims);*/
        }
    }
}
