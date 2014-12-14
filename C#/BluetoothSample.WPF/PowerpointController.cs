using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.PowerPoint;

namespace BluetoothSample.Views
{
    
    public class PowerpointController
    {
        Application _app;
        Presentation _current;



        public bool Load(string documentPath)
        {

            try
            {
                if (_app == null)
                {
                    _app = new Application();
                }

                _app.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

                var presentation = _app.Presentations;

                _current = presentation.Open(documentPath);

                return true;
            }
            catch { }

            return false;
        }

        public void StartShow(int startSlideNumber)
        {
            object inSlideShow = null;

            try
            {
                inSlideShow = _current.SlideShowWindow;
            }
            catch { }

            if (inSlideShow == null)
            {
                _current.SlideShowSettings.Run();

                int start = Math.Min(_current.Slides.Count, startSlideNumber);

                _current.SlideShowWindow.View.GotoSlide(start, Microsoft.Office.Core.MsoTriState.msoTrue);
            }
        }

        public void SetCurrentSlide(int slideNumber)
        {
            try
            {
                _current.SlideShowWindow.View.GotoSlide(slideNumber, Microsoft.Office.Core.MsoTriState.msoTrue);
            }
            catch { }
        }
    }
}