   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	       WpfApplication1.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Login��5	   	   $	��500��6   $	��350��6$    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   $��Segoe UI Emoji)�5   	   .��5      � .+�5   
   �� $	��500��6   $	��Top=�6!   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF22D1A9��6#   � 5      $ 	#FF0D0638��6#    � Offset$ 0.976Q�65   � 5      $ 	#FF173C5B��6#   $
 0.61Q�65   � 5      $ 	#FF142059��6#   $ 0.831Q�65   � 5      $ 	#FF1D8BA4��6#   $ 0.353Q�65   � 5      $ 	#FF0E0C47��6#   $ 0.924Q�65   � 5      $ 	#FF184878��6#   $ 0.474Q�65   � 5      $ 	#FF20B7A7��6#   $ 0.185Q�65   � 5      $ 	#FF18A0A6��6#   $ 0.257Q�65   � 5      $ 	#FF21BEC5��6#   $
 0.08Q�65   5      5      �� 5   
   $	��280��6   $	��211��6    $��Bottom=�6-   $��35,0,35,135q�6H    �� RadiusY$ 10��6]    �� RadiusX$ 10��6j   
�������	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5       
   
BlurRadius$
 15Q�6#      	Direction$ 0Q�63      RenderingBias$ Quality=�6A      ShadowDepth$ 1Q�6Y      Color$ 	#FFBBBBBB��6i   5"      � 5#   
   .+�5$      �� $��120,25,98,367q�6   .+�5%      �� $$��/Assets/shopping_cart_full.png��6   $��76��6@   $��0,0,10,0q�6L   5&      5'      � 5(   
   $��Bottom=�6   $��35,80q�6*   $	��240��69   .+�5*      �� $��LOGIN��6   $��Center=�6$   $	��Top=�6A   $��108,-24,72,0q�6Y   
�������$��18(�6�   $��94��6�   �� 5+      -   5         ��Name$ TxtEmail��5+      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ EMAIL��6(    %  !MaterialDesignFloatingHintTextBox#��[  6O   $��Champagne & Limousines)�6�   $��12(�6�   $��45,28,42,176q�6�   G� 5,      -   5         G�Name$ TxtPassword��5,      $ PASSWORD��6/    ) %MaterialDesignFloatingHintPasswordBox#��[ 6Y   $��Champagne & Limousines)�6�   $��12(�6�   $��45,87,42,115q�6�   �� 5-      -   5         ��Name$ btnLogin��5-   -   $��Login��6?   $
��Left=�6O   $	��Top=�6j   $��75��6�   $��107,176,0,0q�6�   �� 5.      -   5        $ btnForgotPass��5.   1   $��Forgot Password��6H   $
��Left=�6b   $	��Top=�6}   $��94��6�   $��102,214,0,0q�6�   ���	#FF9E9EBD��5/      �� 50       �� 
TargetType" ��6&   .R�51      �� $��	Underline{�6$   �� 52      53      54      ��56      �� 57       �� 
TargetType" ��6   .�58      ��  �� Property � �� �� Value
 ��  �67    �� Triggers 59      P� 5:       P� Property �@J�IsMouseOver P� Value . . �5;   "   ��  � ��
 �  ��6?   5<      5>      5@      �� 5B      -   5        $ btnRegister��5B   /   $+��%Don't have account yet? Register here��6D   $
��Left=�6t   $	��Top=�6�   $	��207��6�   $��47,255,0,-31q�6�   ��5C      �� 5D      " ��6&   .R�5E      �� $��	Underline{�6$   ���	#FFBDBDDC�� 5F      5G      5H      ��5J      �� 5K      " ��6   .�5L      ��  � ��
 ��  �67    5M      P� 5N       �@J�IsMouseOver . . �5O   "   ��  � ��
 �  ��6?   5P      5R      5T      5U      5V      5W      