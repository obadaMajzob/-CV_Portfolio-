
namespace CVproject.Helpers.File
{
    public class FileHelper : IFileHelper
    {
        //public string SaveImage(IFormFile file, string ImageOldName, string PathFolderName)
        //{
        //    throw new NotImplementedException();
        //}

        IWebHostEnvironment env;

        public FileHelper(IWebHostEnvironment env)
        {
            this.env=env;
        }

        public string SaveImage(IFormFile file, string oldImagename, string folderName)
        {
            string imageName = "";
            var allowedExtention = new List<string> { ".png", ".jpg", ".jpeg" };
            if (file != null)
            {
                // .pnj .jpg .jpeg
                var foldertPath = Path.Combine(env.WebRootPath, /*"Images"*/ folderName);// D:/Project/WWWroot/Images
                if (!Directory.Exists(foldertPath))
                {
                    Directory.CreateDirectory(foldertPath);
                }

                FileInfo fileInfo = new FileInfo(file.FileName);// File information
                var ext = fileInfo.Extension;

                if (allowedExtention.Contains(ext))
                {
                    var imageTempName = "Image" +Guid.NewGuid() + "_" + file.FileName;
                    //// D:\ASP\24-11-20\Galaxy_WebApplication-2\Galaxy_WebApplication\wwwroot\Images\imageName
                    var fullPath = Path.Combine(foldertPath, imageTempName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream); ////  عمل نسخه من الفايل جوا الستريم يلي هو ماخد الفول باث

                    }
                    imageName =  "/"+ folderName +"/"+ imageTempName;
                }
                else { imageName = "Error"; }

            }
            else
            {
                imageName = oldImagename;
            }
            return imageName;
        }

        //public string SavePDF(IFormFile file, string PDFOldName, string PathFolderNane)
        //{
        //    throw new NotImplementedException();
        //} fileTempName


        public string SavePDF(IFormFile file, string oldFilename, string folderName)
        {
            string FileName = "";
            var allowedExtention = new List<string> { ".pdf" };
            if (file != null)
            {
                // .pnj .jpg .jpeg
                var foldertPath = Path.Combine(env.WebRootPath, /*"Images"*/ folderName);// D:/Project/WWWroot/Images
                if (!Directory.Exists(foldertPath))
                {
                    Directory.CreateDirectory(foldertPath);
                }

                FileInfo fileInfo = new FileInfo(file.FileName);// File information
                var ext = fileInfo.Extension;

                if (allowedExtention.Contains(ext))
                {
                    var fileTempName = "Image" +Guid.NewGuid() + "_" + file.FileName;
                    //// D:\ASP\24-11-20\Galaxy_WebApplication-2\Galaxy_WebApplication\wwwroot\Images\imageName
                    var fullPath = Path.Combine(foldertPath, fileTempName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream); ////  عمل نسخه من الفايل جوا الستريم يلي هو ماخد الفول باث

                    }
                    FileName =  "/"+ folderName +"/"+ fileTempName;
                }
                else { FileName = "Error"; }

            }
            else
            {
                FileName = oldFilename;
            }
            return FileName;
        }
    }
}
