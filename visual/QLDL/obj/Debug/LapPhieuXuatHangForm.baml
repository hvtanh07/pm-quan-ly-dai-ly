   M S B A M L   `   `   `  ����?  ;QLDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLDLQLDL  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       QLDL.LapPhieuXuatHangForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:QLDL     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   -   5        
�������  � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�6    � WindowStyle$
 None=�6D   
���   � � Title$ Lập phiếu thu tiền��5   	   $	��600��6$   $	��700��61   .��5      � .+�5   
   � $��	0,0,0,320q�6   .+�5      � 
�������$��Center=�6&   $	��Top=�6C   $	��300��6[   $	��700��6h   .+�5      �� -   5        $��Right=�5      $��Center=�66   $��Center=�6Z   $��65��6|   $
��Auto��6�   $��16(�6�   ���	#FF2196F3$��0q�6�   #��[" �6�   $��	0,0,0,240q�69  ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ExitToApp=�6.   $��25��6?   $��30��6K   5      5      �� 5       J� RenderTransformOrigin$ 
0.51,0.375&�6   $��	0,2,0,171q�6?   �� 5       �� TextAlignment$ Center=�6   $	��Top=�63   $��Center=�6K   $��140,10,145,0q�6h   
���   �$��30(�6�   $	��415��6�   $ ��Lập phiếu xuất hàng��6�   �� 5      $��50,90,0,-40q�6   
���   �$��20(�6D   Mã phiếu thu:6a   �� 5      $��408,90,-358,10q�6   
���   �$��20(�6G   $��Mã đại lý��6U   �� 5      $��50,159,350,41q�6   
���   �$��20(�6F   $��Tháng:��6T   �� 5      -   5         ��Name$ maPhieu��5       �� TextAlignment$ Right=�6+   
���   �$��20(�6T   $��180,90,0,176q�6b   $
��Left=�6x   $	��162��6�   6�   �� 5      -   5        	 ��Name$	 madltxt��5      $��Right=�6-   $��518,90,22,176q�6P   
���   �$��20(�6z   $��34��6�   6�   �� 5      -   5        
 ��Name$
 thang��5      $
 Left=�6+   $��140,159,402,110q�6@   
���   �$��20(�6l   6|   �� 5      -   5        $��266,216,266,26q�5      $
��Auto��61   $��20(�6?   .��6`   Lập phiếu6k   5      � 5      $��0,282,0,-320q�6   .+�5       �� $"��Danh sách phiếu xuat hang��6   6@   �� 5!      
���   �$��16(�60   $	��Top=�6>   $��	50 50 0 0q�6V   	Search:6r   �� 5"      -   5        $ 
txtKeyword��5"      
���   �$��16(�6A   $	��Top=�6O   $��150,50,200,0q�6g   6}   �� 5#      -   5         ��Name$ button1��5#      $��Right=�6*   $��Center=�6G   $	��Top=�6k   $��65��6�   $
��Auto��6�   $��16(�6�   $��0q�6�   #��[" �6�   $��0,38,135,221q�6  ��6�   Z� .��5$        $ AccountSearch=�6.   $��25��6C   $��30��6O   5%      5&      �� 5'      -	   5         ��Name$ 	dsphieuxh��5'      
���   �
���   �$��0,85,0,0q�6V   $	��700��6h   $��Right=�6t   $��Normal"�6�   $��12(�6�    �� View 5(      �� 5)      .P�5*      �� $��Mã phiếu xuất hàng��6-    �� Width$	 150��6I    �� DisplayMemberBinding 6U   �� *maxh+5+      �� 5,      $��Mã đại lý��6-   $	 100��6@    6L   �� *madl+�� 5-      $��Ngày lập phiếu��6-   $	 180��6E    6Q   �� *	ngaylap+�� 5.      $��Tổng giá trị��6-   $	 180��6C    6O   �� *
tongtien+5/       � ContextMenu 51      �� 52      .@�53      m� -
   5        $��Sửa bản ghi��53   '   6<   m� 54      -   5        $��Xóa bản ghi��54   '   6<   55      57      58      59      5:      5;      