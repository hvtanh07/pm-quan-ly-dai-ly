   M S B A M L   `   `   `  ����?  ;QLDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLDLQLDL  5          QLDL.QuanLyMatHang   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:QLDL     5      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        
�������$	��930��5
      $	��540��6   $	��930��5      $	��930��6   $	��540��5      $	��540��6   $��Bottom=�5      $��Right=�6)   .��5      � .+�5   
   �� $��	0,0,0,400q�6   �� 5   
     �� TextAlignment$  Center=�6   $	��Top=�6+   $��Center=�6C   $��227,11,288,0q�6`   
���   �$��30(�6�   $	��415��6�   $��51��6�   $��Quản lý mặt hàng��6�   �� 5   
   -   5         ��Name$ LapPhieuXuatHangButton��5      $ ��Lập phiếu xuất hàng��62   $��Center=�6P   $��20(�6k   
������ 
���   �$��696,10,10,479q�6�   $��51��6�   
�������6�   � 5   
   $��
0,20,0,260q�6   .+�5      �� 
���   �$��20(�6+   $��50,80,-50,-80q�69   Mã mặt hàng:6^   �� 5      
���   �$��20(�6+   $��50,130,-50,-80q�69   Tên mặt hàng:6`   �� 5      
���   �$��20(�6+   $��50,180,-50,-80q�69   Đơn vị tính:6_   �� 5      
���   �$��20(�6+   $��500, 80,-50,-80q�69   Hạn sử dụng:6`   �� 5      
���   �$��20(�6+   $��500,130,-50,-80q�69   Giá:6X   �� 5      -   5         ��Name$
 mamh��5       �� TextAlignment$ Right=�6$   
���   �$��20(�6M   $��176,71,554,147q�6[   6u   �� 5      -   5        $	 tmh��5      $ Right=�6#   
���   �$��20(�6L   $��176,113,554,105q�6Z   6u   �� 5      -   5        $	 gia��5      $ Right=�6#   
���   �$��20(�6L   $��622,113,84,105q�6Z   6�   (  "System.Windows.Controls.DatePicker  5      -   5          Name$	 hsd��5      $��20(�6&   $��Right=�64   
���   �$��622,80,84,147q�6j      SelectedDateFormat$ Short=�6�      FirstDayOfWeek$ Monday=�6�   6�   �� 5      -   5         ��Name$	 dvt��5      $��Right=�6$   
���   �$��18(�6Z   $��32��6h   $��176,180,554,48q�6t   6�   �� 5      -   5        $ 
ButtonThem��5      $��474,180,347,37q�6)   $
��Auto��6A   .��6h   Thêm6n   �� 5      -	   5        $ 	ButtonSua��5      $��766,180,55,37q�6(   $
��Auto��6?   .��6e   Sửa6j   �� 5      -
   5        $ 	ButtonXoa��5      $��622,180,199,37q�6(   $
��Auto��6@   .��6f   Xóa6k   5       � 5!   
   $��0,253,0,212q�6   .+�5"      �� $��0,0,0,73q�6    J� RenderTransformOrigin$ 0.5,0.5&�6*   z�5#      V� 5$      .~�5%      �� 	 �� ScaleY$	 -1Q�6)   �� 5&      �� 5'      T� 5(      5)      5+      �� 5,      
���   �$��16(�6,   $��Center=�6:   $��50 0 0 0q�6U    Nhập thông tin mặt hàng:6�   �� 5-      -   5        $ 
txtKeyword��5-      
���   �$��16(�6=   $��Center=�6K   $��240,22,200,23q�6f   6}   �� 5.      -   5        $ button1��5.      $��Right=�6&   $��Center=�6C   $��Center=�6g   $��65��6�   $
��Auto��6�   $��16(�6�   $��0q�6�   #��[" �6�   $��	0,0,135,0q�6  ��6�   Z� .��5/      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]
   Kind$
 AccountSearch=�6*   $��25��6?   $��30��6K   50      51      52      �� 53   
   -   5         ��Name$ 	dsmathang��53      $��	0,320,0,0q�6&    �� View 54      �� 55      .P�56      �� $��Mã mặt hàng��6%    �� Width$	 200��6:    �� DisplayMemberBinding 6F   �� *mamh+57      �� 58      $��Tên mặt hàng��6%   $	 200��6;    6G   �� *tenmh+�� 59      $��Hạn sử dụng��6%   $	 180��6:    6F   �� *	hansudung+�� 5:      $
��Giá��6%   $	 180��62    6>   �� *gia+�� 5;      $��Đơn vị tính��6%   $
 Auto��6:    6G   �� *	donvitinh+5<       � ContextMenu 5>      �� 5?      .@�5@      m� -   5        $��Sửa mặt hàng��5@      65   m� 5A      -   5        $��Xóa mặt hàng��5A      65   5B      5D      5E      5F      