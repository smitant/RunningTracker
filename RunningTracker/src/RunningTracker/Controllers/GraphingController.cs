using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunningTracker.Data;
using RunningTracker.Models.DataEntryModels;

namespace WebApplication2.Controllers
{
    public class GraphingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GraphingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Graphing
        public ActionResult Index()
        {
            string user = User.Identity.Name;
            if (user == null)
            {
                return View("NoLoggedUser");
            }



            return View();
        }

        // GET: Graphing/Details/5
        public ActionResult Details(int id)
        {


            return View();
        }

        // GET: Graphing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Graphing/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        //[Bind("ID,Date,HeartrateMin,HeartrateMax,HeartrateAvg,Steps")]
        //potentially place after "Create("
        {


            var dates = from m in _context.DataEntryViewModel
                        select m;
            string user = User.Identity.Name;
            Console.Write(user);
            if(user == "jane_Doe")
            {
                return View("Index_");
            }
            
            dates = dates.Where(s => s.Username.Equals(user));

            String[] date = new String[365];
            myDouble[] minHeart = new myDouble[365];
            myDouble[] maxHeart = new myDouble[365];
            myDouble[] avgHeart = new myDouble[365];
            myDouble[] steps = new myDouble[365];
            int i = 0;

            DataEntryViewModel[] ob = dates.ToArray();
            QuickSort(ob, 0, ob.Length - 1);

            foreach (DataEntryViewModel d in ob)
            {

                ViewBag.Data[i].Date = d.Date.ToString();
                ViewBag.Data[i].MaxHeart = d.HeartrateMax;
                ViewBag.Data[i].AvgHeart = d.HeartrateAvg;
                ViewBag.Data[i].MinHeart = d.HeartrateMin;
                ViewBag.Data[i].Steps = d.Steps;

                /*
                date[i] = d.Date.ToString();
                minHeart[i].d = d.HeartrateMin;
                maxHeart[i].d = d.HeartrateMax;
                avgHeart[i].d = d.HeartrateAvg;
                steps[i].d = d.Steps;
                i++;
                */
            }

   /*         ViewBag.Date = date;
            ViewBag.MinHeart = minHeart;
            ViewBag.MaxHeart = maxHeart;
            ViewBag.AvgHeart = avgHeart;
            ViewBag.Steps = steps;
*/

            return RedirectToAction("Index");



            //return View();

        }

        public static void QuickSort(DataEntryViewModel[] o, int left, int right)
        {
            int i = left, j = right;
            DataEntryViewModel pivot = o[(left + right) / 2];

            while (i <= j)
            {
                while (o[i].Date.CompareTo(pivot.Date) < 0)
                {
                    i++;
                }

                while (o[j].Date.CompareTo(pivot.Date) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    DataEntryViewModel tmp = o[i];
                    o[i] = o[j];
                    o[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuickSort(o, left, j);
            }

            if (i < right)
            {
                QuickSort(o, i, right);
            }

        }

        public class myDouble
        {
            public Double d;
        }

        // GET: Graphing/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Graphing/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Graphing/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Graphing/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}