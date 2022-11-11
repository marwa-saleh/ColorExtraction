using ExtractColors2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Color = System.Drawing.Color;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Image = System.Drawing.Image;
using SixLabors.ImageSharp;
using System.Text;
using Microsoft.Extensions.Primitives;
using System;

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
            List<Colors> colors;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                using (var image = Image.FromStream(memoryStream))
                {
                    colors = ExtractColors(image);
                    ImageConverter converter = new ImageConverter();
                    ViewBag.Logo = (byte[])converter.ConvertTo(image, typeof(byte[]));
                }
            }
                    
            return View(colors);
        }

        private List<Colors> ExtractColors(Image image)
        {
            List<Colors> colors = new List<Colors>();
            Bitmap bitmap = new Bitmap(image);

            Color box1 = bitmap.GetPixel(209, 384);
            int box1Saturation = (int)(box1.GetSaturation() * 100);
            colors.Add(new Colors() { Name = "Right Bottom White", HSVS = box1Saturation, RGBB = box1.B, RGBR = box1.R, RGBG = box1.G });

            Color box2 = bitmap.GetPixel(215, 252);
            int box2Saturation = (int)(box2.GetSaturation() * 100);
            colors.Add(new Colors() { Name = "Low", HSVS = box2Saturation, RGBB = box2.B, RGBR = box2.R, RGBG = box2.G });

            Color box3 = bitmap.GetPixel(211, 147);
            int box3Saturation = (int)(box3.GetSaturation() * 100);
            colors.Add(new Colors() { Name = "Low Average", HSVS = box3Saturation, RGBB = box3.B, RGBR = box3.R, RGBG = box3.G });

            Color box4 = bitmap.GetPixel(217, 45);
            int box4Saturation = (int)(box4.GetSaturation() * 100);
            colors.Add(new Colors() { Name = "Average", HSVS = box4Saturation, RGBB = box4.B, RGBR = box4.R, RGBG = box4.G });

            Color box5 = bitmap.GetPixel(135, 49);
            int box5Saturation = (int)(box5.GetSaturation() * 100);
            colors.Add(new Colors() { Name = "Top White", HSVS = box5Saturation, RGBB = box5.B, RGBR = box5.R, RGBG = box5.G });

            Color box6 = bitmap.GetPixel(45, 51);
            int box6Saturation = (int)(box6.GetSaturation() * 100);
            colors.Add(new Colors() { Name = "Above Average", HSVS = box6Saturation, RGBB = box6.B, RGBR = box6.R, RGBG = box6.G });

            Color box7 = bitmap.GetPixel(49, 174);
            int box7Saturation = (int)(box7.GetSaturation() * 100);
            colors.Add(new Colors() { Name = "High", HSVS = box7Saturation, RGBB = box7.B, RGBR = box7.R, RGBG = box7.G });

            Color box8 = bitmap.GetPixel(46, 274);
            int box8Saturation = (int)(box8.GetSaturation() * 100);
            colors.Add(new Colors() { Name = "Very High", HSVS = box8Saturation, RGBB = box8.B, RGBR = box8.R, RGBG = box8.G });

            Color box9 = bitmap.GetPixel(46, 372);
            int box9Saturation = (int)(box9.GetSaturation() * 100);
            colors.Add(new Colors() { Name = "Left Bottom White", HSVS = box9Saturation, RGBB = box9.B, RGBR = box9.R, RGBG = box9.G });

            Color box10 = bitmap.GetPixel(127, 254);
            int box10Saturation = (int)(box10.GetSaturation() * 100);
            colors.Add(new Colors() { Name = "Test Strip", HSVS = box10Saturation, RGBB = box10.B, RGBR = box10.R, RGBG = box10.G });

            return colors;
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