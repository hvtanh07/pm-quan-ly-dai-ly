   M S B A M L   `   `   `  ����?  ;QLDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLDLQLDL  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       QLDL.PhieuXuatHang   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:QLDL     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   -   5        
�������  � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�6    � WindowStyle$
 None=�6D   
���   � � Title$ Lập phiếu thu tiền��5   	   $	��800��6$   $	��700��61   .��5      � .+�5   
   � $��0,0,0,10q�6   .+�5      � 
�������$��Center=�6&   $	��Top=�6C   $	��300��6[   $	��700��6h   .+�5      �� -   5        $��Right=�5      $��Center=�66   $��Center=�6Z   $��65��6|   $
��Auto��6�   $��16(�6�   ���	#FF2196F3$��0q�6�   #��[" �6�   $��	0,0,0,240q�69  ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ExitToApp=�6.   $��25��6?   $��30��6K   5      5      �� 5       J� RenderTransformOrigin$ 
0.51,0.375&�6   $��	0,2,0,171q�6?   �� 5       �� TextAlignment$ Center=�6   $	��Top=�63   $��Center=�6K   $��140,10,145,0q�6h   
���   �$��30(�6�   $	��415��6�   $%��Chi tiết phiếu xuất hàng��6�   �� 5      $��50,90,0,-40q�6   
���   �$��20(�6D   Mã phiếu thu:6a   �� 5      $��52,134,-2,-34q�6   
���   �$��20(�6F   $��Mã đại lý:��6T   �� 5      $��369,90,31,110q�6   
���   �$��20(�6F   $��Tháng:��6T   �� 5      -   5         ��Name$ maPhieu��5      $ Right=�6-   
���   �$��20(�6V   $��147,90,0,176q�6d   $
��Left=�6z   $��99��6�   6�   �� 5      -   5        $ madltxt��5      $ Right=�6.   $��113,131,454,135q�6D   
���   �$��20(�6p   $��34��6~   6�   �� 5      -   5        $ thang��5      $
 Left=�6+   $��437,90,105,179q�6@   
���   �$��20(�6k   6{   �� 5      $
 Left=�6   $��369,134,173,135q�61   
���   �$��20(�6]   Tổng giá trị phiếu:6�   �� 5      -   5        $ tongtientxt��5      $
 Left=�61   $��532,134,10,135q�6F   
���   �$��20(�6q   6�   �� 5      -   5        $��266,181,266,61q�5      $
��Auto��61   $��20(�6?   .��6_   Lưu phiếu6j   5       5!      � 5"   
   $��0,262,0,368q�6   .+�5#      �� $1��+Quản lý mặt hàng trong phiếu xuất��6   6D   �� 5$      $��
40,50,10,0q�6   
���   �$��20(�6?   Mã mặt hàng:6[   �� 5%      $��40,98,10,-48q�6   
���   �$��20(�6A   Số lượng:6Z   �� 5&      -   5         ��Name$ mamhtxt��5&      
���   �$��Right=�6;   $��176,50,362,92q�6^   6w   �� 5'      -	   5        	 ��Name$	 soluong��5'      
���   �
 �� TextAlignment$
 Right=�6:   $��176,98,362,44q�6P   6�   �� 5(      -
   5         ��Name$ 
ButtonThem��5(      $��376,82,215,44q�6)   $
��Auto��6@   .��6g   Thêm6m   �� 5)      -   5        $ 	ButtonSua��5)      $��533,82,58,44q�6(   $
��Auto��6>   $��Sửa��6L   6Z   5*      � 5+   
   $��	0,432,0,0q�6   .+�5,      �� $6��0Danh sách các mặt hàng trong phiếu xuất��6   6J   �� 5-      
���   �$��16(�6,   $	��Top=�6:   $��	50 50 0 0q�6R    Nhập thông tin mặt hàng:6   �� 5.      -   5        $	 
txtKeyword��5.      
���   �$��16(�6=   $	��Top=�6K   $��243,46,190,0q�6c   $��29��6�   �� 5/      -   5        $ button1��5/      $��Right=�6&   $��Center=�6C   $	��Top=�6g   $��65��6�   $
��Auto��6�   $��16(�6�   $��0q�6�   #��[" �6�   $��0,38,135,221q�6  ��6�   Z� .��50        $ AccountSearch=�6*   $��25��6?   $��30��6K   51      52      �� 53      -   5         ��Name$ 
danhsachmh��53      
���   �
���   �$��0,85,0,0q�6S   $	��700��6e   $��Right=�6q   $��Normal"�6�   $��12(�6�    �� View 54      �� 55      .P�56      �� $��Mã mặt hàng��6)    �� Width$	 150��6>    �� DisplayMemberBinding 6J   �� *mamh+57      �� 58      $��số lượng��6)   $	 100��6;    6G   �� *	soluong+�� 59      $&�� Tổng giá trị lượng hàng��6)   $	 180��6J    6V   �� *
tongtien+5:       � ContextMenu 5<      �� 5=      .@�5>      m� -   5        $
��Xóa��5>   #   60   5?      5A      5B      5C      5D      