using Microsoft.AspNetCore.Components.Forms;

namespace RealtyWeb_Server.Utils.IService
{
    public interface IFileWork
    {
        Task<string> UploadFile(IBrowserFile file);
        bool DeleteFile(string filePath);
        string RenameFile(string filePath);
        bool CrearTemp();
    }
}
