   M S B A M L   `   `   `  ����N  JInformationSecurity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:InformationSecurityInformationSecurity  5   	   $    InformationSecurity.ChangeUser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:InformationSecurity     5   	     � Title$  
ChangeUser��5   	   $��477.309��6   $��623.087��6-   .��5	      � $��0,0,2,1q�6   ��5
   
   �� 5       �� ImageSource$ resources/Bitmap2.bmp��6   .+�5   
   �� -   5         ��Name$ 	listView1��5      $
��Left=�6&   $	��176��6A   $��	13,10,0,0q�6N   $	��Top=�6a   $	��588��6y   ���	#FFA79AD4���	#FF383838 �� View 5      �� 5      .P�5      �� 5      5      �� 5   
   -   5         ��Name$ label1��5      $��
Логин��6    $
��Left=�60   $��31��6K   $��
13,205,0,0q�6W   $	��Top=�6k   $	��113��6�   $
��Bold"�6�   $��Franklin Gothic Medium)�6�   ���	#FFBFB8DA���	#FF5151516�   �� 5   
   -   5        $ label2��5      $��Пароль��6    $
��Left=�61   $��31��6L   $��131,205,0,0q�6X   $	��Top=�6m   $	��114��6�   $
��Bold"�6�   $��Franklin Gothic Medium)�6�   ���	#FF555555���	#FFBFB8DA6�   �� 5   
   -   5         ��Name$ textBox1��5      $
��Left=�6$   $��30��6?   $��
13,236,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��113��6�   $��Center=�6�   $��Center=�6�   ���	#FFE7E7E76�   �� 5   
   -   5        $ textBox2��5      $
��Left=�6$   $��30��6?   $��131,236,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��114��6�   $��Center=�6�   $��Center=�6�   ���	#FFE7E7E76�   �� 5   
   -   5        $ label3��5      $��Роль��6    $
��Left=�6/   $��31��6J   $��369,205,0,0q�6V   $	��Top=�6k   $	��113��6�   $
��Bold"�6�   $��Franklin Gothic Medium)�6�   ���	#FFBFB8DA���	#FF4D4D4D6�   �� 5   
   -   5        $ label4��5      $��Уровень��6    $
��Left=�62   $��31��6M   $��487,205,0,0q�6Y   $	��Top=�6n   $	��114��6�   $
��Bold"�6�   $��Franklin Gothic Medium)�6�   ���	#FFBFB8DA���	#FF4B4B4B6�   �� 5   
   -   5         ��Name$ button2��5      $��Изменить��6"   $
��Left=�65   $��36��6P   $��131,362,0,0q�6\   $	��Top=�6q   $	��100��6�   ���	#FFE2E2E2���	#FF665D85$��20(�6�   $��Franklin Gothic Medium)�6�   �� 5   
   -	   5        $ button3��5      $��Удалить��6"   $
��Left=�64   $��36��6O   $��262,362,0,0q�6[   $	��Top=�6p   $	��102��6�   ���	#FF665D85���	#FFD6D6D6$��20(�6�   $��Franklin Gothic Medium)�6�   �� 5   
   -
   5        $ label5��5      $��Бан��6    $
��Left=�6.   $��31��6I   $��250,205,0,0q�6U   $	��Top=�6j   $	��114��6�   $
��Bold"�6�   $��Franklin Gothic Medium)�6�   ���	#FFBFB8DA���	#FF4B4B4B6�   �� 5   
   -   5        $ textBox3��5      $
��Left=�6$   $��30��6?   $��250,236,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��114��6�   $��Center=�6�   $��Center=�6�   ���	#FFE7E7E76�   �� 5   
   -   5         ��Name$ 	comboBox1��5      $
��Left=�6&   $��369,236,0,0q�6A   $	��Top=�6V   $	��113��6n   $��30��6z   6�   �� 5   
   -   5        $ 	comboBox2��5      $
��Left=�6&   $��487,236,0,0q�6A   $	��Top=�6V   $	��114��6n   $��30��6z   
�������	 J� RenderTransformOrigin$	 0.5,0.5&�6�   ��5       �� 5!      
 �� EndPoint$	
 0,1&�6&    �� 
StartPoint$	 0,0&�65   .��5"      �  � Color$ 	#FFF0F0F0��6#    � Offset$ 0Q�65   � 5#      $ White��6#   $ 1Q�61   5$      5&      5(      5)      