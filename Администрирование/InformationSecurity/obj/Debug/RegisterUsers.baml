   M S B A M L   `   `   `  ����N  JInformationSecurity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:InformationSecurityInformationSecurity  5   	   '    !InformationSecurity.RegisterUsers   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:InformationSecurity     5   	     � Title$  RegisterUsers��5   	   $��480.147��6   $��576.716��60   ��5	      �� 5
   
    �� ImageSource$ resources/Bitmap2.bmp��6   .��5      � $��0,0,2,-1q�6   .+�5   
   �� -   5         ��Name$ 	listView1��5      $
��Left=�6&   $	��221��6A   $��	10,10,0,0q�6N   $	��Top=�6a   $	��546��6y   ���	#FFA79AD4���	#FF515151 �� View 5      �� 5      .P�5      �� 5      5      �� 5   
   -   5         ��Name$ label1��5      $��
Логин��6    $
��Left=�60   $��28��6K   $��
19,270,0,0q�6W   $	��Top=�6k   $	��109��6�   $
��Bold"�6�   $��16(�6�   ���	#FF4D4D4D���	#FFBFB8DA$��Franklin Gothic Medium)�6�   �� 5   
   -   5        $ label2��5      $��Пароль��6    $
��Left=�61   $��28��6L   $��155,270,0,0q�6X   $	��Top=�6m   $	��109��6�   $
��Bold"�6�   $��16(�6�   ���	#FF4D4D4D���	#FFBEB7D9$��Franklin Gothic Medium)�6�   �� 5   
   -   5         ��Name$ textBox1��5      $
��Left=�6$   $��25��6?   $��
19,298,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��109��6�   $��Center=�6�   $��Center=�6�   G� 5   
   -   5         G�Name$ passBox1��5      $
��Left=�6(   $��25��6C   $��155,298,0,0q�6O   $	��Top=�6d   $	��109��6|   $��Center=�6�   $��Center=�6�   �� 5   
   -   5         ��Name$ 	comboBox1��5      $
��Left=�6&   $��24��6A   $��295,298,0,0q�6M   $	��Top=�6b   $	��109��6z   6�   �� 5   
   -   5        $ 	comboBox2��5      $
��Left=�6&   $��24��6A   $��434,298,0,0q�6M   $	��Top=�6b   $	��109��6z   6�   �� 5   
   -   5        	 ��Name$	 button1��5      $&�� Зарегистрировать��6"   $
��Left=�6=   $��32��6X   $��225,356,0,0q�6d   $	��Top=�6y   $	��110��6�   
 J� RenderTransformOrigin$
 0.502,0.431&�6�   ���	#FF665D85���	#FFE0E0E0$��Franklin Gothic Medium)�6  �� 5   
   -	   5        $ label1_Copy��5      $��Уровень��6%   $
��Left=�67   $��28��6R   $��295,270,0,0q�6^   $	��Top=�6s   $	��109��6�   $
��Bold"�6�   $��16(�6�   ���	#FF4D4D4D���	#FFBFB8DA$��Franklin Gothic Medium)�6�   �� 5   
   -
   5        $ label2_Copy��5      $��Роль��6%   $
��Left=�64   $��28��6O   $��434,270,0,0q�6[   $	��Top=�6p   $	��109��6�   $
��Bold"�6�   $��16(�6�   ���	#FF4D4D4D���	#FFBEB7D9$��Franklin Gothic Medium)�6�   5      5      