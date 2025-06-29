
using System;
using System.Drawing;
using System.IO;
using System.Web;

namespace ZAPI.Models.Utility
{
    public class ImageHandler
    {
        // public bool Upload(HttpPostedFileBase image, string extension, int width, int height, string path, string existingPath)
        public bool Upload(string extension, int width, int height, string path, string existingPath)
        {
            bool result = false;
            //try
            //{
            //    var img = System.Drawing.Image.FromStream(image.InputStream, true, true);

            //    if (existingPath != "" && existingPath != null)
            //    {
            //        existingPath = "~" + existingPath;
            //        int end = existingPath.IndexOf("?v");
            //        existingPath = existingPath.Substring(0, end);
            //        if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(existingPath)))
            //        {
            //            File.Delete(HttpContext.Current.Server.MapPath(existingPath));
            //        }
            //    }

            //    if (width == 0 && height == 0)
            //    {
            //        //var img = System.Drawing.Image.FromStream(image.InputStream, true, true);
            //        width = img.Width;
            //        height = img.Height;
            //    }

            //    Size size = ImageSize(width, height);
            //    width = size.width;
            //    height = size.height;
            //    Bitmap bmp = new Bitmap(img, width, height);
            //    bmp.Save(HttpContext.Current.Server.MapPath(path));
            //    img.Dispose();
            //    bmp.Dispose();

            //    ResizeSettings resizeSetting = new ResizeSettings
            //    {
            //        Width = width,
            //        Height = height,
            //        Format = extension.Replace(".", "")
            //    };
            //    ImageBuilder.Current.Build(path, path, resizeSetting);
            //    result = true;
            //}
            //catch (Exception ex)
            //{

            //}
            return true;
        }
        public class Size
        {
            public int width { get; set; }
            public int height { get; set; }
        }
        private Size ImageSize(int width, int height)
        {
            Size size = new Size();
            try
            {
                if (width > 1366 || height > 1366)
                {
                    double hr = 0.00;
                    double wr = 0.00;
                    if (height > width)
                    {
                        hr = height / 100;
                        wr = width / 100;
                        wr = Convert.ToDouble(width) / Convert.ToDouble(height);
                        size.width = (int)(wr * 1366);
                        size.height = 1366;
                    }
                    else if (width > height)
                    {
                        hr = Convert.ToDouble(height) / Convert.ToDouble(width);
                        size.width = 1366;
                        size.height = (int)(hr * 1366);
                    }
                }
                else
                {
                    size.width = width;
                    size.height = height;
                }
            }
            catch
            {
                size.width = 0;
                size.height = 0;
            }
            return size;
        }

        public bool RemoveImage(string path)
        {
            bool result = false;
            //try
            //{
            //    if (path != "" || path != null)
            //    {
            //        path = "~" + path;
            //        int end = path.IndexOf("?v");
            //        path = path.Substring(0, end);
            //        if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(path)))
            //        {
            //            File.Delete(HttpContext.Current.Server.MapPath(path));
            //        }
            //        result = true;
            //    }
            //}
            //catch(Exception ex) { }
            return result;
        }
    }
}