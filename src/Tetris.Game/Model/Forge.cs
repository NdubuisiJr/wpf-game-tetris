using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Media;
using Tetris.Infrastructure;
using System.Linq;

namespace Tetris.Game.Model {
    public class Forge {
        public Forge() {
        }
        public IEnumerable<Rectangle> ForgeShape(string shapeName) {
            IEnumerable<Rectangle> rects = null;
            if (shapeName.Equals(BrickNames.SQUARE)) {
                rects = CreateRectangles(4, ActualHeight, ActualWidth, Brushes.Yellow);
            }
            return rects;
        }

        private IEnumerable<Rectangle> CreateRectangles(int number, double height, double width, Brush colour) {
            var rectangles = new List<Rectangle>();
            for (int i = 0; i < number; i++) {
                rectangles.Add(new Rectangle()
                {
                    Height = height,
                    Width = width,
                    Fill = colour,
                    Stroke = Brushes.Black,
                });
            }
            return rectangles;
        }
        public double ActualHeight { get; set; }
        public double ActualWidth { get; set; }
    }
}
