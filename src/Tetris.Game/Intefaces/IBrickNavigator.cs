using System.Collections.Generic;
using System.Windows.Shapes;
using Tetris.Game.Control;

namespace Tetris.Game.Intefaces {
    public interface IBrickNavigator {
        void Position(double height, double width, IEnumerable<Rectangle> activeRects, CustomCanvas canvas);
        void MoveDown(IEnumerable<Rectangle> rectangles, CustomCanvas canvas);
        void MoveLeft();
        void MoveRight();
        void Rotate();
        bool IsMatched(string brickName);
    }
}
