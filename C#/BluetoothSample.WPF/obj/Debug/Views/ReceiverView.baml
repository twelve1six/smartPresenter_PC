   M S B A M L   `   `   `  ����  BluetoothSample.WPF(    "BluetoothSample.Views.ReceiverView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � DataContext  5      �� *ReceiverViewModel+   Locator �� Source# [  .��5	      �� $��20q�6    �� Orientation$ Vertical=�6   .+�5
   
   �� I am the Receiver6'   �� 5   
   $ 
Horizontal=�6   .+�5      �� $��0,10,0,0q�6   $��80��6'   $��Start��6x   ��63   �� *StartCommand+{�6T   �� *IsStarEnabled+6x   �� 5      $��	20,10,0,0q�6   $��80��6(   $
��Stop��6w   ��63   �� *StopCommand+{�6S   �� *IsStopEnabled+6w   5      �� 5   
   $��	00,20,0,0q�6   $��Data:��6'   �� 5   
   $��	00,20,0,0q�6   ��6'   �� *Data+�� 5   
   $	��Top=�6   $��25��6*   $��Center=�5       �� 
IsReadOnly . $��	0,0,140,0q�6J   ��5   6   ��  �� Path$ FilePath�5   J   �� 5   
   -   5        $��	0,0,276,0q�5      $
��Open��6;   5      5      