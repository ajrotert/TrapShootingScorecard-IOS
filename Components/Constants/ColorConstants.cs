using System;
using UIKit;
using AR.TrapScorecard.Components.Extensions;

namespace AR.TrapScorecard.Components.Constants
{
    public static class ColorConstants
    {
        private static UIColor _PrimaryColor;
        public static UIColor PrimaryColor { get { if (_PrimaryColor == null) _PrimaryColor = UIColor.Clear.FromHex("#cc3300"); return _PrimaryColor; } }

        private static UIColor _BackgroundColor;
        public static UIColor BackgroundColor { get { if (_BackgroundColor == null) _BackgroundColor = UIColor.Clear.FromHex("#F8F8F8"); return _BackgroundColor; } }

        private static UIColor _TextColor;
        public static UIColor TextColor { get { if (_TextColor == null) _TextColor = UIColor.Clear.FromHex("#383838"); return _TextColor; } }

        private static UIColor _HitColor;
        public static UIColor HitColor { get { if (_HitColor == null) _HitColor = UIColor.Clear.FromHex("#009900"); return _HitColor; } }

        private static UIColor _LossColor;
        public static UIColor LossColor { get { if (_LossColor == null) _LossColor = UIColor.Clear.FromHex("#990000"); return _LossColor; } }
    }
}
