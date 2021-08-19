using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Signup.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Signup.Controllers
{
    public class AccountController : Controller
    {
        List<Country> CountryList;

        List<City> CityList;       

        public AccountController()
        {

            CountryList = new List<Country>()
            {
                new Country(){CountryId=1, CountryName="India"},
                new Country (){ CountryId=2, CountryName="Japan"}
            };

            CityList = new List<City>()
            {
                new City(){CityId=1, CityName="Pune", CountryId=1},
                new City(){CityId=2, CityName="Mumbai", CountryId=1},
                new City(){CityId=3, CityName="Tokyo", CountryId=2},
                new City(){CityId=4, CityName="Yokohama", CountryId=2}
            };
          
        }


        public JsonResult GetCity(int CountryId)
        {

            List<City> Cities = CityList.FindAll(x => x.CountryId == CountryId);
            return new JsonResult(Cities);

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            ViewBag.CountryList = new SelectList(CountryList, "CountryId", "CountryName");          
            
            ViewData["Gender"] = new List<string>()
            {
                new string("Male"),
                new string("Female"),
                new string("Transgender")
            }; 
           
            return View();
        }

        [HttpPost]
        public IActionResult Signup(UserModel usermodel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("DisplayMessage", "Account");
            }
            return View();
        }

        public IActionResult DisplayMessage()
        {
            return View();
        }
    }
}
