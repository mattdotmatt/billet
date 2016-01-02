namespace Billet.Service.Services
{
    using System.IO;
    using System.Net;
    using System.Text;

    public class BillingService : IBillingService
    {
        private readonly string _url;

        public BillingService(string url)
        {
            _url = url;
        }

        public string GetBill(long accountId)
        {
            if (accountId != 123) return "";

            var request = (HttpWebRequest) WebRequest.Create(_url);
            var response = request.GetResponse();
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream == null) return string.Empty;
                var reader = new StreamReader(responseStream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }
    }
}