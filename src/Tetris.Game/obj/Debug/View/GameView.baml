   M S B A M L   `   `   `  ����F  BTetris.Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Tetris.Game.ControlTetris.Game.Control  5      3clr-namespace:Tetris.Game.ViewTetris.Game.View  5          Tetris.Game.View.GameView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5control!clr-namespace:Tetris.Game.Control     5      0localclr-namespace:Tetris.Game.View     5        J� InputBindings  5      �� 5	   
   
 �� Key$
 Down��69    �� Command 6   �� *MoveDownCommand+69   �� 5
   
   $ Right��6:    6   �� *RightMoveCommand+6:   �� 5   
   $
 Left��69    6   �� *LeftMoveCommand+69   �� 5   
   $ Up��69    6   �� *UpRotateCommand+69   .��5      � .+�5   
   &    Tetris.Game.Control.CustomCanvas  -   5          Name$ _canvas��5   1   $��0,0,0,20q�6   }�. |�. 6V   5      5      