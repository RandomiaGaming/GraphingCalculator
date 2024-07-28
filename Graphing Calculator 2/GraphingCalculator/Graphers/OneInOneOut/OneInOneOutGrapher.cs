//Approved 07/08/2022
namespace GraphingCalculator
{
    public sealed class OneInOneOutGrapher : Grapher
    {
        #region Private Variables
        private OneInOneOutFunction _function = null;
        private double _min = -10;
        private double _max = 10;
        private Microsoft.Xna.Framework.Color _backgroundColor = Microsoft.Xna.Framework.Color.Black;
        private Microsoft.Xna.Framework.Color _graphColor = Microsoft.Xna.Framework.Color.White;
        #endregion
        #region Public Constructors
        public OneInOneOutGrapher(OneInOneOutFunction function)
        {
            if (function is null)
            {
                throw new System.Exception("function cannot be null.");
            }
            _function = function;
        }
        public OneInOneOutGrapher(OneInOneOutFunction function, double min, double max)
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
        }
        public OneInOneOutGrapher(OneInOneOutFunction function, Microsoft.Xna.Framework.Color graphColor)
        {
            if (function is null)
            {
                throw new System.Exception("function cannot be null.");
            }
            _function = function;
            _graphColor = graphColor;
        }
        public OneInOneOutGrapher(OneInOneOutFunction function, Microsoft.Xna.Framework.Color graphColor, Microsoft.Xna.Framework.Color backgroundColor)
        {
            if (function is null)
            {
                throw new System.Exception("function cannot be null.");
            }
            _function = function;
            _graphColor = graphColor;
            _backgroundColor = backgroundColor;
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
            if (width <= 0)
            {
                throw new System.Exception("width must be greater than 0.");
            }
            if (height <= 0)
            {
                throw new System.Exception("height must be greater than 0.");
            }

            EditableTexture2D outputTexture = new EditableTexture2D(graphicsDevice, width, height);

            outputTexture.Clear(_backgroundColor);

            double[] outputs = new double[width + 1];

            for (int pixelInput = 0; pixelInput <= width; pixelInput++)
            {
                double input = _min + ((pixelInput * (_max - _min)) / width);
                double output = double.NaN;

                try
                {
                    output = _function.Invoke(input);
                }
                catch
                {
                    output = double.NaN;
                }

                if (output == double.PositiveInfinity || output == double.NegativeInfinity)
                {
                    output = double.NaN;
                }

                outputs[pixelInput] = output;
            }

            double outputMin = double.PositiveInfinity;
            double outputMax = double.NegativeInfinity;

            for (int i = 0; i < width + 1; i++)
            {
                double current = outputs[i];

                if (current != double.NaN)
                {
                    if (current > outputMax)
                    {
                        outputMax = current;
                    }

                    if (current < outputMin)
                    {
                        outputMin = current;
                    }
                }
            }

            bool rangeReset = false;
            if (outputMin == double.NaN || outputMin == double.PositiveInfinity || outputMin == double.NegativeInfinity || outputMin > 1000 || outputMin < -1000)
            {
                outputMin = -10;
                rangeReset = true;
            }
            if (outputMax == double.NaN || outputMax == double.PositiveInfinity || outputMax == double.NegativeInfinity || outputMax > 1000 || outputMax < -1000)
            {
                outputMax = 10;
                rangeReset = true;
            }
            if (outputMin > outputMax)
            {
                outputMin = outputMax - 20;
                rangeReset = true;
            }

            if (rangeReset)
            {
                System.Console.WriteLine($"Range was reset do to overflow!");
            }
            System.Console.WriteLine($"Range is [{outputMin}, {outputMax}].");

            outputMin -= 0.1;
            outputMax += 0.1;

            for (int x = 0; x < width; x++)
            {
                double min = outputs[x];
                double max = outputs[x + 1];

                if (!(min is double.NaN) && !(max is double.NaN))
                {
                    int pixelMin = (int)((min - outputMin) * height / (outputMax - outputMin));
                    int pixelMax = (int)((max - outputMin) * height / (outputMax - outputMin));

                    if (pixelMin > pixelMax)
                    {
                        int temp = pixelMin;
                        pixelMin = pixelMax;
                        pixelMax = temp;
                    }

                    if (pixelMin < 0)
                    {
                        pixelMin = 0;
                    }

                    if (pixelMax >= height)
                    {
                        pixelMax = height - 1;
                    }

                    for (int i = pixelMin; i <= pixelMax; i++)
                    {
                        outputTexture.SetPixelUnsafe(x, i, _graphColor);
                    }
                }
                else if (!(min is double.NaN))
                {
                    int pixelMin = (int)((min - outputMin) * height / (outputMax - outputMin));

                    if(pixelMin >= 0 && pixelMin < height)
                    {
                        outputTexture.SetPixelUnsafe(x, pixelMin, _graphColor);
                    }
                }
                else if (!(max is double.NaN))
                {
                    int pixelMax = (int)((max - outputMin) * height / (outputMax - outputMin));

                    if (pixelMax >= 0 && pixelMax < height)
                    {
                        outputTexture.SetPixelUnsafe(x, pixelMax, _graphColor);
                    }
                }
            }

            outputTexture.Apply();

            return outputTexture.XNABase;
        }
        #endregion
    }
}