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

        private static UIColor _GreenColor;
        public static UIColor GreenColor { get { if (_GreenColor == null) _GreenColor = UIColor.Clear.FromHex("#009900"); return _GreenColor; } }

        private static UIColor _RedColor;
        public static UIColor RedColor { get { if (_RedColor == null) _RedColor = UIColor.Clear.FromHex("#990000"); return _RedColor; } }
    }
}
