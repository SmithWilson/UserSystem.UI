using AutoMapper;
using ServiceContract.Abstractions.DbService;
using ServiceContract.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UserSystem.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountService _accountService;

        public HomeController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Users(int index = 0)
        {
            var accounts = _accountService.Get(10 * index);
            var count = _accountService.GetCount();

            var users = Mapper.Map<List<UserViewModel>>(accounts);

            var viewModel = new UsersViewModel
            {
                Index = index,
                Count = count,
                Users = users
            };
            
            return View(viewModel);
        }
    }
}