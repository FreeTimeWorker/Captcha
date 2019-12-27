using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyCode
{
    public class ImageCaptcha
    {
        /// <summary>
        /// 干扰线的颜色集合
        /// </summary>
        private List<SKColor> colors
        {
            get
            {
                return new List<SKColor>() {
                    SKColors.AliceBlue,
                    SKColors.PaleGreen,
                    SKColors.PaleGoldenrod,
                    SKColors.Orchid,
                    SKColors.OrangeRed,
                    SKColors.Orange,
                    SKColors.OliveDrab,
                    SKColors.Olive,
                    SKColors.OldLace,
                    SKColors.Navy,
                    SKColors.NavajoWhite,
                    SKColors.Moccasin,
                    SKColors.MistyRose,
                    SKColors.MintCream,
                    SKColors.MidnightBlue,
                    SKColors.MediumVioletRed,
                    SKColors.MediumTurquoise,
                    SKColors.MediumSpringGreen,
                    SKColors.LightSlateGray,
                    SKColors.LightSteelBlue,
                    SKColors.LightYellow,
                    SKColors.Lime,
                    SKColors.LimeGreen,
                    SKColors.Linen,
                    SKColors.PaleTurquoise,
                    SKColors.Magenta,
                    SKColors.MediumAquamarine,
                    SKColors.MediumBlue,
                    SKColors.MediumOrchid,
                    SKColors.MediumPurple,
                    SKColors.MediumSeaGreen,
                    SKColors.MediumSlateBlue,
                    SKColors.Maroon,
                    SKColors.PaleVioletRed,
                    SKColors.PapayaWhip,
                    SKColors.PeachPuff,
                    SKColors.Snow,
                    SKColors.SpringGreen,
                    SKColors.SteelBlue,
                    SKColors.Tan,
                    SKColors.Teal,
                    SKColors.Thistle,
                    SKColors.SlateGray,
                    SKColors.Tomato,
                    SKColors.Violet,
                    SKColors.Wheat,
                    SKColors.White,
                    SKColors.WhiteSmoke,
                    SKColors.Yellow,
                    SKColors.YellowGreen,
                    SKColors.Turquoise,
                    SKColors.LightSkyBlue,
                    SKColors.SlateBlue,
                    SKColors.Silver,
                    SKColors.Peru,
                    SKColors.Pink,
                    SKColors.Plum,
                    SKColors.PowderBlue,
                    SKColors.Purple,
                    SKColors.Red,
                    SKColors.SkyBlue,
                    SKColors.RosyBrown,
                    SKColors.SaddleBrown,
                    SKColors.Salmon,
                    SKColors.SandyBrown,
                    SKColors.SeaGreen,
                    SKColors.SeaShell,
                    SKColors.Sienna,
                    SKColors.RoyalBlue,
                    SKColors.LightSeaGreen,
                    SKColors.LightSalmon,
                    SKColors.LightPink,
                    SKColors.Crimson,
                    SKColors.Cyan,
                    SKColors.DarkBlue,
                    SKColors.DarkCyan,
                    SKColors.DarkGoldenrod,
                    SKColors.DarkGray,
                    SKColors.Cornsilk,
                    SKColors.DarkGreen,
                    SKColors.DarkMagenta,
                    SKColors.DarkOliveGreen,
                    SKColors.DarkOrange,
                    SKColors.DarkOrchid,
                    SKColors.DarkRed,
                    SKColors.DarkSalmon,
                    SKColors.DarkKhaki,
                    SKColors.DarkSeaGreen,
                    SKColors.CornflowerBlue,
                    SKColors.Chocolate,
                    SKColors.AntiqueWhite,
                    SKColors.Aqua,
                    SKColors.Aquamarine,
                    SKColors.Azure,
                    SKColors.Beige,
                    SKColors.Bisque,
                    SKColors.Coral,
                    SKColors.Black,
                    SKColors.Blue,
                    SKColors.BlueViolet,
                    SKColors.Brown,
                    SKColors.BurlyWood,
                    SKColors.CadetBlue,
                    SKColors.Chartreuse,
                    SKColors.BlanchedAlmond,
                    SKColors.Transparent,
                    SKColors.DarkSlateBlue,
                    SKColors.DarkTurquoise,
                    SKColors.IndianRed,
                    SKColors.Indigo,
                    SKColors.Ivory,
                    SKColors.Khaki,
                    SKColors.Lavender,
                    SKColors.LavenderBlush,
                    SKColors.HotPink,
                    SKColors.LawnGreen,
                    SKColors.LightBlue,
                    SKColors.LightCoral,
                    SKColors.LightCyan,
                    SKColors.LightGoldenrodYellow,
                    SKColors.LightGray,
                    SKColors.LightGreen,
                    SKColors.LemonChiffon,
                    SKColors.DarkSlateGray,
                    SKColors.Honeydew,
                    SKColors.Green,
                    SKColors.DarkViolet,
                    SKColors.DeepPink,
                    SKColors.DeepSkyBlue,
                    SKColors.DimGray,
                    SKColors.DodgerBlue,
                    SKColors.Firebrick,
                    SKColors.GreenYellow,
                    SKColors.FloralWhite,
                    SKColors.Fuchsia,
                    SKColors.Gainsboro,
                    SKColors.GhostWhite,
                    SKColors.Gold,
                    SKColors.Goldenrod,
                    SKColors.Gray,
                    SKColors.ForestGreen
            };
            }

        }
        /// <summary>
        /// 创建画笔
        /// </summary>
        /// <param name="color"></param>
        /// <param name="fontSize"></param>
        /// <returns></returns>
        private SKPaint CreatePaint(SKColor color, float fontSize)
        {
            SkiaSharp.SKTypeface font = SKTypeface.FromFamilyName(null, SKFontStyleWeight.SemiBold, SKFontStyleWidth.ExtraCondensed, SKFontStyleSlant.Upright);
            SKPaint paint = new SKPaint();
            paint.IsAntialias = true;
            paint.Color = color;
            paint.Typeface = font;
            paint.TextSize = fontSize;
            return paint;
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="captchaText">验证码文字</param>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片高度</param>
        /// <param name="lineNum">干扰线数量</param>
        /// <param name="lineStrookeWidth">干扰线宽度</param>
        /// <returns></returns>
        public byte[] GetCaptcha(string captchaText, int width, int height, int lineNum = 1, int lineStrookeWidth = 1)
        {
            //创建bitmap位图
            using (SKBitmap image2d = new SKBitmap(width, height, SKColorType.Bgra8888, SKAlphaType.Premul))
            {
                //创建画笔
                using (SKCanvas canvas = new SKCanvas(image2d))
                {
                    Random random = new Random();
                    //填充背景颜色为白色
                    canvas.DrawColor(SKColors.White);
                    //将文字写到画布上
                    using (SKPaint drawStyle = CreatePaint(colors[random.Next(colors.Count)], height*0.6f))
                    {
                        canvas.DrawText(captchaText, 1, height-height*0.3f, drawStyle);
                    }
                    //画随机干扰线
                    using (SKPaint drawStyle = new SKPaint())
                    {
                        
                        for (int i = 0; i < lineNum; i++)
                        {
                            drawStyle.Color = colors[random.Next(colors.Count)];
                            drawStyle.StrokeWidth = lineStrookeWidth;
                            canvas.DrawLine(random.Next(0, width), random.Next(0, height), random.Next(0, width), random.Next(0, height), drawStyle);
                        }
                    }
                    //返回图片byte
                    using (SKImage img = SKImage.FromBitmap(image2d))
                    {
                        using (SKData p = img.Encode(SKEncodedImageFormat.Png, 100))
                        {
                            return p.ToArray();
                        }
                    }
                }
            }
        }

    }
}
