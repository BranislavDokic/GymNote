   M S B A M L   `   `   `  ����B  >GymNote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:GymNoteGymNote  5          GymNote.InlogdUser   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:GymNote     5        N� Title$  
InlogdUser��5	       N� 
Background
 � � �.��5      �� 
������� �� CornerRadius$ 30��6   $��20q�61   ._�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� $��0��6   $
��Auto=�6(   .��5      �� -   5         ��Name$ ListBoxUserWorkouts��5      $��Stretch=�67   $��Stretch=�6\   $��10q�6   $	��300��6�   ��5      �� 5      .R�5      �  � ColumnDefinitions 5   "   �� 5   &   $
��Auto �67   �� 5   &   $
��Auto �67   �� 5   &   $
��Auto �67   �� 5   &   $
��Auto �67   �� 5   &   $
��Auto �67   �� 5   &   $
��Auto �67   �� 5   &   $
��Auto �67   �� 5   &   $
��Auto �67   �� 5    &   $
��Auto �67   �� 5!   &   $
��Auto �67   �� 5"   &   $
��Auto �67   �� 5#   &   $
��Auto �67   .+�5&   "   �� $��Name: ��6,   $
��Bold"�6:   $��0��6L   $��Center=�6]   �� 5'   "   $��1��6F   $��2q�6V   $��Center=�6a   ��6,   �� *
UserName+6a   �� 5(   "   $��	Workout: ��6,   $
��Bold"�6=   $��2��6O   $��10q�6_   $��Center=�6k   �� 5)   "   $��3��6I   $��2q�6Y   $��Center=�6d   ��6,   �� *WorkoutName+6d   �� 5*   "   $��Sets: ��6,   $
��Bold"�6:   $��4��6L   $��10q�6\   $��Center=�6h   �� 5+   "   $��5��6B   $��2q�6R   $��Center=�6]   ��6,   �� *Sets+6]   �� 5,   "   $��Reps: ��6,   $
��Bold"�6:   $��6��6L   $��10q�6\   $��Center=�6h   �� 5-   "   $��7��6B   $��2q�6R   $��Center=�6]   ��6,   �� *Reps+6]   �� 5.   "   $��Grade: ��6,   $
��Bold"�6;   $��8��6M   $��10q�6]   $��Center=�6i   �� 5/   "   $��9��6C   $��2q�6S   $��Center=�6^   ��6,   �� *Grade+6^   �� 50   "   $��Workout ID: ��6,   $
��Bold"�6@   $��10��6R   $��10q�6c   $��Center=�6o   �� 51   "   $��11��6G   $��2q�6X   $��Center=�6c   ��6,   �� *	Workoutid+6c   54      55      57      58      �� 59      $��1��6   $��20q�6&   .+�5:      �� $%��Workout Name Max 45 Characters:��6   $��Center=�6B   �� 5;      -   5         ��Name$ TextBoxWorkoutName��5;      $	��0 5q�66   $	��200��6C   $��Center=�6O   �� 5=      $��Sets:��6   $��0 10 0 0q�6(   $��Center=�6:   �� 5>      -   5        $ TextBoxSets��5>      $	��0 5q�6/   $	��200��6<   $��Center=�6H   6e   �� 5@      $��Reps:��6   $��0 10 0 0q�6(   $��Center=�6:   �� 5A      -   5        $ TextBoxReps��5A      $	��0 5q�6/   $	��200��6<   $��Center=�6H   6e   �� 5C      $��Weight:��6   $��0 10 0 0q�6*   $��Center=�6<   �� 5D      -   5        $ TextBoxWeight��5D      $	��0 5q�61   $	��200��6>   $��Center=�6J   6g   �� 5F      $I��CHow did exercise feel(Not Good, Good, Very Good) Max 10 Characters:��6   $��0 10 0 0q�6f   $��Center=�6x   �� 5G      -   5        $ TextBoxGrade��5G      $	��0 5q�60   $	��200��6=   $��Center=�6I   �� 5I       �� Orientation$ 
Horizontal=�6   $��Center=�66   $
��0 20q�6S   .+�5J      �� -   5         ��Name$ ButtonAddWorkout��5J      $	��Add��67   $��80��6E   $��5q�6P   6[   5K      �� 5L      $ 
Horizontal=�6   $��Center=�66   $��20q�6S   .+�5M      �� $��USER:��6   �� 5N      -   5        	 ��Name$	 logdInUserLabel��5N      $�� ��65   5O      �� 5P      $��Search Workout By Name��6   $��Center=�69   �� 5Q      -	   5        $ SerchBox��5Q      $��0,0,0,10q�6,   $	��200��6>   �� 5R      -
   5        $ SerchButton��5R      $��0,0,0,15q�6.   $��25��6@   $	��100��6L   $��serch workout��6X   6p   �� 5S      -   5        $ DeleteButton��5S      $��0,0,0,15q�6/   $��25��6A   $	��100��6M   $��Delete workout��6Y   6r   �� 5T      -   5        $ LogoutButton��5T      $��Log out��6/   $��Center=�6A   $��40��6^   $	��100��6j   6v   �� 5U      $��Uppdate Password��6   $��Center=�63   $��0,20,0,0q�6P   $��15(�6b   $
��Bold"�6p   �� 5V      $*��$Write new Password Max Characters 15��6   $��Center=�6G   G� 5W      -   5        
 G�Name$
 UppdatePasswordTxtBox��5W      $��Center=�6=   $	��150��6Z   �� 5X      $��Verify Password��6   $��Center=�62   G� 5Y      -   5        $
 UppdatePasswordTxtBox2��5Y      $��Center=�6>   $	��150��6[   �� 5Z      -   5        $ UppdateButton��5Z      $��Center=�60   $	��115��6M   $��20��6Y   $��Uppdate Password��6e   $
��0,10q�6�   6�   5[      5]      5^      5_      