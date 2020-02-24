using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BarcodeFun.Controllers
{
    public class DemoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GenerateBarCode()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GenerateBarCode(string barcode)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (Bitmap bitMap = new Bitmap(barcode.Length * 40,80))
                {
                    using (Graphics graphics = Graphics.FromImage(bitMap))
                    {
                        //Font oFont = new Font("IDAutomationHC39M", 16);
                        Font oFont = new Font("IDAutomationHC39M", 9);  // font size was 16
                        PointF point = new PointF(2f, 2f);
                        SolidBrush whiteBrush = new SolidBrush(Color.White);
                        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                        SolidBrush blackBrush = new SolidBrush(Color.DarkBlue);
                        graphics.DrawString("*" + barcode + "*", oFont, blackBrush, point);
              
                    }
                    bitMap.Save(memoryStream, ImageFormat.Jpeg);
                    ViewBag.BarcodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return View();
        }
    }
}
