   M S B A M L   `   `   `  ����?  ;QLDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLDLQLDL  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       QLDL.LapPhieuThuTienForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:QLDL     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   -   5        
�������  � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�6    � WindowStyle$
 None=�6D   
���   � � Title$ Lập phiếu thu tiền��5   	   $	��600��6$   $	��700��61   .��5      � .+�5   
   � $��	0,0,0,320q�6   .+�5      � 
�������$��Center=�6&   $	��Top=�6C   $	��300��6[   $	��700��6h   .+�5      �� -   5        $��Right=�5      $��Center=�66   $��Center=�6Z   $��65��6|   $
��Auto��6�   $��16(�6�   ���	#FF2196F3$��0q�6�   #��[" �6�   $��	0,0,0,240q�69  ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ExitToApp=�6.   $��25��6?   $��30��6K   5      5      �� 5       J� RenderTransformOrigin$ 
0.51,0.375&�6   $��	0,2,0,171q�6?   �� 5       �� TextAlignment$ Center=�6   $	��Top=�63   $��Center=�6K   $��140,10,145,0q�6h   
���   �$��30(�6�   $	��415��6�   Lập phiếu thu tiền6�   �� 5      $��50,90,0,-40q�6   
���   �$��20(�6D   Mã phiếu thu:6a   �� 5      $��408,90,-358,10q�6   
���   �$��20(�6G   Tên đại lý:6b   �� 5      $��50,150,358,119q�6   
���   �$��20(�6G   Ngày thu tiền:6e   �� 5      $��408,150,-8,50q�6   
���   �$��20(�6F   Số tiền thu6a   �� 5      -   5         ��Name$ maptt��5       �� TextAlignment$ Right=�6)   
���   �$��20(�6R   $��180,90,0,176q�6`   $
��Left=�6v   $	��162��6�   6�   �� 5      -   5        	 ��Name$	 madltxt��5      $��Right=�6-   $��518,90,22,176q�6P   
���   �$��20(�6z   $��34��6�   6�   �� 5      -   5        $ tienthu��5      $ Right=�6+   $��520,150,22,119q�6A   
���   �$��20(�6l   6�   (  "System.Windows.Controls.DatePicker  5      -   5        
  Name$
 Ngaythu��5      $��Right=�6.   $��18(�6Q   $��180,150,358,119q�6_   6z   �� 5      -   5        $��266,216,266,26q�5      $
��Auto��61   $��20(�6?   .��6`   Hoàn Tất6j   5       � 5!      $��0,282,0,-320q�6   .+�5"      �� $#��Danh sách phiếu thu tiền��6   6?   �� 5#      
���   �$��16(�60   $	��Top=�6>   $��	50 50 0 0q�6V   	Search:6r   �� 5$      -   5        $ 
txtKeyword��5$      
���   �$��16(�6A   $	��Top=�6O   $��150,50,200,0q�6g   6}   �� 5%      -	   5         ��Name$ button1��5%      $��Right=�6*   $��Center=�6G   $	��Top=�6k   $��65��6�   $
��Auto��6�   $��16(�6�   $��0q�6�   #��[" �6�   $��0,38,135,221q�6  ��6�   Z� .��5&        $ AccountSearch=�6.   $��25��6C   $��30��6O   5'      5(      �� 5)      -
   5         ��Name$ 
Dsphieuthu��5)      
���   �
���   �$��0,85,0,0q�6W   $	��700��6i   $��Right=�6u   $��Normal"�6�   $��12(�6�    �� View 5*      �� 5+      .P�5,      �� $��Mã phiếu thu��6-    �� Width$	 150��6C    �� DisplayMemberBinding 6O   �� *	mathutien+5-      �� 5.      $��Mã đại lý��6-   $	 100��6@    6L   �� *madl+�� 5/      $��Địa chỉ��6-   $ 80��6>    6I   �� *diachi+�� 50      $��Email��6-   $	 100��6<    �� CellTemplate 51   "   �� 52   &   .R�53   *   �� $��	Underline{�6K   
����  � � Cursor$
 Hand��6y   ��64   �� *email+6y   54   '   56      �� 57      $��Điện Thoại��6-   $	 100��6A    6M   �� *	dienthoai+�� 58      $��Ngày thu tiền��6-   $	 130��6D    6P   �� *	ngaythu+�� 59      $��Số tiền thu��6-   $ 70��6B    6M   �� *	sotienthu+5:       � ContextMenu 5<      �� 5=      .@�5>      m� -   5        $��Sửa bản ghi��5>   '   6<   m� 5?      -   5        $��Xóa bản ghi��5?   '   6<   5@      5B      5C      5D      5E      5F      