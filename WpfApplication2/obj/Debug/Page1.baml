   M S B A M L   `   `   `  ����  WpfApplication2    WpfApplication2.Page1   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          N�Name$
  Page��5       N� WindowTitle$
 Page��5      $��LeftToRight=�5      $	��640��5      $	��480��6    N� WindowWidth$	 640Q�5       N� WindowHeight$	 480Q�6    � 	Resources 5	         ShipwreckHover �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value  JungleHover  TempleHover��%)  &	        &	 �     &	 \    �� 5
      .��5      �� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6"   $ ShipB��6k   .g�5        $ 0��6   $ 	#FFFFE640��6&   5      5      �� 5      .��5      �� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6"   $ JungleB��6k   .g�5        $ 0��6   $ 	#FFFFE640��6&   5      5      �� 5      .��5      �� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6"   $ TempleB��6k   .g�5        $ 0��6   $ 	#FFFFE640��6&   5      5      5      	 � Triggers	 5      :� 5      
 :� RoutedEvent$
 Mouse.MouseEnter��6    :� 
SourceName$ ShipB��60   .[�5      �� -   5         ��Name$$ ShipwreckHover_BeginStoryboard��5      #��[  6=   5      :� 5      $
 Mouse.MouseLeave��6   $ ShipB��60   .[�5      ��  �� BeginStoryboardName$$ ShipwreckHover_BeginStoryboard��6   5       :� 5!      $
 Mouse.MouseEnter��6   $ JungleB��60   .[�5"      �� -   5        $! JungleHover_BeginStoryboard��5"      #��[ 6:   5#      :� 5$      $
 Mouse.MouseLeave��6   $ JungleB��60   .[�5%      �� $! JungleHover_BeginStoryboard��6   5&      :� 5'      $
 Mouse.MouseEnter��6   $ TempleB��60   .[�5(      �� -   5        $! TempleHover_BeginStoryboard��5(      #��[ 6:   5)      :� 5*      $
 Mouse.MouseLeave��6   $ TempleB��60   .[�5+      �� $! TempleHover_BeginStoryboard��6   5,      .��5/      �� -   5        $��
MainCanvas��5/      $	��480��6   $	��640��6,   .+�50   
   �� $��93��6   $��
95,20,95,0q�6    $
��Wrap=�64   $	��Top=�6H   $��64(�6`    �� TextAlignment$ Center=�6n   $	��390��6�    �� Left$ 29��6�   
 �� Top$	 -29��6�   �� 6�   $�Pick A Setting��6�   �� 6�   6�   �� 51   
   -   5         ��Name$ JungleB��51      
���   �$��5q�66   $��122.5��6J   $	 423��6Y   $	 119��6k   $��183.327��6|   ._�52      �� -   5         ��Name$ Jungle��52      $��0,0,-0.094,-0.25q�6$   $��Jungle[1].jpg��6>   $
��Fill=�6U   6d   53      �� 54   
   -   5        $ ShipB��54      
���   �$��5q�64   $
��Left=�6H   $	��160��6c   $ 45��6o   $	 119��6�   ._�55      �� -	   5        $ 	Shipwreck��55      $��0,0,0.049,-0.052q�6'   $��Wreck on amangasette.jpg��6A   $
��Fill=�6c   6r   56      �� 57   
   -
   5        $ TempleB��57      
���   �$��5q�66   $��Right=�6J   $	��160��6f   $	 238��6r   $	 119��6�   ._�58      �� -   5        $ Temple��58      $3��-/WpfApplication2;component/B%20temple%201.jpg��6$   $
��Fill=�6[   6j   59      A� 5:   
   -   5        $��rightEllipse��5:   A   $	 269��6   $	 363��6$   $��35��65   
���   �$��35��6d   
����  � � DataContext 6{   �� A� 5;   
   -   5        $��leftEllipse��5;   M   $	 428��6   $	 363��6$   
����  �$��35��6A   
���   �$��35��6o   5<      5=      