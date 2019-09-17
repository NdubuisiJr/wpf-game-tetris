using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Media;
using Tetris.Infrastructure;
using System.Windows.Controls;
using Tetris.Game.Control;
using System.Linq;

namespace Tetris.Game.Model {
    public class Forge {
        public Forge() {
        }
        public List<Rectangle> ForgeShape(string shapeName) {
            var rects = new List<Rectangle>();
            if (shapeName.Equals(BrickNames.SQUARE)) {
                rects = CreateRectangles(4, ActualHeight, ActualWidth, Brushes.Yellow);
            }
            return rects;
        }

        public Grid GetShape(string shapeName) {
            var content = new Bricks().Content as Grid;
            var shape = content.Children
                               .OfType<Grid>()
                               .First(x => x.Name.Equals(shapeName));
            content.Children.Remove(shape);
            foreach (Rectangle rect in shape.Children) {
                rect.Height = ActualHeight;
                rect.Width = ActualWidth;
            }
            return shape;
        }

        private List<Rectangle> CreateRectangles(int number, double height, double width, Brush colour) {
            var rectangles = new List<Rectangle>();
            for (int i = 0; i < number; i++) {
                rectangles.Add(new Rectangle()
                {
                    Height = height,
                    Width = width,
                    Fill = colour,
                    Stroke = Brushes.Black,
                    StrokeThickness=1
                });
            }
            return rectangles;
        }
        public double ActualHeight { get; set; }
        public double ActualWidth { get; set; }
    }
}
