namespace Pro2.Helpers.File
{
    public interface IFileHelper
    {
        public string SaveImage(IFormFile file, string ImageOldName, string PathFolderName);
        string SavePdf(IFormFile file, string ImageOldName, string PathFolderName);

    }
}
