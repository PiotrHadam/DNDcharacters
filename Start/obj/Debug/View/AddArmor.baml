   M S B A M L   `   `   `  ����@  <Start, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Start.View
Start.View  5      1clr-namespace:Start.ViewModelStart.ViewModel  5      3clr-namespace:Start.PropertiesStart.Properties  5          Start.View.AddArmor   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Start.View     5      ,vmclr-namespace:Start.ViewModel     5      /resxclr-namespace:Start.Properties     5        N� Title$  AddArmor��5       � 	Resources 5      #  Start.ViewModel.MainViewModel 
  mainvm  	TextStyle �� 
TargetType �� Property �� Value  TextBoxStyle  
LabelStyle��%�  &	        &	      &	 �     &	 M      5   
   6   �� 5   
   " ��6"   .�5      ��  � ��$ Segoe Script)�6+   �� 5       � ��$ 20��6'   �� 5       � ��
 �����6+   5      �� 5   
   " ��6%   .�5      ��  � ��$ Segoe Script)�6+   �� 5       � ��
 �����6+   �� 5       � ��
 ���� 6+   5      �� 5   
   " ��6#   .�5      ��  � ��$ Segoe Script)�6+   �� 5       � ��
 �����6+   5      5      .��5      �  � DataContext# [  6    � RowDefinitions 5   
   �� 5       �� 5!      $	��18* �6   �� 5"      $��2* �6    � ColumnDefinitions 5$   
   �� 5%      �� 5&      $	��18* �6   �� 5'      .+�5*   
   � $��1��6   $��1��6    5+      �� 5,      �� 5-      �� 5.      �� 5/      �� 50      �� 51      �� 52      �� 53      �� 54      �� 55      �� 56      �� 57      �� 58      �� 59      �� 5:       5<      �� 5=      �� 5>      $
��0.5* �6#   �� 5?      $
��0.5* �6#   �� 5@      .+�5C      �� $��DODAJ PANCERZ��6   $��3��6-   $��0��6:   $��4��6J   $��Center=�6^   $��Viner Hand ITC)�5D      $��26(�64   
�������6B   �� 5F       �� Orientation$ 
Horizontal=�6   $��5��62   $��0��6?   $��2��6O   .+�5G      �� #��[ 6Y   $��0,0,10,0q�6|   ��6   ��     Start.Properties.Resources	   
ArmorsName
 �� Source#
 Z	 6|   �� 5H      $	��120��6M   $��20��6Y   #��[ 6e   $��0,0,10,0q�6�   ��6   �� *AddItemsVM.ArmorName+ �� Mode$ TwoWay=�6�   5I      �� 5K      $ 
Horizontal=�6   $��7��62   $��0��6?   $��2��6O   .+�5L      �� #��[ 6Y   $��0,0,10,0q�6|   ��6   ��    
ClassBonus#
 Z 6|   �� 5M      -   5        $��60��5M   S   $��20��6^   #��[ 6�   $��0,0,10,0q�6�    �� 	MaxLength$ 2��6�   ��6   �� *AddItemsVM.ArmorClassBonus+$ TwoWay=�6�   5N      �� 5P      $ 
Horizontal=�6   $��9��62   $��0��6?   $��4��6O   $��2��6c   .+�5Q      �� #��[ 6_   $��0,0,10,0q�6�   ��6   ��    ItemsDescription#
 Z 6�   �� 5R      $	��320��6T   $��60��6`   #��[ 6l   $��0,0,10,0q�5S       �� TextWrapping$
 Wrap=�6,    �� AcceptsReturn . ��5R      �� *AddItemsVM.ArmorDescription+$ TwoWay=�5S   @   5T      5U      �� 5V   
   -   5         ��Name$
 Next��5V      $	��100��5W      $��40��6   $��Viner Hand ITC)�6)   $��	200,0,0,0q�6E   $��3��5X      $��1��6   ��5V   2   �� *AddItemsVM.AddArmorNext+$ OneWay=���6k   ��    Next#
 Z 5X      5Y      5Z      