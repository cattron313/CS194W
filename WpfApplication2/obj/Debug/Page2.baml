   M S B A M L   `   `   `  ����  WpfApplication2    WpfApplication2.Page2   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          N�Name$
  Page��5       N� WindowTitle$
 Page��5      $��LeftToRight=�5      $	��640��5      $	��480��6    N� WindowWidth$	 640Q�5       N� WindowHeight$	 480Q�6    � 	Resources 5	         LoadSetting��%   &	        �� 5
      6   5       � Triggers 5      :� 5       :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      �� #��[  6   5      .��5      �� -   5        $��controls��5      $	��443��6   $	��604��6*   .+�5   
   �� -   5        $��buildAScene��5      $	��443��6$   $	��604��61   .+�5       � -   5        $��frame1��5   B    �� Left$ 12��6   
 �� Top$ 12��6%   $	��419��65   $	��578��6P   5      �� 5      -   5        $��
switchMode��5   K   $	 479��6   $	 300��6.   $��37��6?   
���   �$	��109��6l   ��5      �� 5      	 �� EndPoint$	 0.5,1&�6*   
 �� 
StartPoint$
 0.5,0&�6;   .��5      �  � Color$ 	#FF0D5969��6'    � Offset$ 0.975Q�69   � 5      $ 	#FFC7EBF2��6'   $ 0Q�69   5      5      �� 5      -   5        $��label5��5   j   $	 503��6   $	 300��6*   $��
1st Person��6;   $��16(�6P   $��35��6^   
�������6x   �� 5      -   5        $��toyBox��5   K   $	 479��6   $	 138��6.   $��37��6?   
���   �$	��109��6h   ��5      �� 5       $	 0.5,1&�6&   $
 0.5,0&�67   .��5!      � $ 	#FF0D5969��6#   $ 0.975Q�65   � 5"      $ 	#FFC7EBF2��6#   $ 0Q�65   5#      5%      �� 5&   
   -   5        $��label4��5&   _   $	 503��6   $	 140��6"   $��Toy Box��63   $��16(�6E   $��35��6S   
�������6m   �� 5'   
   -	   5        $��endScene��5'   B   $	 479��6   $ 37��6&   $��38��66   
���   �$	��109��6a   ��5(      �� 5)      $	 0.5,1&�6&   $
 0.5,0&�67   .��5*      � $ 	#FF0D5969��6#   $ 0.975Q�65   � 5+      $ 	#FFC7EBF2��6#   $ 0Q�65   5,      5.      �� 5/   
   -
   5        $��label3��5/   `   $	 493��6   $ 37��6"   $��	End Scene��62   $��16(�6F   $��28��6T   
�������6n   �� 50   
   -   5        $��pause��50   B   $ 12��6   $	 254��6%   $��37��66   
���   �$	��109��6^   ��51      �� 52      $	 0.5,1&�6&   $
 0.5,0&�67   .��53      � $ 	#FF0D5969��6#   $ 0.975Q�65   � 54      $ 	#FFC7EBF2��6#   $ 0Q�65   55      57      �� 58   
   -   5        $��label2��58   \   $ 39��6   $	 254��6!   $��Pause��62   $��16(�6B   $��28��6P   
�������6j   �� 59   
   -   5        $��record��59   B   $ 12��6   $	 137��6%   $��38��66   
���   �$	��109��6_   ��5:      �� 5;      $	 0.5,1&�6&   $
 0.5,0&�67   .��5<      � $ 	#FF0D5969��6#   $ 0.975Q�65   � 5=      $ 	#FFC7EBF2��6#   $ 0Q�65   5>      5@      �� 5A   
   -   5        $��label1��5A   O   $ 34��6   $	 137��6!   $��Record��62   $��28��6C   $��16(�6]   
�������6k   �� 5B   
   -   5        $
��mode��5B   T   $ 14��6   $ 14��6!   $��Third-Person��61   $��28��6H   $��97��6`   $��15(�6k   ���	#98FFE3416y   A� 5C   
   -   5        $��rightEllipse��5C   A   $	 269��6   $	 363��6$   $��35��65   
���   �$��35��6d   
����  � � DataContext 6{   �� A� 5D   
   -   5        $��leftEllipse��5D   M   $	 428��6   $	 363��6$   
����  �$��35��6A   
���   �$��35��6o   5E      5F      