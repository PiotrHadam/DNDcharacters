   M S B A M L   `   `   `  ����@  <Start, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Start.View
Start.View  5      1clr-namespace:Start.ViewModelStart.ViewModel  5      3clr-namespace:Start.PropertiesStart.Properties  5          Start.View.AddItems   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Start.View     5      ,vmclr-namespace:Start.ViewModel     5      /resxclr-namespace:Start.Properties     5        N� Title$  AddItems��5       � 	Resources 5      #  Start.ViewModel.MainViewModel 
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
��0.5* �6#   �� 5@      .+�5C      �� $��DODAJ PRZEDMIOT��6   $��3��6/   $��0��6<   $��4��6L   $��Center=�6`   $��Viner Hand ITC)�5D      $��26(�64   
�������6B   �� 5F       �� Orientation$ 
Horizontal=�6   $��6��62   $��0��6?   $��2��6O   .+�5G      �� #��[ 6X   $��0,0,10,0q�6{   ��6   ��     Start.Properties.Resources	   	ItemsName
 �� Source#
 Z	 6{   �� 5H      $	��120��6q   $��20��6}   #��[ 6�   $��0,0,10,0q�6�   ��6   �� *AddItemsVM.ItemName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5I      �� 5K      $ 
Horizontal=�6   $��8��62   $��0��6?   $��4��6O   $��2��6c   .+�5L      �� #��[ 6_   $��0,0,10,0q�6�   ��6   ��    ItemsDescription#
 Z 6�   �� 5M      $	��320��6x   $��60��6�   #��[ 6�   $��0,0,10,0q�5N       �� TextWrapping$
 Wrap=�6,    �� AcceptsReturn . ��5M      �� *AddItemsVM.ItemDescription+$ TwoWay=�$ PropertyChanged=�5N   @   5O      5P      �� 5Q   
   -   5         ��Name$
 Save��5Q      $	��100��5R      $��40��6   $��Viner Hand ITC)�6)   $��	0,0,150,0q�6E   $��3��5S      $��1��6   ��5Q      �� *AddItemsVM.AddItem+$ OneWay=���6S   ��    Save#
 Z 5S      �� 5T   
   -   5        $
 Next��5T      $	��100��5U      $��40��6   $��Viner Hand ITC)�6)   $��	150,0,0,0q�6E   $��3��5V      $��1��6   ��5T   2   �� *AddItemsVM.AddItemNext+$ OneWay=���6j   ��    Next#
 Z 5V      5W      5X      