using System.Windows.Media;

namespace hogwartsBingus.DataStorage
{
    public static class DraculaThemeColors
    {
        public static readonly Color Green = Color.FromRgb(80, 250, 123);
        public static readonly Color Red = Color.FromRgb(255, 85, 85);
        public static readonly Color White = Color.FromRgb(248, 248, 242);

        public static readonly SolidColorBrush RedBrush = new SolidColorBrush(Red);
        public static readonly SolidColorBrush GreenBrush = new SolidColorBrush(Green);
        public static readonly SolidColorBrush WhiteBrush = new SolidColorBrush(White);
    }
}