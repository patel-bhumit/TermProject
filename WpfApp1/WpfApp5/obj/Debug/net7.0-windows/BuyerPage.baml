   M S B A M L   `   `   `  ����B  >WpfApp5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp5WpfApp5  5   	       WpfApp5.BuyerPage   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp5     5   	     � Title$  	BuyerPage��5   	   $
��1080��6   $
��1920��6)   .��5	      � $��	0,0,10,-6q�6   $��Center=�6   $��Center=�6;    � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��	0,30,0,44q�6%   .+�5      �� -   5        $��Log Out��5      $��82��6'   $��20��62   $��Right=�6Y   �� 5      $��10q�6   ���	#FFDDDDDD �� CornerRadius$ 5��68   ._�5      �� $��Contract Data��6   
������ .��5      �� .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ ContractGrid��5   #      
IsReadOnly$
 True��69      SelectionMode$ Extended=�6K   �� 5       �� Orientation$ 
Horizontal=�6%   $��Right=�6>   $��0,10,0,0q�6Z   .+�5      �� -   5        $��Refresh��5   %   $��82��67   $��20��6B   6N   5      5      5      5      �� 5      $��10q�6   ���	#FFDDDDDD$ 5��68   ._�5       �� $��Completed Order Data��6   
������ .��5!      �� .+�5"        -   5        $ CompletedOrderGrid��5"   #   $
 True��6?   $ Extended=�6Q   �� 5$      $ 
Horizontal=�6%   $��Right=�6>   $��0,10,0,0q�6Z   .+�5%      �� -   5        $��Refresh��5%   %   $��82��67   $��20��6B   6N   5&      5'      5(      5)      �� 5+      $ 
Horizontal=�6   $��Right=�62   $��0,10,0,0q�6N   .+�5,      �� -   5        $��Add Customer��5,      $	��200��60   6<   �� 5-      -   5        $��Initiate New Order��5-      $	��200��66   6B   �� 5.      -   5        $��Generate Invoice��5.      $	��200��64   6@   5/      50      51      52      