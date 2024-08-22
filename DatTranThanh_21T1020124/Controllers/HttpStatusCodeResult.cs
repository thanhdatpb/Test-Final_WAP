using System.Net;

namespace DatTranThanh_21T1020124.Controllers
{
    internal class HttpStatusCodeResult
    {
        private HttpStatusCode badRequest;

        public HttpStatusCodeResult(HttpStatusCode badRequest)
        {
            this.badRequest = badRequest;
        }
    }
}