using Prism.Commands;
using System.Windows.Controls;
using System.Windows.Input;
using Tetris.Game.Control;
using Tetris.Game.Model;
using Tetris.Infrastructure;
using System.Windows.Media;
using System;
using System.Threading;
using System.ComponentModel;

namespace Tetris.Game.ViewModel {
    public class GameViewModel {
        public GameViewModel(CustomCanvas canvas) {
            _canvas = canvas;
            _canvas.MouseDown += _canvas_MouseDown;
            MoveDownCommand = new DelegateCommand(MoveDownAction);
            RightMoveCommand = new DelegateCommand(RightMoveAction);
            LeftMoveCommand = new DelegateCommand(LeftMoveAction);
            UpRotateCommand = new DelegateCommand(UpRotateAction);
            _forge = new Forge();
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (_brickCounter>=10) {
                return;
            }
            _brickCounter += 1;
            StartGame();
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            MoveDownAction();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e) {
            for (int i = 0; i < 20; i++) {
                Thread.Sleep(300);
                worker.ReportProgress(i);
            }
        }

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

        private void MoveDownAction() {
            var heightToMove = Canvas.GetTop(_activeShape) + _canvas.GetVerticalSpacing();
            if (heightToMove >= 590) {
                return;
            }
            Canvas.SetTop(_activeShape, heightToMove);
        }

        private void MoveDownAction(Grid shape, CustomCanvas canvas) {
            var heightToMove = Canvas.GetTop(shape) + canvas.GetVerticalSpacing();
            if (heightToMove >= 590) {
                return;
            }
            Canvas.SetTop(shape, heightToMove);
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
            Canvas.SetLeft(_activeShape, width + width + width + width + width + width);
            Canvas.SetTop(_activeShape, height);
            _canvas.Children.Add(_activeShape);
            _canvas.Focus();
        }

        private void GetShapeData() {
            var rand = new Random();
            var number = rand.Next(1, 5);

            if (number==1) {
                _activeShape = _forge.GetShape(BrickNames.SQUARE);
            }
            else if (number==2) {
                _activeShape = _forge.GetShape(BrickNames.LINE);
            }
            else if (number==3) {
                _activeShape = _forge.GetShape(BrickNames.HALFCROSS);
            }
            else if (number==4) {
                _activeShape = _forge.GetShape(BrickNames.TWOlINE);
            }
        }

        public DelegateCommand MoveDownCommand { get; set; }
        public DelegateCommand RightMoveCommand { get; set; }
        public DelegateCommand LeftMoveCommand { get; set; }
        public DelegateCommand UpRotateCommand { get; set; }

        private int _brickCounter = 0;
        private int _angle = 90;
        private CustomCanvas _canvas;
        private Forge _forge;
        private Grid _activeShape;
        private BackgroundWorker worker;
    }
}
