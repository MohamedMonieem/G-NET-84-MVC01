using Asp.Demo1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Asp.Demo1.Controllers
{
    public class ProductsController : Controller
    {

        #region Ahmed Shaker Session

        public ContentResult index()
        {
            // return Content("Mohamed");
            return new ContentResult
            {
                ContentType = "text/html",
                Content = "<h1>ahmed</h1>",
                StatusCode = 200
            };
        }


        // example 2
        [HttpGet]
        public JsonResult GetProducts()
        {
            var products = new List<Product>()
            {
                new Product {Id=1, Name="a"},
                 new Product {Id=2, Name="b"}
            };
            return Json(products);
        }
        // can replace jsonResult wth The father ActionResult or IActionResult



        // example 3  Action 
        [HttpGet]
        public IActionResult GetProductById(int id)
       // public IActionResult GetProductById(int id)
        {
            if (id < 0) return BadRequest();
            else if (id == 0) return RedirectToAction("Index");
            else if (id < 10) return NotFound();
            else return Json(new Product { Id = id, Name = "bl7a" });
        }
        // base URL / Products / GetProductById / id
        #endregion

        // notes :
        // redirect to Action => specific Action
        // Redirect => Url 
        // RedirectResult  : return type / يمكن استبدالها بالأب  (IAction Result)


        // example 4  downloadfiles
        public IActionResult DownLoadFile()
        {
            var file = System.IO.File.ReadAllBytes("wwwroot/files/241150361 - 802 +.pdf");
            return File(file, "application/pdf", "soudFile.pdf");
            //   return File(file, " Type ", " Nanme ");

        }


        // example 5 attrbuite routine in any controller
        // base Url / Products / getAllProducts
        // base url / test   بس المشكلة انه بيلغى الروتينى الكونفشن التانى بيبوظ الدنيا
        // [HttpGet ("test") ]  // URL / test
        [HttpGet(  "{test}")]   // URL / products/test
        // [HttpGet ("test") ] ممكن بقى اطلع فوق سم الكلاس نفسه واخليه زى الكنترولر  على مستوى الكلاس 

        public IActionResult getallProducts()
        {
            var products = new List<Product>()
            {
                  new Product {Id=1, Name="a"},
                 new Product {Id=2, Name="b"}
            };
            return Json(products);
        }


        // exampe 6 data binding from URL
        [HttpGet]
        // public IActionResult GetProductByIdAndName(int id, string Name)
        // base URL / Produts / GetProductByIdAndName ?id=11&Name=bl7a               //data from Query
        // base URL / Produts / GetProductByIdAndName/11/bl7a                        // data from route
        // also data can get from form of html   but will not study now

        // public IActionResult GetProductByIdAndName([FromQuery]int id,[FromRoute] string Name)
        public IActionResult GetProductByIdAndName([FromQuery(Name ="Number ")] int id, [FromRoute] string Name) // يعنى خليت اسمه نامبر مش  أى دى 
        {
            if (id < 0) return BadRequest();
            else if (id == 0) return RedirectToAction("Index");
            else if (id < 10) return NotFound();
            else return Json(new Product { Id = id, Name = "bl7a" });
        }



        //#region Rana Hatem Session

        //// baseurl/controller/Action
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //// build action(function)
        //[HttpGet]
        //public JsonResult GetProducts()
        //{
        //    var products = new List<Product>()
        //    {
        //        new Product { Id = 1, Name = "laptop" },
        //        new Product { Id = 2, Name = "mobile" }
        //    };
        //    return Json(products);
        //}

        //[HttpGet]
        //public IActionResult GetProductById(int id)
        //{
        //    if (id < 0) return BadRequest();
        //    else if (id == 0) return RedirectToAction(nameof(Index));
        //    else if (id < 10) return NotFound();
        //    else return Json(new Product { Id = id, Name = "new name" });
        //}

        //[HttpGet]
        //public IActionResult redirectfunction()
        //{
        //    return Redirect("https://www.google.com");
        //}

        //#endregion

    }
}
