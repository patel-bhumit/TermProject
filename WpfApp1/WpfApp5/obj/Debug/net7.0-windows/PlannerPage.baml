   M S B A M L   `   `   `  ����B  >WpfApp5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp5WpfApp5  5   	       WpfApp5.PlannerPage   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp5     5   	     � Title$  PlannerPage��5   	   $
��1080��6   $
��1920��6+   .��5	      � $��	0,0,10,-6q�6   $��Center=�6   $��Center=�6;    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��1��6   ���	#FFDDDDDD �� CornerRadius$ 5��65   $��
12,2,10,10q�6F   ._�5      �� $��Orders Data��6   
������ .��5      �� .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
OrdersGrid��5         AutoGenerateColumns$
 True��63   $��10q�6N   �� 5      -   5        $��Assign Carrier��5      $��5,0,5,0q�6R   $��Right=�6c   5      5      5      �� 5   
   $��2��6   ���	#FFDDDDDD$ 5��65   $��12,10,10,10q�6F   ._�5      �� $��
Trips Data��6   
������ .��5      �� .+�5        -   5        $ TripGrid��5      $
 True��61   $��10q�6L   �� 5      -   5        $��Confirm Order��5      $��5,0,0,0q�6X   $��Right=�6i   5       5!      5"      �� 5$   
   $��3��6   ���	#FFDDDDDD$ 5��65   $��12,10,10,10q�6F   ._�5%      �� $��Completed Orders Data��6   
������ .��5&        -   5        $ CompletedOrderGrid��5&      $
 True��67   $��10q�6R   5'      5(      �� 5*   
   $��4��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��	0,10,10,0q�6W   .+�5+      �� -   5        $��Refresh��5+      $��82��6'   $��20��62   $��0,0,5,0q�6S   $��Right=�6d   �� 5,      -   5        $��Past Two Week Invoice��5,      $��5,0,0,0q�6\   �� 5-      -   5        $��All Invoice��5-      $��5,0,0,0q�6M   5.      �� 50   
   -	   5        $��0��50      $��Logout��6   $��10,10,10,10q�6J   $	��Top=�6_   $��Right=�6w   51      52      