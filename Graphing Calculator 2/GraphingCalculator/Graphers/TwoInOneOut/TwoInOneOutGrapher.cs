namespace GraphingCalculator
{
    public sealed class TwoInOneOutGrapher : Grapher
    {
        #region Private Variables
        private TwoInOneOutFunction _function = null;
        private double _min = -1;
        private double _max = 1;
        private Microsoft.Xna.Framework.Color _backgroundColor = Microsoft.Xna.Framework.Color.Black;
        private Microsoft.Xna.Framework.Color _graphColor = Microsoft.Xna.Framework.Color.White;
        #endregion
        #region Public Constructors
        public TwoInOneOutGrapher(TwoInOneOutFunction function, double min, double max)
        {
            if(function is null)
            {
                throw new System.Exception("function cannot be null.");
            }
            if(min == double.NaN || min == double.PositiveInfinity || min == double.NegativeInfinity)
            {
                throw new System.Exception("min must be a real number.");
            }
            if(max == double.NaN || max == double.PositiveInfinity || max == double.NegativeInfinity)
            {
                throw new System.Exception("max must be a real number.");
            }
            if(min > max)
            {
                throw new System.Exception("min must be less than or equal to max.");
            }
            _function = function;
            _min = min;
            _max = max;
        }
        public OneInOneOutGrapher(OneInOneOutFunction function, double min, double max, Microsoft.Xna.Framework.Color graphColor)
        {
            if (function is null)
            {
                throw new System.Exception("function cannot be null.");
            }
            if (min == double.NaN || min == double.PositiveInfinity || min == double.NegativeInfinity)
            {
                throw new System.Exception("min must be a real number.");
            }
            if (max == double.NaN || max == double.PositiveInfinity || max == double.NegativeInfinity)
            {
                throw new System.Exception("max must be a real number.");
            }
            if (min > max)
            {
                throw new System.Exception("min must be less than or equal to max.");
            }
            _function = function;
            _min = min;
            _max = max;
            _graphColor = graphColor;
        }
        public OneInOneOutGrapher(OneInOneOutFunction function, double min, double max, Microsoft.Xna.Framework.Color graphColor, Microsoft.Xna.Framework.Color backgroundColor)
        {
            if (function is null)
            {
                throw new System.Exception("function cannot be null.");
            }
            if (min == double.NaN || min == double.PositiveInfinity || min == double.NegativeInfinity)
            {
                throw new System.Exception("min must be a real number.");
            }
            if (max == double.NaN || max == double.PositiveInfinity || max == double.NegativeInfinity)
            {
                throw new System.Exception("max must be a real number.");
            }
            if (min > max)
            {
                throw new System.Exception("min must be less than or equal to max.");
            }
            _function = function;
            _min = min;
            _max = max;
            _graphColor = graphColor;
            _backgroundColor = backgroundColor;
        }
        #endregion
        #region Public Overrides
        public override Microsoft.Xna.Framework.Graphics.Texture2D Graph(Microsoft.Xna.Framework.Graphics.GraphicsDevice graphicsDevice, int width, int height)
        {
            if(width <= 0)
            {
                throw new System.Exception("width must be greater than 0.");
            }
            if (height <= 0)
            {
                throw new System.Exception("height must be greater than 0.");
            }

            EditableTexture2D output = new EditableTexture2D(graphicsDevice, width, height);

            output.Clear(_backgroundColor);

            double[] outputs = new double[width + 1];

            for (int pixelInput = 0; pixelInput <= width; pixelInput++)
            {
                double input = _min + ((pixelInput * (_max - _min)) / width);

                outputs[pixelInput] = _function.Invoke(input);
            }

            double outputMin = double.PositiveInfinity;
            double outputMax = double.NegativeInfinity;

            for (int i = 0; i < width + 1; i++)
            {
                if (outputs[i] > outputMax)
                {
                    outputMax = outputs[i];
                }

                if (outputs[i] < outputMin)
                {
                    outputMin = outputs[i];
                }
            }

            for (int x = 0; x < width; x++)
            {
                int pixelMin = (int)((outputs[x] - outputMin) * height / (outputMax - outputMin));
                int pixelMax = (int)((outputs[x + 1] - outputMin) * height / (outputMax - outputMin));

                if (pixelMin > pixelMax)
                {
                    int temp = pixelMin;
                    pixelMin = pixelMax;
                    pixelMax = temp;
                }

                for (int i = pixelMin; i <= pixelMax; i++)
                {
                    if (i > 0 && i < height)
                    {
                        output.SetPixelUnsafe(x, i, _graphColor);
                    }
                }
            }

            output.Apply();

            return output.XNABase;
        }
        #endregion
    }
}