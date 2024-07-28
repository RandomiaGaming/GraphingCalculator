using System.Collections.Generic;
namespace GraphingCalculator
{
    public sealed class Scene
    {
        public double viewPortWidth = 1;
        public double viewPortHeight = 1;
        public double viewPortPositionX = 0;
        public double viewPortPositionY = 0;
        public Color backgroundColor = new Color(0, 0, 0);
        public List<Graph> graphs = new List<Graph>();
    }
}