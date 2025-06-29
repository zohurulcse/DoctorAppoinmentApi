using System.Net;
using ZHOSPITAL.Database.Interface.SMS;

namespace ZHOSPITAL.Database.Repository.SMS
{
    public class CmnSMSRepository : ICmnSMS
    {
        public CmnSMSRepository() { }

        public bool MobileIsValid(string mobile)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendOTPSMS(string mobile, int otp)
        {
            throw new NotImplementedException();
        }

        public string SendSMS(string cellNO, string message, string id)
        {
            string URL = "http://sms.sslwireless.com/pushapi/dynamic/server.php?user=gmfslbulk&pass=o@50N564&msisdn=" + cellNO + "&sms=" + message + "&csmsid=" + id + "&sid=GmfslBulk";
            string MsgResponse = "";
            //string URL = GetURL();
            string URL_cellNO_replace = URL.Replace("clientMobileNumber", cellNO);
            string URL_message_replace = URL_cellNO_replace.Replace("messageBody", message);
            string URL_main = URL_message_replace.Replace("ids", id);
            string apiUrl = URL_main;
            Uri address = new Uri(apiUrl);

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            // Create the web request
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            // Set type to POST
            request.Method = "GET";
            request.ContentType = "text/xml";
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    // Console application output
                    string strOutputXml = reader.ReadToEnd();

                    //
                    if (strOutputXml.Contains("SUCCESS") || strOutputXml.Contains("SMS SUBMITTED") || strOutputXml.Contains("Success") || strOutputXml.Contains("1101") || strOutputXml.Contains("Your SMS is Submitted") || strOutputXml.Contains("ACCEPTD"))
                    {
                        MsgResponse = "SUCCESS";
                        return MsgResponse;
                    }
                    else
                    {
                        //MsgResponse = "FAILED";
                        MsgResponse = strOutputXml; //Added By RAsEL on 03-01-2023
                        return MsgResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                //ex.Message();
                MsgResponse = ex.Message;
            }
            return MsgResponse;
        }



    }
}
