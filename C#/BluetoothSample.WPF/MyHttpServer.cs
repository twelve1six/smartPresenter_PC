using System;
using Bend.Util;
using System.IO;

namespace BluetoothSample.Views
{
    public class MyHttpServer : HttpServer, IDisposable
    {
        PowerpointController _document;
        public MyHttpServer(PowerpointController document, int port)
            : base(port)
        {
            _document = document;
        }

        bool disposed = false;

        public override void handleGETRequest(HttpProcessor p)
        {
            string urlText = p.http_url;
            int pos = urlText.IndexOf("?");

            if (pos != -1)
            {
                urlText = urlText.Substring(0, pos);
            }

            if (urlText.EndsWith("/test") == true)
            {
                p.writeSuccess("text/html");
                p.outputStream.Write(DateTime.Now + ": Hello World!");
            }

            else if (urlText.Contains("/startShow") == true)
            {
                _document.StartShow(1);
                p.writeSuccess("text/html");
                p.outputStream.Write("OK");
            }

            else if (urlText.Contains("/setSlide/") == true)
            {
                string txt = urlText.Substring(urlText.LastIndexOf('/') + 1);

                int slide;
                if (Int32.TryParse(txt, out slide) == true)
                {
                    _document.SetCurrentSlide(slide);
                }

                p.writeSuccess("text/html");
                p.outputStream.Write("OK");
            }
        }

        public override void handlePOSTRequest(HttpProcessor p, StreamReader data) { }

        // Public implementation of Dispose pattern callable by consumers. 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern. 
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                //
            }

            disposed = true;
        }
    }
}