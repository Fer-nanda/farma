   M S B A M L   `   `   `  ����C  ?Farmacia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FarmaciaFarmacia  5   	       Farmacia.Categoria   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Farmacia     5   	     � Title$  	Categoria��5   	   $	��300��6   $	��300��6(   ��5	      �� 5
   
    �� ImageSource$ Imagenes/ca.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��Center=�6   $��0��6-   $��Agregar Categoria��6:   $��Kristen ITC)�6V   � 5   
   $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��119��6   $��Tipo de Categoria��6$   �� 5      -   5         ��Name$ txbTipoCategoria��5      $	��171��64   .��6@   ��5      �� 5      .��5   *   5      5      5      &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ dtgCategoria��5"         
IsReadOnly . $��3��6;   ��5#      �� 5$      $ Imagenes/ca.jpg��6    j� Stretch$ Uniform=�6;   5'      � 5(   
   $��2��6   .+�5)      �� -   5         ��Name$ btnNuevo��5)       $��70��6   $��Nuevo��6I   ��5*      �� 5+      	 �� EndPoint$	 0.5,1&�6*   
 �� 
StartPoint$
 0.5,0&�6;   .��5,      �  � Color$ Black��6'    � Offset$ 0Q�65   � 5-      $ 	#FF88B9EA��6'   $ 0.316Q�69   5.      50      �� 51      -   5        $ 
btnGuardar��51       $��70��6   $��Guardar��6M   ��52      �� 53      $	 0.5,1&�6*   $
 0.5,0&�6;   .��54      � $ Black��6'   $ 0Q�65   � 55      $ 	#FF88B9EA��6'   $ 0.316Q�69   56      58      �� 59      -   5        $ 	btnEditar��59       $��70��6   $��Editar��6K   ��5:      �� 5;      $	 0.5,1&�6*   $
 0.5,0&�6;   .��5<      � $ Black��6'   $ 0Q�65   � 5=      $ 	#FF88B9EA��6'   $ 0.316Q�69   5>      5@      �� 5A      -   5        $ btnCancelar��5A       $��70��6   $��Cancelar��6O   ��5B      �� 5C      $	 0.5,1&�6*   $
 0.5,0&�6;   .��5D      � $ Black��6'   $ 0Q�65   � 5E      $ 	#FF88B9EA��6'   $ 0.316Q�69   5F      5H      �� 5I      -   5        $ btnEliminar��5I       $��70��6   $��Eliminar��6O   ��5J      �� 5K      $	 0.5,1&�6*   $
 0.5,0&�6;   .��5L      � $ Black��6'   $ 0Q�65   � 5M      $ 	#FF88B9EA��6'   $ 0.316Q�69   5N      5P      �� 5Q      -   5        $ btnRegresar��5Q       $��70��6   $��Regresar��6O   ��5R      �� 5S      $	 0.5,1&�6*   $
 0.5,0&�6;   .��5T      � $ Black��6'   $ 0Q�65   � 5U      $ 	#FF88B9EA��6'   $ 0.316Q�69   5V      5X      5Y      5[      5\      