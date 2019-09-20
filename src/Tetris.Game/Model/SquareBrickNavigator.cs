using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Shapes;
using Tetris.Game.Control;
using Tetris.Game.Intefaces;
using Tetris.Infrastructure;

namespace Tetris.Game.Model {
    public class SquareBrickNavigator : IBrickNavigator {
        public bool IsMatched(string brickName) {
            return brickName == BrickNames.SQUARE;
        }

        public void MoveDown(IEnumerable<Rectangle> rectangles, CustomCanvas canvas) {
            foreach (var rect in rectangles) {
                var heightToMove = Canvas.GetTop(rect) + canvas.GetVerticalSpacing();
                if (heightToMove >= canvas.ActualHeight) {
                    if (rect.Name=="s0" || rect.Name=="s1") {
                        Canvas.SetTop(rect, Canvas.GetTop(rect));
                        continue;
                    }
                    Canvas.SetTop(rect, heightToMove -= canvas.GetVerticalSpacing());
                    continue;
                }
                else {
                    Canvas.SetTop(rect, heightToMove);
                }
                
            }
        }

        public void MoveLeft() {
            throw new NotImplementedException();
        }

        public void MoveRight() {
            throw new NotImplementedException();
        }

        public void Position(double height, double width, IEnumerable<Rectangle> activeRects, CustomCanvas canvas) {
            // foreach for Square
            double positioningHeight = height;
            double positioningWidth = 12 * width;
            for (int i = 0; i < activeRects.Count(); i++) {
                switch (i) {
                    case 0:
                        activeRects.ElementAt(i).Name = "s0";
                        Canvas.SetLeft(activeRects.ElementAt(i), positioningWidth);
                        Canvas.SetTop(activeRects.ElementAt(i), positioningHeight);
                        break;
                    case 1:
                        activeRects.ElementAt(i).Name = "s1";
                        positioningWidth += width;
                        Canvas.SetLeft(activeRects.ElementAt(i), positioningWidth);
                        Canvas.SetTop(activeRects.ElementAt(i), positioningHeight);
                        break;
                    case 2:
                        positioningHeight += height;
                        positioningWidth -= width;
                        Canvas.SetLeft(activeRects.ElementAt(i), positioningWidth);
                        Canvas.SetTop(activeRects.ElementAt(i), positioningHeight);
                        break;
                    case 3:
                        positioningWidth += width;
                        Canvas.SetLeft(activeRects.ElementAt(i), positioningWidth);
                        Canvas.SetTop(activeRects.ElementAt(i), positioningHeight);
                        break;
                    default:
                        break;
                }
            }
            foreach (var rect in activeRects) {
                canvas.Children.Add(rect);
            }
        }

        public void Rotate() {
            throw new NotImplementedException();
        }
    }
}
