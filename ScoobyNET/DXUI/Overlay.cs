using GameOverlay.Drawing;
using GameOverlay.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace ScoobyNET.DXUI
{
    public class Overlay : IDisposable
    {
        private Thread GFXThread;
        private StickyWindow _window;

        private readonly Dictionary<string, SolidBrush> _brushes;
        private readonly Dictionary<string, Font> _fonts;
        private readonly Dictionary<string, Image> _images;

        private Geometry _gridGeometry;
        private Rectangle _gridBounds;

        private Random _random = new Random();
        private List<Action<Graphics, float, float>> _randomFigures;

        public string Screentext = "";

        public Overlay()
        {
            _brushes = new Dictionary<string, SolidBrush>();
            _fonts = new Dictionary<string, Font>();
            _images = new Dictionary<string, Image>();
        }

        private IntPtr FindDolphinWindow()
        {
            var dolphinProcesses = Process.GetProcessesByName("Dolphin");
            if (!dolphinProcesses.Any())
                return IntPtr.Zero;

            foreach (var handle in Imports.EnumerateProcessWindowHandles(dolphinProcesses.First().Id))
            {
                StringBuilder message = new StringBuilder(1000);
                Imports.SendMessage(handle, Imports.WM_GETTEXT, message.Capacity, message);
                string title = message.ToString();
                if (title.Contains("FPS") && title.Contains("VPS"))
                    return handle;
                else if (title.Contains("G5DE78") || title.Contains("G5DP78"))
                    return handle;
            }

            return IntPtr.Zero;
        }

        public void Run()
        {
            if (GFXThread != null)
                return;

            GFXThread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                IntPtr gameWindow = IntPtr.Zero;

                while (gameWindow == IntPtr.Zero)
                {
                    gameWindow = FindDolphinWindow();
                }

                var gfx = new Graphics()
                {
                    MeasureFPS = true,
                    PerPrimitiveAntiAliasing = true,
                    TextAntiAliasing = true
                };

                _window = new StickyWindow(gameWindow, gfx)
                {
                    FPS = 60,
                    IsTopmost = true,
                    IsVisible = true
                };

                _window.DestroyGraphics += _window_DestroyGraphics;
                _window.DrawGraphics += _window_DrawGraphics;
                _window.SetupGraphics += _window_SetupGraphics;

                _window.Create();
                _window.Join();
            });

            GFXThread.Start();
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

#if DEBUG
            string infoText = new StringBuilder()
                .Append("FPS: ").Append(gfx.FPS).Append("  ")
                .Append("FrameTime: ").Append(e.FrameTime).Append("  ")
                .Append("FrameCount: ").Append(e.FrameCount).Append("  ")
                .Append("DeltaTime: ").Append(e.DeltaTime).Append("\n")
                .ToString();
#else
            string infoText = "";
#endif

            gfx.ClearScene();

            gfx.DrawText(_fonts["consolas"], 14.0f, _brushes["green"], 11, 30, infoText + Screentext);
        }

        private SolidBrush GetRandomColor()
        {
            var brush = _brushes["random"];
            brush.Color = new Color(_random.Next(0, 256), _random.Next(0, 256), _random.Next(0, 256));
            return brush;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _window?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Overlay()
        {
            Dispose(false);
        }
    }
}
