using FrontEND.Helpers;
using FrontEND.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEND.Controllers
{
    public class ShipperController : Controller
    {
        ShipperHelper shipperHelper;

        // GET: ShipperController
        public ActionResult Index()
        {
            shipperHelper= new ShipperHelper();
            List < ShipperViewModel> list = shipperHelper.GetAll();
            return View(list);
        }

        // GET: ShipperController/Details/5
        public ActionResult Details(int id)
        {
            shipperHelper = new ShipperHelper();
            ShipperViewModel ship = shipperHelper.GetByID(id);
            return View(ship);
        }

        // GET: ShipperController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShipperController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShipperViewModel shipper)
        {
            try
            {
                shipperHelper = new ShipperHelper();
                shipper = shipperHelper.Add(shipper);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShipperController/Edit/5
        public ActionResult Edit(int id)
        {
            shipperHelper = new ShipperHelper();
            ShipperViewModel shipper = shipperHelper.GetByID(id);
            return View(shipper);
        }

        // POST: ShipperController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShipperViewModel shipper)
        {
            try
            {
                shipperHelper = new ShipperHelper();
                shipper = shipperHelper.Edit(shipper);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            shipperHelper = new ShipperHelper();
            ShipperViewModel shipper = shipperHelper.GetByID(id);
            return View(shipper);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ShipperViewModel shipper)
        {
            try
            {
                shipperHelper = new ShipperHelper();
                shipperHelper.Delete(shipper.ShipperId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult UploadImage(int id)
        {
            shipperHelper = new ShipperHelper();
            ShipperViewModel shipper = shipperHelper.GetByID(id);
            return View(shipper);
        }

        [HttpPost]
        public ActionResult UploadImage(ShipperViewModel shipper, List<IFormFile> files)
        {
            if (files.Count > 0)
            {
                IFormFile formFile = files[0];
                using (var ms = new MemoryStream())
                {
                    formFile.CopyTo(ms);
                    shipper.Picture = ms.ToArray();
                }
            }

            shipperHelper = new ShipperHelper();
            ShipperViewModel cat = shipperHelper.GetByID(shipper.ShipperId);
            cat.Picture = shipper.Picture;

            shipperHelper.Edit(cat);

            return RedirectToAction("Details", new { id = cat.ShipperId });
        }

    }
}
