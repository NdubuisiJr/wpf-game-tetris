using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tetris.Game.Control {
    public class CustomCanvas : Canvas {
        protected override void OnRender(DrawingContext dc) {
            dc.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Black, 1), new Rect(0, 0, ActualWidth, ActualHeight));
            DrawVerticalLines(28, dc);
            DrawHonrizontallines(22, dc);
        }

        private void DrawHonrizontallines(int number, DrawingContext dc) {
            var spacing = ActualHeight / number;
            var space = spacing;
            for (int i = 0; i < number; i++) {
                dc.DrawLine(new Pen(Brushes.Black, 1), new Point(0,spacing), new Point(ActualWidth, spacing));
                spacing = spacing + space;
            }
            _verticalSpace = space;
        }

        private void DrawVerticalLines(int number, DrawingContext dc) {
            var spacing = ActualWidth/number;
            var space = spacing;
            for (int i = 0; i < number; i++) {
                dc.DrawLine(new Pen(Brushes.Black, 1), new Point(spacing, 0), new Point(spacing, ActualHeight));
                spacing = spacing+space;
            }
            _horizontalSpace = space;
        }
        public double GetVerticalSpacing() {
            return _verticalSpace;
        }

        public double GetHorizontalSpacing() {
            return _horizontalSpace;
        }

        double _verticalSpace;
        double _horizontalSpace;
    }
}
