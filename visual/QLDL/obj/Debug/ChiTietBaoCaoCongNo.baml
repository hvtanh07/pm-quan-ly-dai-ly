   M S B A M L   `   `   `  ����?  ;QLDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLDLQLDL  5   	       QLDL.ChiTietBaoCaoCongNo   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:QLDL     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        
�������  � 
ResizeMode$  NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�6    � WindowStyle$
 None=�6D   
���   �$	��600��5      $	��600��6)   .��5      � .+�5   
   �� -   5        $��Right=�5      $��Center=�6.   $��Center=�6R   $��76��6t   $
��Auto��6   $��16(�6�   ���	#FF2196F3$��0q�6�   #��[" �6�   $��	0,0,0,529q�61  ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ExitToApp=�6&   $��25��67   $��30��6C   5      5      �� 5   
   $��	0,2,0,462q�6   �� 5   
    �� TextAlignment$ Center=�6   $	��Top=�6+   $��Center=�6C   $��
55,10,60,0q�6`   
���   �$��30(�6�   $	��485��6�   $%��Chi tiết báo cáo công nợ��6�   � 5   
   $��
0,71,0,349q�6   .+�5      �� $��18(�6   
���   �$��-16,53,334,8q�69   $ Right=�6O   #!Mã phiếu báo cáo công nợ:6�   �� 5      $��18(�6   
���   �$��-16,89,334,-28q�69   $ Right=�6Q   	Tháng:6p   �� 5      -   5         ��Name$ Matxt��5      $��18(�6'   
���   �$��271,53,47,8q�6H   $
 Left=�6]   6t   �� 5      -   5        $ thang��5      $��18(�6'   
���   �$��271,89,47,-28q�6H   $
 Left=�6_   6w   �� 5      -   5         ��Name$ ButtonXacNhan��5      $
��Auto��6,   $��24(�6:   $��413,53,47,64q�6H   .��6z   Xác nhận6�   5      � 5   
   $��	0,256,0,0q�6   .+�5      �� $��Danh sách đại lý��6   63   � 5      $��0,37,0,0q�6   .+�5      �� 
���   �$��16(�60   $	��Top=�6>   $��42,18,-42,0q�6V   Nhập thông tin đại lý:6�   �� 5      -   5         ��Name$ 
txtKeyword��5      
���   �$��16(�6B   $	��Top=�6P   $��205,14,177,0q�6h   $��29��6�   �� 5      -   5        $ button1��5      $��Right=�6*   $��Center=�6G   $	��Top=�6k   $��65��6�   $
��Auto��6�   $��16(�6�   $��0q�6�   #��[" �6�   $��0,0,112,259q�6   J� RenderTransformOrigin$ 0.5,0.5&�6A  ��6�   Z� .��5         $ AccountSearch=�6.   $��25��6C   $��30��6O   5!      5"      �� 5#      -   5        	 ��Name$
	 dsDL��5#      
���   �
���   �$��0,48,0,0q�6Q   $	��600��6c   $��Right=�6o   $��Normal"�6�   $��12(�6�   
 �� View
 5$      �� 5%      .P�5&      �� $��Mã đại lý��6-    �� Width$	 150��6@    �� DisplayMemberBinding 6L   �� *madl+5'      �� 5(      $��Nợ đầu kỳ��6-   $	 150��6@    6L   �� *nodau+�� 5)      $��Nợ cuối kì��6-   $	 150��6A    6M   �� *nocuoi+�� 5*      $��
Phát sinh��6-   $	 150��6@    6L   �� *
phatsinh+5+      5-      5.      50      51      52      