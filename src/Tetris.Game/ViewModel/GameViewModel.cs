using Prism.Commands;
using System.Windows.Input;
using Tetris.Game.Control;
using Tetris.Game.Model;
using Tetris.Infrastructure;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using Tetris.Game.Intefaces;

namespace Tetris.Game.ViewModel {
    public class GameViewModel {
        public GameViewModel(CustomCanvas canvas) {
            _brickNavigators = new List<IBrickNavigator> {
                new SquareBrickNavigator()
            };
            _canvas = canvas;
            _canvas.MouseDown += _canvas_MouseDown;
            MoveDownCommand = new DelegateCommand(MoveDownAction);
            /*
            RightMoveCommand = new DelegateCommand(RightMoveAction);
            LeftMoveCommand = new DelegateCommand(LeftMoveAction);
            UpRotateCommand = new DelegateCommand(UpRotateAction);
            */
            _forge = new Forge();
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            _activeRects = new List<Rectangle>();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (_brickCounter >= 10) {
                return;
            }
            _brickCounter++;
            StartGame();
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            MoveDownAction();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e) {
            for (int i = 0; i < 20; i++) {
                Thread.Sleep(1000);
                worker.ReportProgress(i);
            }
        }

        /*
        private void UpRotateAction() {
            var rotateTransform = new RotateTransform(_angle, _activeShape.ActualHeight / 2, _activeShape.ActualWidth / 2);
            _activeShape.RenderTransform = rotateTransform;
            if (_angle == 360) {
                _angle = 90;
            }
            else {
                _angle += 90;
            }
        }

        // Todo-Remember to refactor magic numbers for stopping key movements

        private void LeftMoveAction() {
            var WidthToMove = Canvas.GetLeft(_activeShape) - _canvas.GetHorizontalSpacing();
            if (WidthToMove < -1) {
                return;
            }
            Canvas.SetLeft(_activeShape, WidthToMove);
        }
        
        private void RightMoveAction() {
            var WidthToMove = Canvas.GetLeft(_activeShape) + _canvas.GetHorizontalSpacing();
            if (WidthToMove >= 970) {
                return;
            }
            Canvas.SetLeft(_activeShape, WidthToMove);
        }
        */


        private void MoveDownAction() {
            _brickNavigators.First(x => x.IsMatched(_activeShape))
                            .MoveDown(_activeRects, _canvas);
        }

        private void _canvas_MouseDown(object sender, MouseButtonEventArgs e) {
            StartGame();
        }

        private void StartGame() {
            InJectBrick();
            worker.RunWorkerAsync();
        }

        private void InJectBrick() {
            var height = _canvas.GetVerticalSpacing();
            var width = _canvas.GetHorizontalSpacing();
            _forge.ActualWidth = width;
            _forge.ActualHeight = height;
            GetShapeData();

            _brickNavigators.First(x => x.IsMatched(_activeShape))
                            .Position(height, width, _activeRects, _canvas);
            _canvas.Focus();
        }

        
        private void GetShapeData() {
            //var rand = new Random();
            //var number = rand.Next(1, 5);
            var number = 1;
            switch (number) {
                case 1:
                    _activeRects = _forge.ForgeShape(BrickNames.SQUARE);
                    _activeShape = BrickNames.SQUARE;
                    break;
                default:
                    break;
            }       
        }

        public DelegateCommand MoveDownCommand { get; set; }
        public DelegateCommand RightMoveCommand { get; set; }
        public DelegateCommand LeftMoveCommand { get; set; }
        public DelegateCommand UpRotateCommand { get; set; }

        private string _activeShape;
        private int _brickCounter = 0;
        private CustomCanvas _canvas;
        private Forge _forge;
        private BackgroundWorker worker;
        private IEnumerable<Rectangle> _activeRects;
        private IEnumerable<IBrickNavigator> _brickNavigators;
    }
}
