   M S B A M L   `   `   `  ����?  ;QLDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLDLQLDL  5   	       QLDL.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:QLDL     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��600��5      $
��1000��6'   
�������  � 
ResizeMode$  NoResize=�6G    � WindowStartupLocation$ CenterScreen=�6]    � WindowStyle$
 None=�6�    � 	Resources 5	         OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu��%�  &	        &	 �     �� 5
   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $ 70Q�63     5      $ 0:0:0.5��6'   $	 200Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $	 200Q�63     5      $ 0:0:0.5��6'   $ 70Q�69   5      5      5       � Triggers 5      :� 5   
   	 :� RoutedEvent$	 ButtonBase.Click��6   
 :� 
SourceName$
 ButtonOpenMenu��66   .[�5      �� #��[  6   5      :� 5   
   $	 ButtonBase.Click��6   $
 ButtonCloseMenu��66   .[�5      �� #��[ 6   5      .��5      � ���	#FFDEDEDE.+�5    
   >� -   5         >�Name$	 usc��5       $	��930��6#   $	��540��6/   $��Bottom=�6<   $��Right=�6W   � 5!   
   -   5         �Name$ GridMain��5!      $��Right=�6!   $��Bottom=�6=   $	��540��6X   $
��1010��6e   � 5"   
   $��60��6   $	��Top=�6   ���	#FF5C99D6 J� Effect 5#      3  -System.Windows.Media.Effects.DropShadowEffect  5$         
BlurRadius$ 1Q�6#      ShadowDepth$ 1Q�62      Color$ 	#FFACACAC��6B   .+�5&      �� -   5        $��Right=�5&      $��Center=�62   $��Center=�6V   $��65��6x   $
��Auto��6�   $��16(�6�   
�������$��0q�6�   #��[" �6�   ��6�   Z� .��5'      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ExitToApp=�6*   $��25��6;   $��30��6G   5(      5)      �� 5*      $��Center=�6   $��Center=�65   $��22(�6P   Quản Lý Đại Lý6n   5+      � 5,   
   -   5        $ GridMenu��5,      $��70��6!   $
��Left=�6,   ���	#FF31577E 5-        5.      $ 2Q�6#   $ 1Q�62   $ 	#FFAEAEAE��6B   .+�50      �� .+�51      � $	��150��6   
������� J� RenderTransformOrigin$ 0.5,0.5&�67   z�52      V� 53      .~�54      �� �� 55      �� 56      T� 57      58      .+�5:      �� -   5         ��Name$ ButtonOpenMenu��5:      $��60��65   $��60��6A   $��5q�6L   $��Right=�6W   $	��Top=�6s    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6�   ���	#FF31577E��6�   Z� ��6�   Z� .��5;        $
 Menu=�62   $��25��6>   $��25��6I   5<      �� 5=      -   5        $ ButtonCloseMenu��5=      $y�	Collapsed=�66   $��60��6M   $��60��6Y   $��5q�6d   $��Right=�6o   $	��Top=�6�   #��[ 6�   ���	#FF31577E��6�   Z� ��6�   Z� .��5>        $ 	ArrowLeft=�62   $��25��6C   $��25��6N   5?      �� 5A      $��80��6   $��Bottom=�6(   5B      �� 5C      -   5         ��Name$ ListViewMenu��5C      ���	#FF5C99D6$��Disabled=�6H   .@�5D      �� -   5         ��Name$ BranchManagement��5D   #   $��60��6=   .��5E      ��  �� Orientation$ 
Horizontal=�6%   .+�5F        $ Store=�66   $��25��6C   $��25��6O   $��10q�6Z   �� 5G      $��Quản lý đại lý��6(   $��Center=�6>   $��20 10q�6Y   5H      5I      �� 5J      -	   5        $ ItemManagement��5J   #   $��60��6;   .��5K      �� $ 
Horizontal=�6%   .+�5L        $ Dropbox=�66   $��25��6E   $��25��6Q   $��10q�6\   �� 5M      $��Quản lý mặt hàng��6(   $��Center=�6@   $��20 10q�6[   5N      5O      �� 5P      -
   5        $ MonthlyReport��5P   #   $��60��6:   .��5Q      �� $ 
Horizontal=�6%   .+�5R        $	 Pen=�66   $��25��6A   $��25��6M   $��10q�6X   �� 5S      $��Lập báo cáo tháng��6(   $��Center=�6A   $��20 10q�6]   5T      5U      �� 5V      -   5        $ 
RuleChange��5V   #   $��60��67   .��5W      �� $ 
Horizontal=�6%   .+�5X        $ Screwdriver=�66   $��25��6I   $��25��6U   $��10q�6`   �� 5Y      $��Thay đổi quy định��6(   $��Center=�6A   $��20 10q�6]   5Z      5[      5\      5]      5_      5a      5b      