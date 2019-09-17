using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Tetris.Domain.Bricks {
    public class Elbow : TetrisBrick {
        protected override void OnRender(DrawingContext drawingContext) {
            var polylineSegment = new PolyLineSegment( new List<Point>
                {
                    new Point(_startingWidth,_startingHeight),
                    new Point(_startingWidth,_drawingHeight),
                    new Point(_doubleWidth,_drawingHeight),
                    new Point(_doubleWidth,_halfHeight),
                    new Point(_halfWidth,_halfHeight),
                    new Point(_halfWidth,_startingHeight)
                }
                ,true);
            Draw(drawingContext, polylineSegment,Brushes.Green);
        }
    }
}
