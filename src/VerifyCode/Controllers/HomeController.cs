using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VerifyCode.Models;

namespace VerifyCode.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetImageCaptcha()
        {
            Random random = new Random();
            ImageCaptcha imageVerificationCode = new ImageCaptcha();
            string codeTable = "1234567890abcdefghijklmnpqrstuvwxyz二丁厂七卜人入八九几儿了力乃刀又";
            var codeCount = 4;
            char[] captcha =new char[codeCount];
            for (int i = 0; i < codeCount; i++)
            {
                var index = random.Next(0, codeTable.Length);
                captcha[i] = codeTable[index];
            }
            var bytes = imageVerificationCode.GetCaptcha(string.Concat(captcha), 150, 60, random.Next(5, 20), 2);
            return File(bytes, "image/png", "验证码.png");
        }
    }
}
