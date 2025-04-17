namespace CVproject.Helpers.File
{
    public interface IFileHelper
    {
        string SaveImage(IFormFile file, string ImageOldName, string PathFolderName);

        string SavePDF(IFormFile file, string PDFOldName, string PathFolderNane);
    }
}
