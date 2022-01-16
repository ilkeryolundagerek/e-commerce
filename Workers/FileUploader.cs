using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECommerce.Workers
{
    public class FileUploader
    {/*
        public static string ImageUpload(HttpRequestBase request)
        {
            HttpPostedFileBase file = request.Files[0];
            string upload_path = "";
            if (file != null && file.ContentLength > 0)
            {
                string fName = Path.GetFileName(file.FileName);
                fName = DateTime.Now.ToString("yyyyMMddHHmmssfff_") + fName;
                string p = Path.Combine(create_directories(AppDomain.CurrentDomain.BaseDirectory + "/Content/upload"), fName);
                file.SaveAs(p);
                upload_path = "/Content/upload/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/o/" + fName;
            }
            return upload_path;
        }

        private static string create_directories(string p)
        {
            p = p + "/" + DateTime.Now.Year;
            if (!Directory.Exists(p))
            {
                Directory.CreateDirectory(p);
            }
            p += "/" + DateTime.Now.Month;
            if (!Directory.Exists(p))
            {
                Directory.CreateDirectory(p);
            }

            if (!Directory.Exists(p + "/s")) { Directory.CreateDirectory(p + "/s"); }
            if (!Directory.Exists(p + "/t")) { Directory.CreateDirectory(p + "/t"); }
            if (!Directory.Exists(p + "/o")) { Directory.CreateDirectory(p + "/o"); }

            return p;
        }*/
    }
}
