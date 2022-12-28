using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TradingApp_1.Models;
using TradingApp_1.Services;

namespace TradingApp_1.Controllers
{
    public class AccountController : Controller
    {

        tradingAppContext context = new tradingAppContext();
        
        private readonly SecurityService securityService;

        IWebHostEnvironment hostEnvironment;
        public AccountController(SecurityService securityService, IWebHostEnvironment hostEnvironment)
        {
            
            this.securityService = securityService;
            this.hostEnvironment = hostEnvironment;
           
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(Registeruser user)
        {
            string filepath = TempData["filepath"].ToString();
            user.Photo = filepath;
            context.Registerusers.Add(user);
            context.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpPost]

        public async Task<IActionResult> Login(Registeruser user)
        {
            bool isValid = context.Registerusers.Any(x => x.Email == user.Email && x.UserPasword == user.UserPasword);

            if (isValid)
            {
                SecureResponse response = new SecureResponse();

                response = await securityService.AuthUser(user);
                return RedirectToAction("getAddInfo", "User");
            }
            else
                return RedirectToAction("Login");
        }

        public IActionResult UploadPhoto()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            
                if (file == null)
                    throw new Exception("File is Not Received...");

                string dirPath = Path.Combine(hostEnvironment.WebRootPath, "ReceivedFiles");
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                string dataFileName = Path.GetFileName(file.FileName);

                string extension = Path.GetExtension(dataFileName);

                string[] allowedExtsnions = new string[] { ".png", ".jpeg" };

                if (!allowedExtsnions.Contains(extension))
                    throw new Exception("Sorry! This file is not allowed, make sure that file having extension as either.xls or.xlsx is uploaded.");

                string saveToPath = Path.Combine(dirPath, dataFileName);
            TempData["filepath"] = saveToPath;

                using (FileStream stream = new FileStream(saveToPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return RedirectToAction("Signup");

        }
    }
}

