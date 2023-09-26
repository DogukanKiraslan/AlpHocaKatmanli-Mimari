using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ecommaranceWithLayeredArchDomain.Entities;
using ecommaranceWithLayeredArchManagerUI.Filters;
using ecommaranceWithLayeredArchPersistance.Content;

namespace ecommaranceWithLayeredArchManagerUI.Controllers
{
    [AdminAutantication]
    public class ProductController : Controller
    {
        ecommaranceContext model = new ecommaranceContext();

        //Ürün İşlemleri Burada
        #region Product
        public ActionResult Index()
        {
            return View(model.Products.ToList().Where(x => x.IsDeleted == false));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Name")] Product p)
        {
            if (ModelState.IsValid)
            {
                model.Products.Add(p);
                model.SaveChanges();
                ViewBag.result = "success";
            }
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Product product = model.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                model.Entry(p).State = System.Data.Entity.EntityState.Modified;
                model.SaveChanges();
                ViewBag.result = "success";
                return View();
            }
            return View(p);
        }

        public ActionResult Delete(Guid id) 
        {
            Product product = model.Products.Find(id);
            if (product != null)
            {
                product.IsDeleted = true;
                product.IsActive = false;
                model.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult ChangeStatus(Guid id)
        {
            Product product = model.Products.Find(id);
            if (product != null) 
            {
                product.IsActive = !product.IsActive;
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Detail(Guid id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Product product = model.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        #endregion

        #region Varyant

        [HttpGet]
        public ActionResult CreateVariant(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Product product = model.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
           
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateVariant(Variant v,Guid id)
        {
            if (ModelState.IsValid)
            {
                v.ID = Guid.NewGuid();
                v.Product_ID = id;
                model.Variants.Add(v);
                model.SaveChanges();
                ViewBag.result = "success";
            }
            ModelState.Clear();
            return View();
        }

        #endregion

        #region SKU

        [HttpGet]
        public ActionResult CreateSKU(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Product product = model.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateSKU(SKU s, Guid id)
        {
            if (ModelState.IsValid)
            {
                Product product = model.Products.FirstOrDefault(x=> x.ID == id);
                s.Name = product.Name;
                s.Product_ID = id;
                s.ID = Guid.NewGuid();
                model.SKUs.Add(s);
                model.SaveChanges();
                ViewBag.result = "success";
            }
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult PairVariantSKU(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            SKU sku = model.SKUs.Find(id);
            if (sku == null)
            {
                return HttpNotFound();
            }
            List<Variant> variants = model.Variants.Where(x => x.Product_ID == sku.Product_ID).ToList();
            ViewBag.Variant_ID = new SelectList(model.Variants.Where(x => x.Product_ID == sku.Product_ID), "ID", "Value");
            ViewBag.product_ID = sku.Product_ID;
            return View();
        }

        [HttpPost]
        public ActionResult PairVariantSKU(Guid id, VariantSKU vs)
        {
            SKU sku = model.SKUs.Find(id);
            ViewBag.Variant_ID = new SelectList(model.Variants.Where(x => x.Product_ID == sku.Product_ID),"ID","Value");
            if(ModelState.IsValid)
            {
                Variant v = model.Variants.Find(vs.Variant_ID);
                sku.Name = sku.Name + "-" + v.value;
                model.Entry(sku).State = System.Data.Entity.EntityState.Modified;
                vs.ID = Guid.NewGuid();
                vs.SKU_ID = id;
                model.SaveChanges();
                ViewBag.result = "success";
            }
            ModelState.Clear();
            ViewBag.product_ID = sku.Product_ID;
            return View();
        }
        #endregion
    }
}