using GameOverlay.Drawing;
using GameOverlay.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScoobyNET.DXUI
{
    public class Overlay : IDisposable
	{

		private Thread GFXThread;

		private readonly StickyWindow _window;

		private readonly Dictionary<string, SolidBrush> _brushes;
		private readonly Dictionary<string, Font> _fonts;
		private readonly Dictionary<string, Image> _images;

		private Geometry _gridGeometry;
		private Rectangle _gridBounds;

		private Random _random;
		private long _lastRandomSet;
		private List<Action<Graphics, float, float>> _randomFigures;

		public string Screentext = "";

		public Overlay()
		{
			_brushes = new Dictionary<string, SolidBrush>();
			_fonts = new Dictionary<string, Font>();
			_images = new Dictionary<string, Image>();

			var gfx = new Graphics()
			{
				MeasureFPS = true,
				PerPrimitiveAntiAliasing = true,
				TextAntiAliasing = true
			};

			IntPtr gameWindow = IntPtr.Zero;

			foreach (var handle in Imports.EnumerateProcessWindowHandles(
			Process.GetProcessesByName("Dolphin").First().Id))
			{
				StringBuilder message = new StringBuilder(1000);
				Imports.SendMessage(handle, Imports.WM_GETTEXT, message.Capacity, message);
				string title = message.ToString();
				if (title.Contains("FPS") && title.Contains("VPS"))
				{
					gameWindow = handle;
					break;
				}
			}


			if (gameWindow == IntPtr.Zero)
				return;

			_window = new StickyWindow(gameWindow, gfx)
			{
				FPS = 60,
				IsTopmost = true,
				IsVisible = true
			};

			_window.DestroyGraphics += _window_DestroyGraphics;
			_window.DrawGraphics += _window_DrawGraphics;
			_window.SetupGraphics += _window_SetupGraphics;
		}

		private void _window_SetupGraphics(object sender, SetupGraphicsEventArgs e)
		{
			var gfx = e.Graphics;

			if (e.RecreateResources)
			{
				foreach (var pair in _brushes) pair.Value.Dispose();
				foreach (var pair in _images) pair.Value.Dispose();
			}

			_brushes["black"] = gfx.CreateSolidBrush(0, 0, 0);
			_brushes["white"] = gfx.CreateSolidBrush(255, 255, 255);
			_brushes["red"] = gfx.CreateSolidBrush(255, 0, 0);
			_brushes["green"] = gfx.CreateSolidBrush(0, 255, 0);
			_brushes["blue"] = gfx.CreateSolidBrush(0, 0, 255);
			_brushes["background"] = gfx.CreateSolidBrush(0x33, 0x36, 0x3F);
			_brushes["grid"] = gfx.CreateSolidBrush(255, 255, 255, 0.2f);
			_brushes["random"] = gfx.CreateSolidBrush(0, 0, 0);

			if (e.RecreateResources) return;

			_fonts["arial"] = gfx.CreateFont("Arial", 12);
			_fonts["consolas"] = gfx.CreateFont("Consolas", 14);

			_gridBounds = new Rectangle(20, 60, gfx.Width - 20, gfx.Height - 20);
			_gridGeometry = gfx.CreateGeometry();

			for (float x = _gridBounds.Left; x <= _gridBounds.Right; x += 20)
			{
				var line = new Line(x, _gridBounds.Top, x, _gridBounds.Bottom);
				_gridGeometry.BeginFigure(line);
				_gridGeometry.EndFigure(false);
			}

			for (float y = _gridBounds.Top; y <= _gridBounds.Bottom; y += 20)
			{
				var line = new Line(_gridBounds.Left, y, _gridBounds.Right, y);
				_gridGeometry.BeginFigure(line);
				_gridGeometry.EndFigure(false);
			}

			_gridGeometry.Close();

			_randomFigures = new List<Action<Graphics, float, float>>()
			{
				(g, x, y) => g.DrawRectangle(GetRandomColor(), x + 10, y + 10, x + 110, y + 110, 2.0f),
				(g, x, y) => g.DrawCircle(GetRandomColor(), x + 60, y + 60, 48, 2.0f),
				(g, x, y) => g.DrawRoundedRectangle(GetRandomColor(), x + 10, y + 10, x + 110, y + 110, 8.0f, 2.0f),
				(g, x, y) => g.DrawTriangle(GetRandomColor(), x + 10, y + 110, x + 110, y + 110, x + 60, y + 10, 2.0f),
				(g, x, y) => g.DashedRectangle(GetRandomColor(), x + 10, y + 10, x + 110, y + 110, 2.0f),
				(g, x, y) => g.DashedCircle(GetRandomColor(), x + 60, y + 60, 48, 2.0f),
				(g, x, y) => g.DashedRoundedRectangle(GetRandomColor(), x + 10, y + 10, x + 110, y + 110, 8.0f, 2.0f),
				(g, x, y) => g.DashedTriangle(GetRandomColor(), x + 10, y + 110, x + 110, y + 110, x + 60, y + 10, 2.0f),
				(g, x, y) => g.FillRectangle(GetRandomColor(), x + 10, y + 10, x + 110, y + 110),
				(g, x, y) => g.FillCircle(GetRandomColor(), x + 60, y + 60, 48),
				(g, x, y) => g.FillRoundedRectangle(GetRandomColor(), x + 10, y + 10, x + 110, y + 110, 8.0f),
				(g, x, y) => g.FillTriangle(GetRandomColor(), x + 10, y + 110, x + 110, y + 110, x + 60, y + 10),
			};
		}

		private void _window_DestroyGraphics(object sender, DestroyGraphicsEventArgs e)
		{
			DolphinComm.DolphinAccessor.unHook();
			foreach (var pair in _brushes) pair.Value.Dispose();
			foreach (var pair in _fonts) pair.Value.Dispose();
			foreach (var pair in _images) pair.Value.Dispose();
		}

		private void _window_DrawGraphics(object sender, DrawGraphicsEventArgs e)
		{
			var gfx = e.Graphics;

			var padding = 8;

#if DEBUG

			string infoText = new StringBuilder()
				.Append("FPS: ").Append(gfx.FPS.ToString().PadRight(padding))
				.Append("FrameTime: ").Append(e.FrameTime.ToString().PadRight(padding))
				.Append("FrameCount: ").Append(e.FrameCount.ToString().PadRight(padding))
				.Append("DeltaTime: ").Append(e.DeltaTime.ToString().PadRight(padding))
				.Append("\n")
				.ToString();
#else
			string infoText = "";
#endif

			gfx.ClearScene();

            gfx.DrawText(_fonts["consolas"], 14.0f, _brushes["green"], 11, 30, infoText + Screentext);
		}

        private void DrawRandomFigure(Graphics gfx, float x, float y)
		{
			var action = _randomFigures[_random.Next(0, _randomFigures.Count)];

			action(gfx, x, y);
		}

		private SolidBrush GetRandomColor()
		{
			var brush = _brushes["random"];

			brush.Color = new Color(_random.Next(0, 256), _random.Next(0, 256), _random.Next(0, 256));

			return brush;
		}

		public void Run()
		{
			if (_window == null)
				return;

			if (GFXThread == null)
            {
				GFXThread = new Thread(() =>
				{
					Thread.CurrentThread.IsBackground = true;
					_window.Create();
					_window.Join();
				});

				GFXThread.Start();
            }
		}

		~Overlay()
		{
			GFXThread.Abort();
			Dispose(false);
		}

#region IDisposable Support
		private bool disposedValue;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				_window.Dispose();

				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
#endregion
	}
}
