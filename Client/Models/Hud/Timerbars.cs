using System.Collections.Generic;
using Font = CitizenFX.Core.UI.Font;
using CitizenFX.Core.UI;
using System.Drawing;
using static CitizenFX.Core.Native.API;
using System;

namespace Client.Models.Hud
{
    internal static class UIMenu
    {
        /// <summary>
        /// Returns the 1080pixels-based screen resolution while mantaining current aspect ratio.
        /// </summary>
        /// <returns></returns>
        public static SizeF GetScreenResolutionMaintainRatio()
        {
            int screenw = 0;
            int screenh = 0;
            GetActiveScreenResolution(ref screenw, ref screenh);
            const float height = 1080f;
            float ratio = (float)screenw / screenh;
            var width = height * ratio;

            return new SizeF(width, height);
        }

        /// <summary>
        /// Returns the safezone bounds in pixel, relative to the 1080pixel based system.
        /// </summary>
        /// <returns></returns>
        public static PointF GetSafezoneBounds()
        {
            float t = GetSafeZoneSize(); // Safezone size.
            double g = Math.Round(Convert.ToDouble(t), 2);
            g = (g * 100) - 90;
            g = 10 - g;

            const float hmp = 5.4f;
            int screenw = 0;
            int screenh = 0;
            GetActiveScreenResolution(ref screenw, ref screenh);
            float ratio = (float)screenw / screenh;
            float wmp = ratio * hmp;


            return new PointF((int)Math.Round(g * wmp), (int)Math.Round(g * hmp));
        }
    }

    public abstract class TimerBarBase
    {
        public string Label { get; set; }

        public TimerBarBase(string label)
        {
            Label = label;
        }

        public virtual void Draw(int interval)
        {
            SizeF res = UIMenu.GetScreenResolutionMaintainRatio();
            PointF safe = UIMenu.GetSafezoneBounds();
            new UIResText(Label, new PointF((int)res.Width - safe.X - 180, (int)res.Height - safe.Y - (30 + (4 * interval))), 0.3f, Color.FromArgb(255, 255, 255, 255), Font.ChaletLondon, UIResText.ScreenAlignment.Right).Draw();

            CitizenFX.Core.Native.API.DrawSprite("timerbars", "all_black_bg", ((int)res.Width - safe.X - 298) / res.Width + (300f / res.Width / 2), (res.Height - safe.Y - (40 + (4 * interval))) / res.Height + (37 / res.Height / 2), 300f / res.Width, 37f / res.Height, 0f, 255, 255, 255, 180);

            // TODO: just move them instead
            HideHudComponentThisFrame(7);
            HideHudComponentThisFrame(9);
            HideHudComponentThisFrame(6);
        }
    }

    public class TextTimerBar : TimerBarBase
    {
        public string Text { get; set; }

        public TextTimerBar(string label, string text) : base(label)
        {
            Text = text;
        }

        public override void Draw(int interval)
        {
            SizeF res = UIMenu.GetScreenResolutionMaintainRatio();
            PointF safe = UIMenu.GetSafezoneBounds();

            base.Draw(interval);
            new UIResText(Text, new PointF((int)res.Width - safe.X - 10, (int)res.Height - safe.Y - (42 + (4 * interval))), 0.5f, Color.FromArgb(-1), Font.ChaletLondon, UIResText.ScreenAlignment.Right).Draw();
        }
    }

    public class BarTimerBar : TimerBarBase
    {
        /// <summary>
        /// Bar percentage. Goes from 0 to 1.
        /// </summary>
        public float Percentage { get; set; }

        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }

        public BarTimerBar(string label) : base(label)
        {
            BackgroundColor = Color.FromArgb(-7667712);
            ForegroundColor = Color.FromArgb(-65536);
        }

        public override void Draw(int interval)
        {
            SizeF res = UIMenu.GetScreenResolutionMaintainRatio();
            PointF safe = UIMenu.GetSafezoneBounds();

            base.Draw(interval);

            var start = new PointF((int)res.Width - safe.X - 160, (int)res.Height - safe.Y - (28 + (4 * interval)));

            new UIResRectangle(start, new SizeF(150, 15), BackgroundColor).Draw();
            new UIResRectangle(start, new SizeF((int)(150 * Percentage), 15), ForegroundColor).Draw();
        }
    }

    public class TimerBarPool
    {
        private static List<TimerBarBase> _bars = new List<TimerBarBase>();

        public TimerBarPool()
        {
            _bars = new List<TimerBarBase>();
        }

        public List<TimerBarBase> ToList()
        {
            return _bars;
        }

        public void Add(TimerBarBase timer)
        {
            _bars.Add(timer);
        }

        public void Remove(TimerBarBase timer)
        {
            _bars.Remove(timer);
        }

        public void Draw()
        {
            for (int i = 0; i < _bars.Count; i++)
            {
                _bars[i].Draw(i * 10);
            }
        }
    }

    /// <summary>
    /// A rectangle in 1080 pixels height system.
    /// </summary>
    public class UIResRectangle : CitizenFX.Core.UI.Rectangle
    {
        public UIResRectangle()
        { }

        public UIResRectangle(PointF pos, SizeF size) : base(pos, size)
        { }

        public UIResRectangle(PointF pos, SizeF size, Color color) : base(pos, size, color)
        { }

        public override void Draw(SizeF offset)
        {
            if (!Enabled) return;
            int screenw = 0;
            int screenh = 0;
            GetActiveScreenResolution(ref screenw, ref screenh);
            const float height = 1080f;
            float ratio = (float)screenw / screenh;
            var width = height * ratio;

            float w = Size.Width / width;
            float h = Size.Height / height;
            float x = ((Position.X + offset.Width) / width) + w * 0.5f;
            float y = ((Position.Y + offset.Height) / height) + h * 0.5f;

            DrawRect(x, y, w, h, Color.R, Color.G, Color.B, Color.A);
        }

        public static void Draw(float xPos, float yPos, int boxWidth, int boxHeight, Color color)
        {
            int screenw = 0;
            int screenh = 0;
            GetActiveScreenResolution(ref screenw, ref screenh);
            const float height = 1080f;
            float ratio = (float)screenw / screenh;
            var width = height * ratio;

            float w = boxWidth / width;
            float h = boxHeight / height;
            float x = ((xPos) / width) + w * 0.5f;
            float y = ((yPos) / height) + h * 0.5f;
            DrawRect(x, y, w, h, color.R, color.G, color.B, color.A);
        }
    }

    /// <summary>
    /// A Text object in the 1080 pixels height base system.
    /// </summary>
    public class UIResText : Text
    {
        public UIResText(string caption, PointF position, float scale) : base(caption, position, scale)
        {
            TextAlignment = ScreenAlignment.Left;
        }

        public UIResText(string caption, PointF position, float scale, Color color)
            : base(caption, position, scale, color)
        {
            TextAlignment = ScreenAlignment.Left;
        }

        public UIResText(string caption, PointF position, float scale, Color color, Font font, ScreenAlignment justify)
            : base(caption, position, scale, color, font, CitizenFX.Core.UI.Alignment.Left)
        {
            TextAlignment = justify;
        }


        public ScreenAlignment TextAlignment { get; set; }
        public bool DropShadow { get; set; } = false;
        public new bool Outline { get; set; } = false;

        /// <summary>
        /// Push a long string into the stack.
        /// </summary>
        /// <param name="str"></param>
        public static void AddLongString(string str)
        {
            var utf8ByteCount = System.Text.Encoding.UTF8.GetByteCount(str);

            if (utf8ByteCount == str.Length)
            {
                AddLongStringForAscii(str);
            }
            else
            {
                AddLongStringForUtf8(str);
            }
        }

        private static void AddLongStringForAscii(string input)
        {
            const int maxByteLengthPerString = 99;

            for (int i = 0; i < input.Length; i += maxByteLengthPerString)
            {
                string substr = (input.Substring(i, Math.Min(maxByteLengthPerString, input.Length - i)));
                AddTextComponentString(substr);
            }
        }

        private static void AddLongStringForUtf8(string input)
        {
            const int maxByteLengthPerString = 99;

            if (maxByteLengthPerString < 0)
            {
                throw new ArgumentOutOfRangeException("maxLengthPerString");
            }
            if (string.IsNullOrEmpty(input) || maxByteLengthPerString == 0)
            {
                return;
            }

            var enc = System.Text.Encoding.UTF8;

            var utf8ByteCount = enc.GetByteCount(input);
            if (utf8ByteCount < maxByteLengthPerString)
            {
                AddTextComponentString(input);
                return;
            }

            var startIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var length = i - startIndex;
                if (enc.GetByteCount(input.Substring(startIndex, length)) > maxByteLengthPerString)
                {
                    string substr = (input.Substring(startIndex, length - 1));
                    AddTextComponentString(substr);

                    i -= 1;
                    startIndex = (startIndex + length - 1);
                }
            }
            AddTextComponentString(input.Substring(startIndex, input.Length - startIndex));
        }

        public static float MeasureStringWidth(string str, Font font, float scale)
        {
            int screenw = Screen.Resolution.Width;
            int screenh = Screen.Resolution.Height;

            const float height = 1080f;
            float ratio = (float)screenw / screenh;
            float width = height * ratio;
            return MeasureStringWidthNoConvert(str, font, scale) * width;
        }

        public static float MeasureStringWidthNoConvert(string str, Font font, float scale)
        {
            BeginTextCommandWidth("STRING");
            AddLongString(str);
            return EndTextCommandGetWidth(true) * scale;
        }

        public SizeF WordWrap { get; set; }

        public override void Draw(SizeF offset)
        {
            int screenw = 0;
            int screenh = 0;
            GetActiveScreenResolution(ref screenw, ref screenh);
            const float height = 1080f;
            float ratio = (float)screenw / screenh;
            var width = height * ratio;

            float x = (Position.X) / width;
            float y = (Position.Y) / height;

            SetTextFont((int)Font);
            SetTextScale(1f, Scale);
            SetTextColour(Color.R, Color.G, Color.B, Color.A);
            if (DropShadow)
                SetTextDropShadow();
            if (Outline)
                SetTextOutline();
            switch (TextAlignment)
            {
                case ScreenAlignment.Centered:
                    SetTextCentre(true);
                    break;
                case ScreenAlignment.Right:
                    SetTextRightJustify(true);
                    SetTextWrap(0, x);
                    break;
            }

            if (WordWrap.Width != 0)
            {
                float xsize = (Position.X + WordWrap.Width) / width;
                SetTextWrap(x, xsize);
            }

            SetTextEntry("jamyfafi");
            AddLongString(Caption);

            DrawText(x, y);
        }

        public enum ScreenAlignment
        {
            Left,
            Centered,
            Right,
        }
    }
}
