   M S B A M L   `   `   `  ����@  <Start, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Start.View
Start.View  5      1clr-namespace:Start.ViewModelStart.ViewModel  5      3clr-namespace:Start.PropertiesStart.Properties  5          Start.View.AddWeapons   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Start.View     5      ,vmclr-namespace:Start.ViewModel     5      /resxclr-namespace:Start.Properties     5        N� Title$  AddArmor��5       � 	Resources 5      #  Start.ViewModel.MainViewModel 
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
��0.5* �6#   �� 5@      .+�5C      �� $��DODAJ BROŃ��6   $��3��6*   $��0��67   $��4��6G   $��Center=�6[   $��Viner Hand ITC)�5D      $��26(�64   
�������6B   �� 5F       �� Orientation$ 
Horizontal=�6   $��5��62   $��0��6?   $��2��6O   .+�5G      �� #��[ 6Z   $��0,0,10,0q�6}   ��6   ��     Start.Properties.Resources	   WeaponsName
 �� Source#
 Z	 6}   �� 5H      $	��120��6N   $��20��6Z   #��[ 6f   $��0,0,10,0q�6�   ��6   �� *AddItemsVM.WeaponName+ �� Mode$ TwoWay=�6�   5I      �� 5K      $ 
Horizontal=�6   $��6��62   $��0��6?   $��2��6O   .+�5L      �� #��[ 6Z   $��0,0,10,0q�6}   ��6   ��    WeaponRange#
 Z 6}   �� 5M      $	��120��6O   $��20��6[   #��[ 6g   $��0,0,10,0q�6�   ��6   �� *AddItemsVM.AttackRange+$ TwoWay=�6�   5N      �� 5P      $ 
Horizontal=�6   $��6��62   $��2��6?   $��2��6O   .+�5Q      �� #��[ 6S   $��0,0,10,0q�6v   ��6   ��    Type#
 Z 6v   �� 5R      $	��120��6N   $��20��6Z   #��[ 6f   $��0,0,10,0q�6�   ��6   �� *AddItemsVM.DamageType+$ TwoWay=�6�   5S      �� 5U      $ 
Horizontal=�6   $��7��62   $��0��6?   $��2��6O   .+�5V      �� #��[ 6V   $��0,0,10,0q�6y   ��6   ��    DMGDice#
 Z 6y   �� 5W      -   5        $	��120��5W   K   $��20��6W   #��[ 6c   $��0,0,10,0q�6�    �� 	MaxLength$ 1��6�   ��6   �� *AddItemsVM.DmgDice+$ TwoWay=�6�   5X      �� 5Z      $ 
Horizontal=�6   $��7��62   $��2��6?   $��2��6O   .+�5[      �� #��[ 6Z   $��0,0,10,0q�6}   ��6   ��    DMGDiceSize#
 Z 6}   �� 5\      -   5        $	��120��5\   O   $��20��6[   #��[ 6g   $��0,0,10,0q�6�   $ 1��6�   ��6   �� *AddItemsVM.DmgDiceSize+$ TwoWay=�6�   5]      �� 5_      $ 
Horizontal=�6   $��8��62   $��0��6?   $��4��6O   $��2��6c   .+�5`      �� #��[ 6_   $��0,0,10,0q�6�   ��6   ��    ItemsDescription#
 Z 6�   �� 5a      $	��320��6U   $��60��6a   #��[ 6m   $��0,0,10,0q�5b       �� TextWrapping$
 Wrap=�6,    �� AcceptsReturn . ��5a      �� *AddItemsVM.WeaponDescription+$ TwoWay=�5b   @   5c      5d      �� 5e   
   -   5         ��Name$
 Next��5e      $	��100��5f      $��40��6   $��Viner Hand ITC)�6)   $��	150,0,0,0q�6E   $��3��5g      $��1��6   ��5e   2   �� *AddItemsVM.AddWeaponNext+$ OneWay=���6l   ��    Next#
 Z 5g      �� 5h   
   -   5        $
 Save��5h      $	��100��5i      $��40��6   $��Viner Hand ITC)�6)   $��	0,0,150,0q�6E   $��3��5j      $��1��6   ��5h      �� *AddItemsVM.AddWeapon+$ OneWay=���6U   ��    Save#
 Z 5j      5k      5l      