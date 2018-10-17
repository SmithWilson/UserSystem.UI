using ServiceContract.Abstractions.Auth;
using ServiceContract.Abstractions.DbService;
using ServiceContract.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace UserSystem.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISaltService _saltService;
        private readonly IAccountService _accountService;

        public AccountController(
            ISaltService saltService,
            IAccountService accountService)
        {
            _saltService = saltService;
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _accountService.GetByLogin(viewModel.Login);
                if (user != null)
                {
                    var hash = _saltService.Hash(viewModel.Password, user.Secret.Salt);
                    if (hash == user.Secret.Hash)
                    {
                        FormsAuthentication.SetAuthCookie(user.Login, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Неверно введенные данные.");
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _accountService.GetByLogin(viewModel.Login);
                if (user == null)
                {
                    var salt = _saltService.Generate();
                    var hash = _saltService.Hash(viewModel.Password, salt);

                    var account = new Entity.Models.Account
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        Age = viewModel.Age,
                        Gender = viewModel.Gender,
                        Login = viewModel.Login,
                        Passport = viewModel.Passport,
                        Secret = new Entity.Models.Secret
                        {
                            Hash = hash,
                            Salt = salt
                        }
                    };

                    var created = _accountService.Add(account);
                    if (created != -1)
                    {
                        FormsAuthentication.SetAuthCookie(viewModel.Login, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь с таким логином уже существует");
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}