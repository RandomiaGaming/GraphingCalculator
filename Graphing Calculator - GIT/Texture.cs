using System;
namespace GraphingCalculator
{
    public sealed class Texture
    {
       #region Constants
        public const int MaxWidth = 46340;
        public const int MaxHeight = 46340;
        #endregion
        #region Public Variables
        public int Width
        {
            get
            {
                return _width;
            }
        }
        public int Height
        {
            get
            {
                return _height;
            }
        }
        public Microsoft.Xna.Framework.Graphics.Texture2D XNABase
        {
            get
            {
                return _XNABase;
            }
        }
        public Microsoft.Xna.Framework.Graphics.GraphicsDevice XNAGraphicsDevice
        {
            get
            {
                return _XNAGraphicsDevice;
            }
        }
        #endregion
        #region Private Variables
        private int _width = 0;
        private int _height = 0;
        private int _heightMinusOne = 0;
        private int _dataLength = 0;
        private Microsoft.Xna.Framework.Graphics.Texture2D _XNABase = null;
        private Microsoft.Xna.Framework.Graphics.GraphicsDevice _XNAGraphicsDevice = null;
        private Microsoft.Xna.Framework.Color[] _data = null;
        #endregion
        #region Constructors
        public Texture(Microsoft.Xna.Framework.Graphics.GraphicsDevice XNAGraphicsDevice, int width, int height)
        {
            if (XNAGraphicsDevice is null)
            {
                throw new Exception("XNAGraphicsDevice cannot be null.");
            }
            _XNAGraphicsDevice = XNAGraphicsDevice;

            if (width <= 0)
            {
                throw new Exception("width must be greater than 0.");
            }
            if (width > MaxWidth)
            {
                throw new Exception("width must be less than or equal to MaxWidth.");
            }
            _width = width;

            if (height <= 0)
            {
                throw new Exception("height must be greater than 0.");
            }
            if (height > MaxHeight)
            {
                throw new Exception("height must be less than or equal to MaxHeight.");
            }
            _height = height;

            _heightMinusOne = _height - 1;

            _dataLength = _width * _height;

            _XNABase = new Microsoft.Xna.Framework.Graphics.Texture2D(XNAGraphicsDevice, _width, _height);

            _data = new Microsoft.Xna.Framework.Color[_dataLength];
        }
        #endregion
        #region Public Methods
        public void SetPixel(int x, int y, Microsoft.Xna.Framework.Color color)
        {
            if (x < 0)
            {
                throw new Exception("x must be greater than or equal to 0.");
            }
            if (x >= _width)
            {
                throw new Exception("x must be less than width.");
            }

            if (y < 0)
            {
                throw new Exception("y must be greater than or equal to 0.");
            }
            if (y >= _height)
            {
                throw new Exception("y must be less than height.");
            }

            _data[((_heightMinusOne - y) * _width) + x] = color;
        }
        public Microsoft.Xna.Framework.Color GetPixel(int x, int y)
        {
            if(x < 0)
            {
                throw new Exception("x must be greater than or equal to 0.");
            }
            if (x >= _width)
            {
                throw new Exception("x must be less than width.");
            }

            if (y < 0)
            {
                throw new Exception("y must be greater than or equal to 0.");
            }
            if (y >= _height)
            {
                throw new Exception("y must be less than height.");
            }

            return _data[((_heightMinusOne - y) * _width) + x];
        }
        public void SetData(Microsoft.Xna.Framework.Color[] data)
        {
            if (data is null)
            {
                throw new Exception("data cannot be null.");
            }
            if (data.Length != _dataLength)
            {
                throw new Exception("data.Length must equal width times height.");
            }

            _data = (Microsoft.Xna.Framework.Color[])data.Clone();
        }
        public Microsoft.Xna.Framework.Color[] GetData()
        {
            return (Microsoft.Xna.Framework.Color[])_data.Clone();
        }

        public void SetPixelUnsafe(int x, int y, Microsoft.Xna.Framework.Color color)
        {
            _data[((_heightMinusOne - y) * _width) + x] = color;
        }
        public Microsoft.Xna.Framework.Color GetPixelUnsafe(int x, int y)
        {
            return _data[((_heightMinusOne - y) * _width) + x];
        }
        public void SetDataUnsafe(Microsoft.Xna.Framework.Color[] data)
        {
            _data = data;
        }
        public Microsoft.Xna.Framework.Color[] GetDataUnsafe()
        {
            return _data;
        }

        public void Clear(Microsoft.Xna.Framework.Color color)
        {
            if (_dataLength == 0)
            {
                return;
            }

            _data[0] = color;

            if (_dataLength == 1)
            {
                return;
            }

            int halfDataLength = _dataLength / 2;

            int i = 1;

            while (i < halfDataLength)
            {
                Array.Copy(_data, 0, _data, i, i);
                i = i * 2;
            }

            if (i != _dataLength)
            {
                Array.Copy(_data, 0, _data, i, _dataLength - i);
            }
        }
        public void Apply()
        {
            _XNABase.SetData(_data);
        }
        #endregion
    }
}