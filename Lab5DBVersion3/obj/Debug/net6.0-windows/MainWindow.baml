   M S B A M L   `   `   `  ����I  ELab5DBVersion3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Lab5DBVersion3.ViewModelLab5DBVersion3.ViewModel  5   	       Lab5DBVersion3.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Lab5DBVersion3.ViewModel     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5	      ,   &Lab5DBVersion3.ViewModel.MainViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��20 �6   �� 5      �� 5      $��40 �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      $��50 �6   .+�5   
   o� $��0��6   $��3��6   $��0��63   .@�5      m� $��Добавить��6   $��30��6)    m� Command 68   �� *
AddFiles+5      R� 5   
   $��1��6   $��2��6    $��0��61   ��6A   �� *TreeElement+��5      �� 5       �� ItemsSource 6+   �� *
Children+.R�5      �� ��6    �� *Name+5      5!      �� 5"   
   $��1��6   $��1��6    ��60   �� *ComboBoxElement+ �� SelectedItem 6X   �� *ComboBoxSelectItem+�� 5#   
   $��1��6   $��2��6   $��Выбрать��6.   ��6@   �� *CreateTable+&   System.Windows.Controls.DataGrid  5$   
   $��2��6   $��2��6    $��1��61   $��2��6A   ��6U   �� *TableElement+�� 5%   
   $��3��6   $��0��6!   ��61   �� *ContentErrorWindow+5&      5'      