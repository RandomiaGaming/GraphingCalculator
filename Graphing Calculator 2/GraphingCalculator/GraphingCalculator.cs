//Approved 07/08/2022
namespace GraphingCalculator
{
    public static class GraphingCalculator
    {
        #region OneInOneOutGraphs
        public static void Graph(OneInOneOutFunction function)
        {
            Grapher grapher = new OneInOneOutGrapher(function);
            GraphViewer graphViewer = new GraphViewer(grapher);
            graphViewer.Run();
            graphViewer.Dispose();
        }
        public static void Graph(OneInOneOutFunction function, double min, double max)
        {
            Grapher grapher = new OneInOneOutGrapher(function, min, max);
            GraphViewer graphViewer = new GraphViewer(grapher);
            graphViewer.Run();
            graphViewer.Dispose();
        }
        public static void Graph(OneInOneOutFunction function, Microsoft.Xna.Framework.Color graphColor)
        {
            Grapher grapher = new OneInOneOutGrapher(function, graphColor);
            GraphViewer graphViewer = new GraphViewer(grapher);
            graphViewer.Run();
            graphViewer.Dispose();
        }
        public static void Graph(OneInOneOutFunction function, Microsoft.Xna.Framework.Color graphColor, Microsoft.Xna.Framework.Color backgroundColor)
        {
            Grapher grapher = new OneInOneOutGrapher(function, graphColor, backgroundColor);
            GraphViewer graphViewer = new GraphViewer(grapher);
            graphViewer.Run();
            graphViewer.Dispose();
        }
        public static void Graph(OneInOneOutFunction function, double min, double max, Microsoft.Xna.Framework.Color graphColor)
        {
            Grapher grapher = new OneInOneOutGrapher(function, min, max, graphColor);
            GraphViewer graphViewer = new GraphViewer(grapher);
            graphViewer.Run();
            graphViewer.Dispose();
        }
        public static void Graph(OneInOneOutFunction function, double min, double max, Microsoft.Xna.Framework.Color graphColor, Microsoft.Xna.Framework.Color backgroundColor)
        {
            Grapher grapher = new OneInOneOutGrapher(function, min, max, graphColor, backgroundColor);
            GraphViewer graphViewer = new GraphViewer(grapher);
            graphViewer.Run();
            graphViewer.Dispose();
        }
        #endregion
    }
}