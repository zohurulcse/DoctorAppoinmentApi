using System.Net;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Database.Interface.Email;
using ZHOSPITAL.Database.Interface.FTP;
using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Database.Repository.FTP
{
    public class CmnFTPRepository : BaseRepository<CmnFTPCredential>, ICmnFTPCredential
    {
        public CmnFTPRepository(ZHOSPITALDbContext db) : base(db) { }
        public new List<CmnFTPCredential> GetAll()
        {
            List<CmnFTPCredential> cmnFTPCredentials = _db.CmnFTPCredentials.ToList();
            return cmnFTPCredentials;
        }

        public void UploadToFTPserver(string sourceFilePath)
        {
            ////string HostingURL = HostingEnvironment.MapPath(@"" + MapPathReverse(sourceFilePath));
            //string ControlFilePath = sourceFilePath.Replace(".xml", "-ctrl.xml");
            //ControlFilePath = HostingEnvironment.MapPath(@"" + MapPathReverse(ControlFilePath));
            string FileName = Path.GetFileName(sourceFilePath); //The file Name to send to the resource.
                                                                //string ControlFileName = Path.GetFileName(ControlFilePath); //The file Name to send to the resource.
                                                                //sourceFilePath = HostingEnvironment.MapPath(@"" + MapPathReverse(sourceFilePath));
                                                                //string WebClientMethod = "STOR";  //The method used to send the file to the resource. If null, the default is POST for http and STOR for ftp.

            FileInfo f = new FileInfo(FileName);
            var fullName = f.FullName;
            var name = f.Name;
            CmnFTPCredential ftpCredentials = new CmnFTPCredential();
            ftpCredentials = _db.CmnFTPCredentials.FirstOrDefault();

            try
            {
                //new ProcessManager(ftpCredentials).GetObjectByID<FTPSettings>(ftpCredentials);

                if (ftpCredentials != null)
                {
                    if (string.IsNullOrEmpty(ftpCredentials.HostIP) || string.IsNullOrEmpty(ftpCredentials.UserName) || string.IsNullOrEmpty(ftpCredentials.Password) || string.IsNullOrEmpty(ftpCredentials.Port.ToString()))
                    {
                        //_msgBox.ShowError("FTP Server Login Credentials Missing !!! ");
                    }
                    else
                    {
                        //NetworkCredential credentials = new NetworkCredential(ftpCredentials.UserID, ftpCredentials.FTPassword);

                        string BaseURI = ftpCredentials.HostIP;
                        string AbsoluteUri = "ftp://" + BaseURI + ":" + ftpCredentials.Port + "/";


                        //zohurul Web Request//
                        try
                        {
                            //string[] filePaths = new string[] { sourceFilePath, ControlFilePath };
                            string[] filePaths = new string[] { sourceFilePath };
                            foreach (string filePathName in filePaths)
                            {
                                var pathName = Path.GetFileName(filePathName);
                                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", AbsoluteUri, pathName)));
                                request.Method = WebRequestMethods.Ftp.UploadFile;
                                //request.EnableSsl = true;
                                request.Credentials = new NetworkCredential(ftpCredentials.UserName, ftpCredentials.Password);
                                Stream ftpStrem = request.GetRequestStream();

                                Stream fs = File.OpenRead(filePathName);
                                byte[] buffer = new byte[1024];
                                double total = (double)fs.Length;

                                int byteRead = 0;
                                double read = 0;
                                do
                                {
                                    byteRead = fs.Read(buffer, 0, 1024);
                                    ftpStrem.Write(buffer, 0, byteRead);
                                    read += (double)byteRead;
                                    double percentage = read / total * 100;
                                }
                                while (byteRead != 0);
                                fs.Close();
                            }
                            //_msgBox.ShowSuccess("Limits File Uploaded Successfully On DSE  FTP Server. !!!");
                        }
                        catch (Exception exMsg)
                        {
                            //_msgBox.ShowError(exMsg.ToString());
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //_msgBox.ShowError(ex.ToString());
            }
        }


    }
}
