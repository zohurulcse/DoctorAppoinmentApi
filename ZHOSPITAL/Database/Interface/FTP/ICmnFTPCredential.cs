using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Database.Interface.FTP
{
    public interface ICmnFTPCredential
    {
        public void UploadToFTPserver(string sourceFilePath);
    }
}
