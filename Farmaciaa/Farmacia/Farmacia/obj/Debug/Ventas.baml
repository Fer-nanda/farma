   M S B A M L   `   `   `  ����C  ?Farmacia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FarmaciaFarmacia  5   	       Farmacia.Ventas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Farmacia     5   	     � Title$  Ventas��5   	   $��566.667��6   $	��646��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��1��6   $��2��6    $%��Imagenes/la-farmacia-online.jpg��61   $
��Fill=�6Z   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dtgGrupos��5      $��0��6&   $��0��66   $��2��6C   ��5      �� 5       �� ImageSource$% Imagenes/la-farmacia-online.jpg��6   5      �� 5   
   $��0��6   $��2��6%    �� Orientation$ 
Horizontal=�62   ��5      �� 5      $% Imagenes/la-farmacia-online.jpg��6   .+�5      �� -   5         ��Name$ btnAgregarGrupo��5      $��50��6.   $��16��69   .��5      �� $��Imagenes/add.png��6    � ToolTip$ Agregar Grupo��62   5      �� 5       -   5        $ btnEditarGrupo��5       $��50��6-   $��16��68   .��5!      �� $��Imagenes/pencil.png��6   $ Editar Grupo��65   5"      �� 5#      -   5        $ btnEliminarGrupo��5#      $��50��6/   $��16��6:   .��5$      �� $��Imagenes/Bin.png��6   $ Eliminar Grupo��62   5%      5&      �� 5'   
   $��1��6   $��0��6%   .+�5(      �� $��Guardar��6   ��5)      �� 5*       �� EndPoint$ 0.5,1&�6*   	 �� 
StartPoint$	 0.5,0&�6;   .��5+      � 
 � Color$
 Black��6'    � Offset$ 0Q�65   � 5,      $
 	#FFE7EBF7��6'   $ 0.115Q�69   5-      5/      �� 50      $ 
Horizontal=�6   .+�51      �� $	��120��6   $��Fecha��6$   $
��Bold"�64   (  "System.Windows.Controls.DatePicker  52      -   5          Name$ pkrFechaNacimiento��52   )   $	��200��6   6)   53      �� 54      $ 
Horizontal=�6   .+�55      �� $	��120��6   $��Empleado��6$   $
��Bold"�67   �� 56      -   5         ��Name$ cmbEmpleado��56   '   $	��200��6   6'   57      �� 58      $ 
Horizontal=�6   .+�59      �� $	��120��6   $��Cliente��6$   $
��Bold"�66   �� 5:      -   5        $ 
cmbCliente��5:   '   $	��200��6   6'   5;      �� 5<      $ 
Horizontal=�6   .+�5=      �� $	��120��6   $��	Productos��6$   $
��Bold"�68   �� 5>      -   5        $ cmbproductos��5>   '   $	��200��6   6'   5?      �� 5@      $ 
Horizontal=�6   .+�5A      �� $	��120��6   $��Cantidad��6$   $
��Bold"�67   �� 5B      -	   5         ��Name$ txbCantidad��5B   &   $	��200��6   .��6;   ��5C      �� 5D      .��5E   *   5F      5G      5H        5I   
   -
   5        $ dtgCompañeros��5I   0   $��1��6   $��1��6#   ��5J      �� 5K      5M      �� 5N   
   $��1��6   $��2��6%   $ 
Horizontal=�62   ��5O      �� 5P      $% Imagenes/la-farmacia-online.jpg��6   .+�5R      �� -   5        $ btnAgregarCompaniero��5R      $��50��63   $��16��6>   .��5S      �� $��Imagenes/add.png��6   $ Agregar Compañero��62   5T      �� 5U      -   5        $ btnEliminarCompanieros��5U      $��50��65   $��16��6@   .��5V      �� $��Imagenes/Bin.png��6   $ Eliminar Compañero��62   5W      5X      5Y      5Z      