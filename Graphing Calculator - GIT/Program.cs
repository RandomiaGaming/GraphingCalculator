 using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace GraphingCalculator
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            //PDLogoRenderrer.Render(256, 256, 0.25, 0.3, 0.35, 0.35).Save("C:/Users/Randomiagaming/Desktop/Icon - Favicon.png", System.Drawing.Imaging.ImageFormat.Png);
            //PDLogoRenderrer.RenderV2(256, 256).Save("C:/Users/Randomiagaming/Desktop/Icon - Favicon.png", System.Drawing.Imaging.ImageFormat.Png);
            //return;

            Console.Title = "Graphing Calculator";

            TestGraph testGraph = new TestGraph();

            GraphViewer graphicViewer = new GraphViewer(testGraph);
            graphicViewer.Run();

            Process.GetCurrentProcess().Kill();
        }
    }
}