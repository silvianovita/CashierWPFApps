   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	       WpfApplication1.Register   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Login��5   	   $	��500��6   $	��350��6$    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   $��Segoe UI Emoji)�5   	   .��5      � .+�5   
   �� $	��500��6   $	��Top=�6!   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF26EABD��6#    � Offset$ 0.016Q�65   � 5      $ 	#FF38268A��6#   $ 1Q�65   � 5      $ 	#FF288B62��6#   $ 0.546Q�65   � 5      $ 	#FF1ED3AA��6#   $ 0.064Q�65   � 5      $ 	#FF20C2AC��6#   $ 0.169Q�65   � 5      $ 	#FE21B687��6#   $ 0.253Q�65   � 5      $ 	#FE23A386��6#   $ 0.378Q�65   � 5      $ 	#FE259873��6#   $
 0.45Q�65   � 5      $ 	#FF298165��6#   $
 0.59Q�65   � 5      $ 	#FF2C5A70��6#   $ 0.715Q�65   � 5      $ 	#FF2D4475��6#   $ 0.775Q�65   � 5      $ 	#FF2F3D7B��6#   $ 0.843Q�65   � 5      $ 	#FF303E7F��6#   $ 0.888Q�65   � 5      $ 	#FF313181��6#   $ 0.916Q�65   � 5      $ 	#FF2C4084��6#   $ 0.952Q�65   5       5"      �� 5$   
   $	��280��6   $	��247��6    $��Bottom=�6-   $��
29,0,35,80q�6H    �� RadiusY$ 10��6\    �� RadiusX$ 10��6i   
�������	 J� Effect	 5%      3  -System.Windows.Media.Effects.DropShadowEffect  5&      
   
BlurRadius$
 15Q�6#      	Direction$ 0Q�63      RenderingBias$ Quality=�6A      ShadowDepth$ 1Q�6Y      Color$ 	#FFBBBBBB��6i   5(      � 5)   
   $��Bottom=�6   $��
35,0,35,80q�6*   $	��247��6>    � ColumnDefinitions 5*      �� 5+      $
��181* �6#   �� 5,      $��7* �6#   �� 5-      $	��86* �6#   .+�5/      �� $��REGISTER��6   $��Center=�6'   $	��Top=�6D   $��
84,22,79,0q�6\   
�������$��18(�6�   $��3��6�   $	��111��6�   �� 50      $��Center=�6   $��15,61q�64   $��3��6C   .+�51      �� -   5         ��Name$ TxtName��51      $
��0,10q�6,   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 NAME��6:    %  !MaterialDesignFloatingHintTextBox#��[  6`   $��Champagne & Limousines)�6�   $��18(�6�   �� 52      -   5        $ TxtEmail��52      $
��0,10q�6,   $ EMAIL��6:   #��[  6a   $��Champagne & Limousines)�6�   $��18(�6�   53      54      �� 55   
   -   5         ��Name$ btnRegister��55      $	��150��6@   $��Center=�6L   $��Bottom=�6i   $��
95,0,99,69q�6�   $��REGISTER��6�   57      58      