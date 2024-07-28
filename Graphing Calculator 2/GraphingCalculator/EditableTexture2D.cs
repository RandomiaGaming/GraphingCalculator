//Approved 07/08/2022
namespace GraphingCalculator
{
    public sealed class EditableTexture2D
    {
        #region Public Constants
        public const int MaxWidth = 46340;
        public const int MaxHeight = 46340;
        #endregion
        #region Public Variables
        public Microsoft.Xna.Framework.Graphics.GraphicsDevice XNAGraphicsDevice { get; private set; } = null;
        internal Microsoft.Xna.Framework.Graphics.Texture2D XNABase { get; private set; } = null;

        public int Width { get; private set; } = 0;
        public int Height { get; private set; } = 0;
        #endregion
        #region Private Variables
        private int _heightMinusOne = -1;
        private int _dataLength = 0;

        private Microsoft.Xna.Framework.Color[] _XNAColorData = new Microsoft.Xna.Framework.Color[0];
        #endregion
        #region Public Constructors
        public EditableTexture2D(Microsoft.Xna.Framework.Graphics.GraphicsDevice XNAGraphicsDevice, int width, int height)
        {
            if (XNAGraphicsDevice is null)
            {
                throw new System.Exception("XNAGraphicsDevice cannot be null.");
            }
            this.XNAGraphicsDevice = XNAGraphicsDevice;

            if (width <= 0)
            {
                throw new System.Exception("width must be greater than 0.");
            }
            if (width > MaxWidth)
            {
                throw new System.Exception("width must be less than or equal to MaxWidth.");
            }
            Width = width;

            if (height <= 0)
            {
                throw new System.Exception("height must be greater than 0.");
            }
            if (height > MaxHeight)
            {
                throw new System.Exception("height must be less than or equal to MaxHeight.");
            }
            Height = height;

            _heightMinusOne = Height - 1;

            XNABase = new Microsoft.Xna.Framework.Graphics.Texture2D(XNAGraphicsDevice, Width, Height);

            _dataLength = Width * Height;

            _XNAColorData = new Microsoft.Xna.Framework.Color[_dataLength];
        }
        public EditableTexture2D(Microsoft.Xna.Framework.Graphics.GraphicsDevice XNAGraphicsDevice, int width, int height, Microsoft.Xna.Framework.Color[] data)
        {
            if (XNAGraphicsDevice is null)
            {
                throw new System.Exception("XNAGraphicsDevice cannot be null.");
            }
            this.XNAGraphicsDevice = XNAGraphicsDevice;

            if (width <= 0)
            {
                throw new System.Exception("width must be greater than 0.");
            }
            if (width > MaxWidth)
            {
                throw new System.Exception("width must be less than or equal to MaxWidth.");
            }
            Width = width;

            if (height <= 0)
            {
                throw new System.Exception("height must be greater than 0.");
            }
            if (height > MaxHeight)
            {
                throw new System.Exception("height must be less than or equal to MaxHeight.");
            }
            Height = height;

            _heightMinusOne = Height - 1;

            XNABase = new Microsoft.Xna.Framework.Graphics.Texture2D(XNAGraphicsDevice, Width, Height);

            _dataLength = Width * Height;

            if (data is null)
            {
                throw new System.Exception("data cannot be null.");
            }
            if (data.Length != _dataLength)
            {
                throw new System.Exception("data.Length must be equal to width multiplied by height.");
            }

            _XNAColorData = (Microsoft.Xna.Framework.Color[])data.Clone();

            _XNAColorData = new Microsoft.Xna.Framework.Color[_dataLength];

            XNABase.SetData(_XNAColorData);
        }
        public EditableTexture2D(Microsoft.Xna.Framework.Graphics.GraphicsDevice XNAGraphicsDevice, string filePath)
        {
            if (XNAGraphicsDevice is null)
            {
                throw new System.Exception("XNAGraphicsDevice cannot be null.");
            }
            this.XNAGraphicsDevice = XNAGraphicsDevice;

            if (filePath is null)
            {
                throw new System.Exception("filePath cannot be null.");
            }
            if (filePath == string.Empty)
            {
                throw new System.Exception("filePath cannot be empty.");
            }
            if (!System.IO.File.Exists(filePath))
            {
                throw new System.Exception("filePath does not exist.");
            }

            try
            {
                XNABase = Microsoft.Xna.Framework.Graphics.Texture2D.FromFile(XNAGraphicsDevice, filePath);
            }
            catch
            {
                throw new System.Exception("XNABase could not be loaded from filePath.");
            }

            Width = XNABase.Width;
            Height = XNABase.Height;

            if (Width <= 0)
            {
                throw new System.Exception("Width must be greater than 0.");
            }
            if (Width > MaxWidth)
            {
                throw new System.Exception("Width must be less than or equal to MaxWidth.");
            }

            if (Height <= 0)
            {
                throw new System.Exception("Height must be greater than 0.");
            }
            if (Height > MaxHeight)
            {
                throw new System.Exception("Height must be less than or equal to MaxHeight.");
            }

            _heightMinusOne = Height - 1;

            _dataLength = Width * Height;

            _XNAColorData = new Microsoft.Xna.Framework.Color[_dataLength];

            XNABase.GetData(_XNAColorData);
        }
        public EditableTexture2D(Microsoft.Xna.Framework.Graphics.GraphicsDevice XNAGraphicsDevice, System.IO.Stream sourceStream)
        {
            if (XNAGraphicsDevice is null)
            {
                throw new System.Exception("XNAGraphicsDevice cannot be null.");
            }
            this.XNAGraphicsDevice = XNAGraphicsDevice;

            if (sourceStream is null)
            {
                throw new System.Exception("sourceStream cannot be null.");
            }
            if (!sourceStream.CanRead)
            {
                throw new System.Exception("sourceStream must be readable.");
            }

            try
            {
                XNABase = Microsoft.Xna.Framework.Graphics.Texture2D.FromStream(XNAGraphicsDevice, sourceStream);
            }
            catch
            {
                throw new System.Exception("XNABase could not be loaded from filePath.");
            }

            Width = XNABase.Width;
            Height = XNABase.Height;

            if (Width <= 0)
            {
                throw new System.Exception("Width must be greater than 0.");
            }
            if (Width > MaxWidth)
            {
                throw new System.Exception("Width must be less than or equal to MaxWidth.");
            }

            if (Height <= 0)
            {
                throw new System.Exception("Height must be greater than 0.");
            }
            if (Height > MaxHeight)
            {
                throw new System.Exception("Height must be less than or equal to MaxHeight.");
            }

            _heightMinusOne = Height - 1;

            _dataLength = Width * Height;

            _XNAColorData = new Microsoft.Xna.Framework.Color[_dataLength];

            XNABase.GetData(_XNAColorData);
        }
        #endregion
        #region Public Overrides
        public override string ToString()
        {
            return $"EditableTexture2D({Width}, {Height})";
        }
        #endregion
        #region Public Methods
        public void SetPixel(int x, int y, Microsoft.Xna.Framework.Color color)
        {
            if (x < 0)
            {
                throw new System.Exception("x must be greater than or equal to 0.");
            }
            if (x >= Width)
            {
                throw new System.Exception("x must be less than width.");
            }

            if (y < 0)
            {
                throw new System.Exception("y must be greater than or equal to 0.");
            }
            if (y >= Height)
            {
                throw new System.Exception("y must be less than height.");
            }

            _XNAColorData[((_heightMinusOne - y) * Width) + x] = color;
        }
        public Microsoft.Xna.Framework.Color GetPixel(int x, int y)
        {
            if (x < 0)
            {
                throw new System.Exception("x must be greater than or equal to 0.");
            }
            if (x >= Width)
            {
                throw new System.Exception("x must be less than width.");
            }

            if (y < 0)
            {
                throw new System.Exception("y must be greater than or equal to 0.");
            }
            if (y >= Height)
            {
                throw new System.Exception("y must be less than height.");
            }

            return _XNAColorData[((_heightMinusOne - y) * Width) + x];
        }
        public void SetData(Microsoft.Xna.Framework.Color[] data)
        {
            if (data is null)
            {
                throw new System.Exception("data cannot be null.");
            }
            if (data.Length != _dataLength)
            {
                throw new System.Exception("data.Length must be equal to width times height.");
            }

            _XNAColorData = (Microsoft.Xna.Framework.Color[])data.Clone();
        }
        public Microsoft.Xna.Framework.Color[] GetData()
        {
            return (Microsoft.Xna.Framework.Color[])_XNAColorData.Clone();
        }
        public void Clear(Microsoft.Xna.Framework.Color color)
        {
            _XNAColorData[0] = color;

            if (_dataLength == 1)
            {
                return;
            }

            int halfDataLength = _dataLength / 2;

            int i = 1;

            while (i < halfDataLength)
            {
                System.Array.Copy(_XNAColorData, 0, _XNAColorData, i, i);
                i = i * 2;
            }

            if (i != _dataLength)
            {
                System.Array.Copy(_XNAColorData, 0, _XNAColorData, i, _dataLength - i);
            }
        }
        public void Apply()
        {
            XNABase.SetData(_XNAColorData);
        }
        #endregion
        #region Internal Methods
        internal void SetPixelUnsafe(int x, int y, Microsoft.Xna.Framework.Color color)
        {
            _XNAColorData[((_heightMinusOne - y) * Width) + x] = color;
        }
        internal Microsoft.Xna.Framework.Color GetPixelUnsafe(int x, int y)
        {
            return _XNAColorData[((_heightMinusOne - y) * Width) + x];
        }
        internal void SetDataUnsafe(Microsoft.Xna.Framework.Color[] data)
        {
            _XNAColorData = data;
        }
        internal Microsoft.Xna.Framework.Color[] GetDataUnsafe()
        {
            return _XNAColorData;
        }
        #endregion
    }
}