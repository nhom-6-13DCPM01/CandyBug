using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CandyBug.Models;
namespace CandyBug.Controllers
{
    public class CartController : Controller
    {
        CandybugOnlineEntities db = new CandybugOnlineEntities();
        public List<ItemCart> getCart()
        {
            List<ItemCart> listItem = Session["ItemCart"] as List<ItemCart>;
            if (listItem == null)
            {
                listItem = new List<ItemCart>();
                Session["ItemCart"] = listItem;
            }
            return listItem;
        }

        public ActionResult AddItem(int? Id, string strURL)
        {
            Product product = db.Products.SingleOrDefault(c => c.Id == Id);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            List<ItemCart> list = getCart();
            ItemCart productCheck = list.SingleOrDefault(c => c.Id == Id);
            if (productCheck != null)
            {
                if (product.Quantity < productCheck.Quantity)
                {
                    return Redirect(strURL);
                }
                productCheck.Quantity++;
                return Redirect(strURL);
            }
            if (product.Quantity < productCheck.Quantity)
            {
                return Redirect(strURL);
            }
            ItemCart newItem = new ItemCart(Id);
            list.Add(newItem);
            return Redirect(strURL);
        }

        public int CountQuantity()
        {
            List<ItemCart> listCarts = Session["ItemCart"] as List<ItemCart>;
            if (listCarts == null)
            {
                return 0;
            }
            return listCarts.Sum(c => c.Quantity);
        }

        public decimal TotalPrice()
        {
            List<ItemCart> listCarts = Session["ItemCart"] as List<ItemCart>;
            if (listCarts == null)
            {
                return 0;
            }
            return listCarts.Sum(c => c.Total);
        }

        public ActionResult _CartPartial()
        {
            if (CountQuantity() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSL = CountQuantity();
            ViewBag.TongTien = TotalPrice();
            return PartialView();
        }
        // GET: Cart
        public ActionResult Index()
        {
            ViewBag.ActiveCart = "active";
            return View();
        }

        public ActionResult Checkout()
        {
            ViewBag.ActiveCheckout = "active";
            return View();
        }
    }
}