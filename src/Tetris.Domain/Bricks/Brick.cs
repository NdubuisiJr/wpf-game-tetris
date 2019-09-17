using System.Windows;
using System.Windows.Media;

namespace Tetris.Domain.Bricks {
    public class Brick : FrameworkElement {
        protected override void OnRender(DrawingContext drawingContext) {
            drawingContext.DrawRectangle(Colour, new Pen(Brushes.Black, 1), new Rect(0, 0, _drawingWidth, _drawingHeight));
        }
        public Brush Colour { get; set; }
        public double SavedHeight { get { return ActualHeight; } }
        public double SavedWidth { get { return ActualHeight; } }
        protected double _drawingHeight = 25;
        protected double _drawingWidth = 25;
    }
}
