using Pro2.Helpers.File;

namespace Pro2.Helpers
{
    public class FileHelper : IFileHelper
    {
        IWebHostEnvironment env;

        public FileHelper(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public string SaveImage(IFormFile file, string ImageOldName, string PathFolderName)
        {
            var allowedImages = new List<string> { ".jpg", ".png", ".jpeg" };

            var imageName = "";

            if (file != null)
            {
                var path = Path.Combine(env.WebRootPath, PathFolderName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                FileInfo f = new FileInfo(file.FileName);
                var ext = f.Extension;
                if (allowedImages.Contains(ext))
                {
                    var tempName = Guid.NewGuid() + "_" + file.FileName;
                    imageName = Path.Combine(PathFolderName, tempName);
                    var fullPath = Path.Combine(env.WebRootPath, imageName);


                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    } }
                    else
                    {
                        return "Error";
                    }
                }
                else
                {
                    imageName = ImageOldName;
                }

                return imageName;
            }

    public string SavePdf(IFormFile file, string PdfOldName, string PathFolderName)
        {
            var allowedPdfs = new List<string> {
        ".pdf"
        };

            var imageName = "";

            if (file != null)
            {
                var path = Path.Combine(env.WebRootPath, PathFolderName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                FileInfo f = new FileInfo(file.FileName);
                var ext = f.Extension;
                if (allowedPdfs.Contains(ext))
                {
                    var tempName = Guid.NewGuid() + "_" + file.FileName;
                    imageName = Path.Combine(PathFolderName, tempName);
                    var fullPath = Path.Combine(env.WebRootPath, imageName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                else
                {
                    return "Error";
                }
            }
            else
            {
                imageName = PdfOldName;
            }

            return imageName;
        }
    }
}
