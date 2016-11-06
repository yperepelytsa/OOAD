using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using StripeDemo.Models;

namespace StripeDemo.Controllers
{
    //  [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;   
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(
            SignInManager<ApplicationUser> signinManager,
            UserManager<ApplicationUser> userManager
            )
        {
            _userManager = userManager;
            _signInManager = signinManager;
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("account/login")]
        public IActionResult Login(string ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("account/reset")]
        public IActionResult Reset()
        {
            ViewData["success"] = false;
            return View();
        }
        /*      [HttpPost]
              [AllowAnonymous]
              [Route("account/reset")]
              public async Task<IActionResult> Reset(string email)
              {
                  var user = await _userManager.FindByEmailAsync(email);
                  if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                  {
                      ViewData["success"] = false;
                      return View("Reset", "Incorrect user");
                  }
                  var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                  await _userManager.GenerateEmailConfirmationTokenAsync(user);
                  Console.WriteLine(code);
                  await _tokenservice.AddToken(code, user);
                  var callbackUrl = Url.Action("ResetPassword", "Account",
                  new { UserId = user.Id, code = code }, protocol: Request.Scheme);
                  await _emailsender.SendEmailAsync(user.Email, "Reset Password",
                  "Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">Reset</a>");
                  ViewData["success"] = true;
                  return View();
              }

              [Route("account/resetpassword")]
              [HttpGet]
              public async Task<IActionResult> ResetPassword(string userID, string code)
              {
                  System.Console.WriteLine(_tokenservice.TokenExists(code));
                  if (await Task.Run(() => _tokenservice.TokenExists(code)))
                  {
                      System.Console.WriteLine(_tokenservice.TokenExists(code));
                      return RedirectToAction("Enter", "Account", new { code = code });
                  }
                  else return View("Reset");
              }
              [Route("account/enter")]
              [HttpGet]
              public IActionResult Enter(string code = null)
              {
                  System.Console.WriteLine(_tokenservice.TokenExists(code));
                  if (code == null || !_tokenservice.TokenExists(code))
                      return RedirectToAction("Reset");
                  ViewData["code"] = code;
                  return View();
              }
              [Route("account/enter")]
              [HttpPost]
              public async Task<IActionResult> Enter(string code, string password)
              {
                  System.Console.WriteLine(_tokenservice.TokenExists(code));
                  if (code != null && !_tokenservice.TokenExists(code))
                      return RedirectToAction("Reset");
                  var userid = await _tokenservice.GetUserByToken(code);
                  var user = await _userManager.FindByIdAsync(userid);
                  await _userManager.AddPasswordAsync(user, password);
                  await _emailsender.SendEmailAsync(user.Email, "Password changed",
                      "Your password was changed");
                  await _tokenservice.RemoveToken(code);
                  return RedirectToAction("Login");
              }*/
        [HttpPost]
        [AllowAnonymous]
        [Route("account/login")]
        public async Task<IActionResult> Login(string userName, string Password)
        {
            if (userName == null || Password == null)
                return View();
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(userName);
            }
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, Password, true, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Admin");
                else
                    return View("Login", "Incorrect password");
            }
            return View("Login", "Incorrect email");
        }
        [Authorize]
        [Route("account/logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Admin");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied(string returnUrl = null)
        {
            return RedirectToAction("Index", "Admin");
        }
    }
}