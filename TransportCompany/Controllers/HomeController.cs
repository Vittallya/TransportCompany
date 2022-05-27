using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System.Diagnostics;
using System.Linq;
using TransportCompany.Services;
using TransportCompany.ViewModels;

namespace TransportCompany.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContextLocal db;
        private readonly UserService userService;
        private readonly Mapper _mapper;



        public HomeController(ILogger<HomeController> logger, DbContextLocal db, UserService userService, Mapper mapper)
        {
            _logger = logger;
            this.db = db;
            this.userService = userService;
            _mapper = mapper;
        }

        [Authorize]
        public IActionResult Index()
        {            
            return View();
        }



        [HttpGet]
        public IActionResult UserCabinet(int? userId)
        {
            if (!userId.HasValue)
                return RedirectToAction("Autorize");

            var user = db.Users.Find(userId);

            var model = _mapper.Map<User, UserViewModel>(user);
            model.Password = null;
            model.Login = null;

           

            if (model.UserGroup == UserGroup.Contragent)
                ViewData["Layout"] = "LayoutManager";
            else if (model.UserGroup == UserGroup.Driver)
                ViewData["Layout"] = "LayoutDriver";
            else if(model.UserGroup == UserGroup.Manager)
                ViewData["Layout"] = "LayoutManager";

            ViewBag.UserId = userId;
            return View(model);
        }

    }
}
