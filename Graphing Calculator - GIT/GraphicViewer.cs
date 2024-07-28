using System;
namespace GraphingCalculator
{
    public sealed class GraphViewer : Microsoft.Xna.Framework.Game
    {
        public Graph Graph { get; set; } = null;

        private Microsoft.Xna.Framework.GraphicsDeviceManager _graphicsDeviceManager = null;
        private Microsoft.Xna.Framework.Graphics.SpriteBatch _spriteBatch = null;
        private int _viewportPixelWidth = 1;
        private int _viewportPixelHeight = 1;

        private double _viewportMinX = -1.0;
        private double _viewportMinY = -1.0;
        private double _viewportMaxX = 1.0;
        private double _viewportMaxY = 1.0;

        private Texture _renderCache = null;
        public GraphViewer(Graph graph)
        {
            if (graph is null)
            {
                throw new Exception("graph cannot be null.");
            }
            Graph = graph;

            _graphicsDeviceManager = new Microsoft.Xna.Framework.GraphicsDeviceManager(this);
            _graphicsDeviceManager.GraphicsProfile = Microsoft.Xna.Framework.Graphics.GraphicsProfile.Reach;
            _graphicsDeviceManager.SynchronizeWithVerticalRetrace = false;
            _graphicsDeviceManager.HardwareModeSwitch = true;
            _graphicsDeviceManager.IsFullScreen = false;
            _graphicsDeviceManager.PreferHalfPixelOffset = false;
            _graphicsDeviceManager.PreferredBackBufferFormat = Microsoft.Xna.Framework.Graphics.SurfaceFormat.Color;
            _graphicsDeviceManager.SupportedOrientations = Microsoft.Xna.Framework.DisplayOrientation.LandscapeLeft | Microsoft.Xna.Framework.DisplayOrientation.LandscapeRight | Microsoft.Xna.Framework.DisplayOrientation.Portrait | Microsoft.Xna.Framework.DisplayOrientation.PortraitDown | Microsoft.Xna.Framework.DisplayOrientation.Unknown | Microsoft.Xna.Framework.DisplayOrientation.Default;
            _graphicsDeviceManager.ApplyChanges();

            GraphicsDevice.BlendState = Microsoft.Xna.Framework.Graphics.BlendState.AlphaBlend;
            GraphicsDevice.DepthStencilState = Microsoft.Xna.Framework.Graphics.DepthStencilState.None;
            GraphicsDevice.RasterizerState = Microsoft.Xna.Framework.Graphics.RasterizerState.CullNone;

            Window.AllowAltF4 = true;
            Window.AllowUserResizing = true;
            Window.IsBorderless = false;
            Window.Position = new Microsoft.Xna.Framework.Point(GraphicsDevice.Adapter.CurrentDisplayMode.Width / 4, GraphicsDevice.Adapter.CurrentDisplayMode.Height / 4);
            Window.Title = "Graphing Calculator";
            Window.ClientSizeChanged += ResizeCallback;

            _spriteBatch = new Microsoft.Xna.Framework.Graphics.SpriteBatch(GraphicsDevice);
            _spriteBatch.Name = "Graphing Calculator Main SpriteBatch";
            _spriteBatch.Tag = null;

            InactiveSleepTime = new TimeSpan(0);
            TargetElapsedTime = new TimeSpan(10000000 / 60);
            MaxElapsedTime = new TimeSpan(10000000 / 60);
            IsFixedTimeStep = false;
            IsMouseVisible = true;

            Resize();
        }
        private double scrollValue = 1.0;
        private double xPosition = 0;
        private double yPosition = 0;
        protected override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            scrollValue = 1.0 + (Microsoft.Xna.Framework.Input.Mouse.GetState().ScrollWheelValue / 1000.0);

            _viewportMinX = xPosition - scrollValue;
            _viewportMinY = yPosition - scrollValue;
            _viewportMaxX = xPosition + scrollValue;
            _viewportMaxY = yPosition + scrollValue;

            Microsoft.Xna.Framework.Input.KeyboardState keyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();

            if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D))
            {
                xPosition += 0.1;
            }
            else if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A))
            {
                xPosition -= 0.1;
            }

            if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W))
            {
                yPosition += 0.1;
            }
            else if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S))
            {
                yPosition -= 0.1;
            }

            Profiler.RenderStart();
            Render();
            Profiler.RenderEnd();
            Profiler.DrawStart();
            _spriteBatch.Begin(Microsoft.Xna.Framework.Graphics.SpriteSortMode.Deferred, Microsoft.Xna.Framework.Graphics.BlendState.NonPremultiplied, Microsoft.Xna.Framework.Graphics.SamplerState.PointClamp, null, null, null, null);
            _spriteBatch.Draw(_renderCache.XNABase, new Microsoft.Xna.Framework.Rectangle(0, 0, _viewportPixelWidth, _viewportPixelHeight), Microsoft.Xna.Framework.Color.White);
            _spriteBatch.End();
            Profiler.DrawEnd();
            Profiler.Print();
        }
        public void Render()
        {
            _renderCache.Clear(Microsoft.Xna.Framework.Color.White);

            for (int x = 0; x < _viewportPixelWidth; x++)
            {
                for (int y = 0; y < _viewportPixelHeight; y++)
                {
                    double scaledX = _viewportMinX + ((_viewportMaxX - _viewportMinX) * (x / (double)_viewportPixelWidth));
                    double scaledY = _viewportMinY + ((_viewportMaxY - _viewportMinY) * (y / (double)_viewportPixelHeight));

                    double[] sampleArray = Graph.Sample(scaledX, scaledY);

                    double sampleX = sampleArray[0];
                    double sampleY = sampleArray[1];

                    double sample = Math.Atan2(sampleY, sampleX);

                    if(sample < 0)
                    {
                        sample += (Math.PI * 2.0);
                    }

                    Color c = ColorHelper.SampleHueGradient(sample / (Math.PI * 2.0));

                    _renderCache.SetPixelUnsafe(x, y, new Microsoft.Xna.Framework.Color(c.R, c.G, c.B, byte.MaxValue));
                }
            }
            _renderCache.Apply();
        }
        public void Resize()
        {
            if (_graphicsDeviceManager.IsFullScreen)
            {
                _viewportPixelWidth = GraphicsDevice.DisplayMode.Width;
                _viewportPixelHeight = GraphicsDevice.DisplayMode.Height;
            }
            else
            {
                _viewportPixelWidth = GraphicsDevice.Viewport.Width;
                _viewportPixelHeight = GraphicsDevice.Viewport.Height;
            }
            _renderCache = new Texture(GraphicsDevice, _viewportPixelWidth, _viewportPixelHeight);
            Render();
        }
        private void ResizeCallback(object sender, EventArgs e)
        {
            Resize();
        }
    }
}