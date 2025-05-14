using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnologyKeeda.Entity;
using TechnologyKeeda.Repositories.Interfaces;
using TechnologyKeeda.UI.ViewModels.UserInfoViewModels;

namespace TechnologyKeeda.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepo _userRepo;

        public AuthController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserInfoViewModel vm)
        {
            var model = new UserInfo
            {
                UserName = vm.UserName,
                Password = vm.Password
            };
            await _userRepo.Register(model);
            return RedirectToAction("Login");
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserInfoViewModel vm)
        {
            var userInfo = await _userRepo.GetUserInfo(vm.UserName,vm.Password);
            HttpContext.Session.SetInt32("userId", userInfo.UserId);
            HttpContext.Session.SetString("userName", userInfo.UserName);

            return RedirectToAction("Index","Countries");
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
