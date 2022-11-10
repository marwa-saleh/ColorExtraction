using ExtractColors2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
//using SixLabors.ImageSharp;
//using Image = SixLabors.ImageSharp.Image;
using Color = System.Drawing.Color;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Image = System.Drawing.Image;
using SixLabors.ImageSharp;
using System.Text;
using Microsoft.Extensions.Primitives;

namespace ExtractColors2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Index(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                using (var image = Image.FromStream(memoryStream))
                {
                    ExtractColors(image);
                }
            }
                    
            return View();
        }

        private void ExtractColors(Image image)
        {
            Bitmap bitmap = new Bitmap(image);

            Color box1 = bitmap.GetPixel(209, 384);
            int box1Blue = box1.B;
            int box1Saturation = (int)(box1.GetSaturation() * 100);
            string box1Result = "Box 1: Saturation =" + box1Saturation + ", Blue =" + box1Blue; 

            Color box2 = bitmap.GetPixel(215, 252);
            int box2Blue = box2.B;
            int box2Saturation = (int)(box2.GetSaturation() * 100);
            string box2Result = "Box 2: Saturation =" + box2Saturation + ", Blue =" + box2Blue;

            Color box3 = bitmap.GetPixel(211, 147);
            int box3Blue = box3.B;
            int box3Saturation = (int)(box3.GetSaturation() * 100);
            string box3Result = "Box 3: Saturation =" + box3Saturation + ", Blue =" + box3Blue;

            Color box4 = bitmap.GetPixel(217, 45);
            int box4Blue = box4.B;
            int box4Saturation = (int)(box4.GetSaturation() * 100);
            string box4Result = "Box 4: Saturation =" + box4Saturation + ", Blue =" + box4Blue;

            Color box5 = bitmap.GetPixel(135, 49);
            int box5Blue = box5.B;
            int box5Saturation = (int)(box5.GetSaturation() * 100);
            string box5Result = "Box 5: Saturation =" + box5Saturation + ", Blue =" + box5Blue;

            Color box6 = bitmap.GetPixel(45, 51);
            int box6Blue = box6.B;
            int box6Saturation = (int)(box6.GetSaturation() * 100);
            string box6Result = "Box 6: Saturation =" + box6Saturation + ", Blue =" + box6Blue;

            Color box7 = bitmap.GetPixel(49, 174);
            int box7Blue = box7.B;
            int box7Saturation = (int)(box7.GetSaturation() * 100);
            string box7Result = "Box 7: Saturation =" + box7Saturation + ", Blue =" + box7Blue;

            Color box8 = bitmap.GetPixel(46, 274);
            int box8Blue = box8.B;
            int box8Saturation = (int)(box8.GetSaturation() * 100);
            string box8Result = "Box 8: Saturation =" + box8Saturation + ", Blue =" + box8Blue;

            Color box9 = bitmap.GetPixel(46, 372);
            int box9Blue = box9.B;
            int box9Saturation = (int)(box9.GetSaturation() * 100);
            string box9Result = "Box 9: Saturation =" + box9Saturation + ", Blue =" + box9Blue;

            Color box10 = bitmap.GetPixel(127, 254);
            int box10Blue = box10.B;
            int box10Saturation = (int)(box10.GetSaturation() * 100);
            string box10Result = "Box 10: Saturation =" + box10Saturation + ", Blue =" + box10Blue;

            ViewBag.Message = new string[] { box1Result, box2Result, box3Result, box4Result, box5Result, box6Result, box7Result, box8Result, box9Result, box10Result };
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Page()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}