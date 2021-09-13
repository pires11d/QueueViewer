using QueueViewer.Forms.Entities;
using System;
using System.Drawing;

namespace QueueViewer.Forms
{
    public static class Colors
    {
        public static Color LightestGray { get; set; } = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
        public static Color LighterGray { get; set; } = System.Drawing.ColorTranslator.FromHtml("#cccccc");
        public static Color LightGray { get; set; } = System.Drawing.ColorTranslator.FromHtml("#848484");
        public static Color DarkGray { get; set; } = System.Drawing.ColorTranslator.FromHtml("#333333");
        public static Color DarkerGray { get; set; } = System.Drawing.ColorTranslator.FromHtml("#252526");
        public static Color DarkestGray { get; set; } = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");

        public static Color GetDefaultColor(ThemesEnum theme)
        {
            switch (theme)
            {
                case ThemesEnum.Light:
                    return Color.White;
                case ThemesEnum.Dark:
                    return Color.Black;
                default:
                    return Color.White;
            }
        }

        public static Color GetBackColor(ThemesEnum theme)
        {
            switch (theme)
            {
                case ThemesEnum.Light:
                    return LightestGray;
                case ThemesEnum.Dark:
                    return DarkestGray;
                default:
                    return LightestGray;
            }
        }

        public static Color GetForeColor(ThemesEnum theme)
        {
            switch (theme)
            {
                case ThemesEnum.Light:
                    return Color.Black;
                case ThemesEnum.Dark:
                    return LightestGray;
                default:
                    return Color.Black;
            }
        }

        public static Color GetBlue(ThemesEnum theme)
        {
            switch (theme)
            {
                case ThemesEnum.Light:
                    return Color.Blue;
                case ThemesEnum.Dark:
                    return Color.SkyBlue;
                default:
                    return Color.Blue;
            }
        }

        public static Color GetRed(ThemesEnum theme)
        {
            switch (theme)
            {
                case ThemesEnum.Light:
                    return Color.DarkRed;
                case ThemesEnum.Dark:
                    return Color.LightSalmon;
                default:
                    return Color.DarkRed;
            }
        }

        public static Color GetGreen(ThemesEnum theme)
        {
            switch (theme)
            {
                case ThemesEnum.Light:
                    return Color.DarkGreen;
                case ThemesEnum.Dark:
                    return Color.Green;
                default:
                    return Color.DarkGreen;
            }
        }

        public static Color GetYellow(ThemesEnum theme)
        {
            switch (theme)
            {
                case ThemesEnum.Light:
                    return Color.DarkGoldenrod;
                case ThemesEnum.Dark:
                    return Color.Yellow;
                default:
                    return Color.DarkGoldenrod;
            }
        }

        public static Color GetViolet(ThemesEnum theme)
        {
            switch (theme)
            {
                case ThemesEnum.Light:
                    return Color.DarkViolet;
                case ThemesEnum.Dark:
                    return Color.Violet;
                default:
                    return Color.DarkViolet;
            }
        }

        public static Color GetHighlightColor(ThemesEnum theme)
        {
            switch (theme)
            {
                case ThemesEnum.Light:
                    return SystemColors.ActiveCaption;
                case ThemesEnum.Dark:
                    return SystemColors.Highlight;
                default:
                    return SystemColors.ActiveCaption;
            }
        }
    }
}
