   M S B A M L   `   `   `  ����  WpfApplication2    WpfApplication2.Page1   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6I   c _Microsoft.Expression.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  6�   -   5          N�Name$
  Page��5       N� WindowTitle$
 Page��5      $��LeftToRight=�5      $
��1366��5      $	��768��6    N� WindowWidth$
 1366Q�5       N� WindowHeight$	 768Q�6    N� 
Background 5      �� 5	   
    �� ImageSource$b \c:\users\tajah\documents\visual studio 2010\Projects\WpfApplication2\WpfApplication2\bg3.jpg��6   5
       � 	Resources 5         ShipwreckHover  JungleHover  TempleHover��%W   &	        &	      &	 &     �� 5      6   �� 5      6   �� 5      6   5      .��5      �� -   5         ��Name$ 
MainCanvas��5      $	��480��6!   $	��640��6.   .+�5   
   �� $��93��6   $
��Wrap=�6    $	��Top=�64   $��64(�6L    �� TextAlignment$ Center=�6Z   $	��450��6q   	 �� Left$	 105.564��6}   

 �� Top$
 -114.922��6�   $
��Bold"�6�   
����������	#FFEF5938�� 6�   $�Pick A Setting��6�   �� 6  6  �� 5   
   -   5         ��Name$ Jungle1��5      $��Jungle[1].jpg��6!   $
��Fill=�68   $��247.286��6_   $		 581��6p   $
 44.542��6�   $��391.945��6�    J� OpacityMask
 �   � J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5   
   -   5        $ 
Shipwreck1��5      $��Wreck on amangasette.jpg��6$   $
��Fill=�6F   $��247.926��6m   $
	 -327��6~   $
 44.792��6�   $��391.802��6�    5        5      5      �� 5   
   -   5        $ Temple2��5      $3��-/WpfApplication2;component/B%20temple%201.jpg��6!   $
��Fill=�6X   $��247.036��6   $	 105.564��6�   $
 44.792��6�   $��391.851��6�    5        5       5"      �� 5#      $��108.834��6   $
 95��6#   $��71.309��63   $��2��6B   $
	 -425��6V   �� 5$   
   $��108.834��6   $		 997��6%   $
 95��67   $��71.309��6G   �� 5%      -   5         ��Name$ 	Shipwreck��5%      $��248.176��6%   $
	 -327��66   $
 44.542��6I   $��391.802��6]   �� 5&   
   -   5        $ Temple��5&      $��248.176��6$   $	 105.564��65   $
 44.542��6K   $��391.851��6_   �� 5'   
   -   5        $ Jungle��5'      $��248.176��6$   $		 581��65   $
 44.542��6G   $��391.945��6[   A� 5(   
   -	   5         A�Name$ rightEllipse��5(   E   $		 170��6   $
 738.691��6$   $��35��69   
���   �$��35��6j   
����  � � DataContext 6�   �� A� 5)   
   -
   5        $ leftEllipse��5)   U   $	 770.325��6   $
 738.691��6(   
����  �$��35��6I   
���   �$��35��6y   5+      5,      