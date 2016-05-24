using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5.Models;

namespace MVC5
{
    public class CarsController : Controller
    {
        private CarDbContext db = new CarDbContext();
        private PossibleCarDbContext possibleCarDb = new PossibleCarDbContext();


                  

        // GET: /Cars/
        public ActionResult Index()
        {
            var carList = db.Cars.ToList();

            ViewBag.total = carList.Sum(i => i.RetailPrice) + carList.Sum(i => long.Parse(i.Doors)) + carList.Sum(i => long.Parse(i.Fuel)) + carList.Sum(i => long.Parse(i.Transmission)) + carList.Sum(i => long.Parse(i.Interior));

            //I'm confident this is not the best way at all but I am short on time.
            return View(carList.OrderBy(x => x.Model).ToList().OrderBy(x => x.Make).ToList());
         
        }


        // GET: /Cars/Create
        public ActionResult Create() 
        {
            //Okay so I dont really like this Idea at all. I'm mostly shoving BLL in here b/c the instructions are all like dont worry about DB and so on for a clearly DB oriented project. Trying to follow instructions though.

            var carList = new List<Car>();
            //The spec wanted me to hardcode this so I did.
            var pCar = new Car();
            pCar.ID = 1;
            pCar.Type = "Car";
            pCar.Make = "Ford";
            pCar.Model = "Focus";
            pCar.RetailPrice = 16500;

            carList.Add(pCar);

            var aCar = new Car();
            aCar.ID = 2;
            aCar.Type = "Car";
            aCar.Make = "Ford";
            aCar.Model = "Fusion";
            aCar.RetailPrice = 22000;
            carList.Add(aCar);        

            var bCar = new Car();
            bCar.ID = 3;
            bCar.Type = "Truck";
            bCar.Make = "Ford";
            bCar.Model = "F-150";
            bCar.RetailPrice = 24500;
            carList.Add(bCar);

            var cCar = new Car();
            cCar.ID = 4;
            cCar.Type = "Car";
            cCar.Make = "Lincoln";
            cCar.Model = "MKZ";
            cCar.RetailPrice = 34500;
            carList.Add(cCar);

            var dCar = new Car();
            dCar.ID = 5;
            dCar.Type = "SUV";
            dCar.Make = "Lincoln";
            dCar.Model = "Navigator";
            dCar.RetailPrice = 56000;
            carList.Add(dCar);

            var eCar = new Car();
            eCar.ID = 6;
            eCar.Type = "Car";
            eCar.Make = "Dodge";
            eCar.Model = "Avenger";
            eCar.RetailPrice = 20500;
            carList.Add(eCar);

            var fCar = new Car();
            fCar.ID = 7;
            fCar.Type = "Car";
            fCar.Make = "Dodge";
            fCar.Model = "Dart";
            fCar.RetailPrice = 16000;
            carList.Add(fCar);

            var gCar = new Car();
            gCar.ID = 8;
            gCar.Type = "SUV";
            gCar.Make = "Dodge";
            gCar.Model = "Durango";
            gCar.RetailPrice = 29500;
            carList.Add(gCar);

            ViewData["Cars"] = carList;


            return View();
        }

        // POST: /Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Make,Model,Year,Type,RetailPrice,Doors,Fuel,Transmission,Interior,Price")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }



        // GET: /Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: /Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult AddCar(int id)
        {

      //I cannot get the model to validate with this no matter what I try.
      //I dont have enough time to handle that.

                Car car = db.Cars.Find(id);

                var carList = new List<Car>();
                //The spec wanted me to hardcode this so I did.
                var pCar = new Car();
                pCar.ID = 1;
                pCar.Type = "Car";
                pCar.Make = "Ford";
                pCar.Model = "Focus";
                pCar.RetailPrice = 16500;

                carList.Add(pCar);

                var aCar = new Car();
                aCar.ID = 2;
                aCar.Type = "Car";
                aCar.Make = "Ford";
                aCar.Model = "Fusion";
                aCar.RetailPrice = 22000;
                carList.Add(aCar);

                var bCar = new Car();
                bCar.ID = 3;
                bCar.Type = "Truck";
                bCar.Make = "Ford";
                bCar.Model = "F-150";
                bCar.RetailPrice = 24500;
                carList.Add(bCar);

                var cCar = new Car();
                cCar.ID = 4;
                cCar.Type = "Car";
                cCar.Make = "Lincoln";
                cCar.Model = "MKZ";
                cCar.RetailPrice = 34500;
                carList.Add(cCar);

                var dCar = new Car();
                dCar.ID = 5;
                dCar.Type = "SUV";
                dCar.Make = "Lincoln";
                dCar.Model = "Navigator";
                dCar.RetailPrice = 56000;
                carList.Add(dCar);

                var eCar = new Car();
                eCar.ID = 6;
                eCar.Type = "Car";
                eCar.Make = "Dodge";
                eCar.Model = "Avenger";
                eCar.RetailPrice = 20500;
                carList.Add(eCar);

                var fCar = new Car();
                fCar.ID = 7;
                fCar.Type = "Car";
                fCar.Make = "Dodge";
                fCar.Model = "Dart";
                fCar.RetailPrice = 16000;
                carList.Add(fCar);

                var gCar = new Car();
                gCar.ID = 8;
                gCar.Type = "SUV";
                gCar.Make = "Dodge";
                gCar.Model = "Durango";
                gCar.RetailPrice = 29500;
                carList.Add(gCar);

                ViewData["Cars"] = carList;

                var Doors = new SelectList(new[]
                {
                new { Value = "0", Name = "2-door"},
                new {Value = "2500", Name = "4-door"}
            },
                "Value", "Name", 1);

                var Fuel = new SelectList(new[]
                {
                new {Name = "Gas", Cost = "0"},
                new {Name = "Hybrid", Cost = "10000"},
                new {Name = "Electric", Cost = "15000"}
            },
                "Cost", "Name", 1);

                var Transmission = new SelectList(new[]
                {
                new {Name = "Automatic", Cost = "1000"},
                new {Name = "Manual", Cost = "0"}
            },
                "Cost", "Name", 1);

                var Interior = new SelectList(new[]
                {
                new {Name = "Cloth", Cost = "0"},
                new {Name = "Leather", Cost = "1500"}
            },
                "Cost", "Name", 1);

                ViewData["Doors"] = Doors;
                ViewData["Fuel"] = Fuel;
                ViewData["Transmission"] = Transmission;
                ViewData["Interior"] = Interior;

            //db.Cars.Add(car);
            //    db.SaveChanges();
            ViewBag.total = car.RetailPrice + car.Interior + car.Doors + car.Fuel + car.Transmission;

            return PartialView("_FeatureView", carList.Find(x => x.ID == id));

        }

       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
