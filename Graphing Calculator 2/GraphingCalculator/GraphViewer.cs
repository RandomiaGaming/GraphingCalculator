//Approved 07/08/2022
namespace GraphingCalculator
{
	public sealed class GraphViewer : Microsoft.Xna.Framework.Game
	{
		#region Private Variables
		private Grapher _Grapher = null;
		private Microsoft.Xna.Framework.Graphics.Texture2D _Render = null;
		private Microsoft.Xna.Framework.GraphicsDeviceManager _XNAGraphicsDeviceManager = null;
		private Microsoft.Xna.Framework.Graphics.GraphicsDevice _XNAGraphicsDevice = null;
		private Microsoft.Xna.Framework.GameWindow _XNAGameWindow = null;
		private Microsoft.Xna.Framework.Graphics.SpriteBatch _XNASpriteBatch = null;
		private Microsoft.Xna.Framework.Rectangle _XNAViewportRect = new Microsoft.Xna.Framework.Rectangle(0, 0, 1920, 1080);
		public int _viewportWidth = 1920;
		public int _viewportHeight = 1080;
		#endregion
		#region Public Constructors
		public GraphViewer(Grapher grapher)
		{
			if (grapher is null)
			{
				throw new System.Exception("grapher cannot be null.");
			}

			_Grapher = grapher;

			InactiveSleepTime = new System.TimeSpan(0);
			TargetElapsedTime = new System.TimeSpan(10000000 / 60);
			MaxElapsedTime = new System.TimeSpan(long.MaxValue);
			IsFixedTimeStep = false;
			IsMouseVisible = true;

			_XNAGraphicsDeviceManager = new Microsoft.Xna.Framework.GraphicsDeviceManager(this);
			_XNAGraphicsDeviceManager.GraphicsProfile = Microsoft.Xna.Framework.Graphics.GraphicsProfile.Reach;
			_XNAGraphicsDeviceManager.SynchronizeWithVerticalRetrace = false;
			_XNAGraphicsDeviceManager.HardwareModeSwitch = false;
			_XNAGraphicsDeviceManager.IsFullScreen = false;
			_XNAGraphicsDeviceManager.PreferHalfPixelOffset = false;
			_XNAGraphicsDeviceManager.PreferredBackBufferFormat = Microsoft.Xna.Framework.Graphics.SurfaceFormat.Color;
			_XNAGraphicsDeviceManager.SupportedOrientations = Microsoft.Xna.Framework.DisplayOrientation.LandscapeLeft | Microsoft.Xna.Framework.DisplayOrientation.LandscapeRight | Microsoft.Xna.Framework.DisplayOrientation.Portrait | Microsoft.Xna.Framework.DisplayOrientation.PortraitDown | Microsoft.Xna.Framework.DisplayOrientation.Unknown | Microsoft.Xna.Framework.DisplayOrientation.Default;
			_XNAGraphicsDeviceManager.ApplyChanges();

			_XNAGraphicsDevice = GraphicsDevice;

			_XNAGraphicsDevice.BlendState = Microsoft.Xna.Framework.Graphics.BlendState.AlphaBlend;
			_XNAGraphicsDevice.DepthStencilState = Microsoft.Xna.Framework.Graphics.DepthStencilState.None;
			_XNAGraphicsDevice.RasterizerState = Microsoft.Xna.Framework.Graphics.RasterizerState.CullNone;

			_XNAGameWindow = Window;

			_XNAGameWindow.AllowAltF4 = true;
			_XNAGameWindow.AllowUserResizing = true;
			_XNAGameWindow.IsBorderless = false;
			_XNAGameWindow.Position = new Microsoft.Xna.Framework.Point(_XNAGraphicsDevice.Adapter.CurrentDisplayMode.Width / 4, _XNAGraphicsDevice.Adapter.CurrentDisplayMode.Height / 4);
			_XNAGameWindow.Title = "Graph Viewer";

			_XNAGameWindow.ClientSizeChanged += ResizeCallback;

			_viewportWidth = _XNAGraphicsDevice.Viewport.Width;
			_viewportHeight = _XNAGraphicsDevice.Viewport.Height;
			_XNAViewportRect = new Microsoft.Xna.Framework.Rectangle(0, 0, _viewportWidth, _viewportHeight);

			_XNAGraphicsDeviceManager.PreferredBackBufferWidth = _viewportWidth;
			_XNAGraphicsDeviceManager.PreferredBackBufferHeight = _viewportHeight;
			_XNAGraphicsDeviceManager.ApplyChanges();

			_XNASpriteBatch = new Microsoft.Xna.Framework.Graphics.SpriteBatch(_XNAGraphicsDevice);
			_XNASpriteBatch.Name = "Main Sprite Batch";
			_XNASpriteBatch.Tag = null;

			ResizeCallback(null, null);
		}
		#endregion
		#region Private Methods
		private void ResizeCallback(object sender, System.EventArgs e)
		{
			if (_XNAGraphicsDeviceManager.IsFullScreen)
			{
				_viewportWidth = _XNAGraphicsDevice.Adapter.CurrentDisplayMode.Width;
				_viewportHeight = _XNAGraphicsDevice.Adapter.CurrentDisplayMode.Height;
			}
			else
			{
				_viewportWidth = _XNAGraphicsDevice.Viewport.Width;
				_viewportHeight = _XNAGraphicsDevice.Viewport.Height;
			}

			_XNAViewportRect.Width = _viewportWidth;
			_XNAViewportRect.Height = _viewportHeight;

			if (_XNAGraphicsDeviceManager.PreferredBackBufferWidth != _viewportWidth || _XNAGraphicsDeviceManager.PreferredBackBufferHeight != _viewportHeight)
			{
				_XNAGraphicsDeviceManager.PreferredBackBufferWidth = _viewportWidth;
				_XNAGraphicsDeviceManager.PreferredBackBufferHeight = _viewportHeight;
				_XNAGraphicsDeviceManager.ApplyChanges();
			}


			if (_Render is null || _viewportWidth != _Render.Width || _viewportHeight != _Render.Height)
			{
				_Render = _Grapher.Graph(_XNAGraphicsDevice, _viewportWidth, _viewportHeight);
			}
		}
		protected override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
		{
			System.Console.WriteLine(1.0 / gameTime.ElapsedGameTime.TotalSeconds + "FPS");

			_Render = _Grapher.Graph(_XNAGraphicsDevice, _viewportWidth, _viewportHeight);

			_XNASpriteBatch.Begin(Microsoft.Xna.Framework.Graphics.SpriteSortMode.Deferred, Microsoft.Xna.Framework.Graphics.BlendState.NonPremultiplied, Microsoft.Xna.Framework.Graphics.SamplerState.PointClamp, null, null, null, null);

			_XNASpriteBatch.Draw(_Render, _Render.Bounds, _XNAViewportRect, Microsoft.Xna.Framework.Color.White);

			_XNASpriteBatch.End();
		}
		#endregion
	}
}