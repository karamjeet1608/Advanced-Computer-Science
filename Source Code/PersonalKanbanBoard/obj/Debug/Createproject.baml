   M S B A M L   `   `   `  ����N  JPersonalKanbanBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PersonalKanbanBoardPersonalKanbanBoard  5   	   '    !PersonalKanbanBoard.Createproject   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:PersonalKanbanBoard     5   	     � Title$  CreateProject��5   
   $	��700��6    $
��1024��6-   .��5	      � $	��667��6   $	��Top=�6   .+�5
   
   �� $��Georgia)�6   $��20(�6&   $��Project Title��64   $
��Left=�6L   $��
138,69,0,0q�6g   $	��Top=�6{   $	��126��6�   �� 5   
   $��Georgia)�6   $��20(�6&   $��Project Description��64   $
��Left=�6R   $��138,136,0,0q�6m   $	��Top=�6�   �� 5   
   $��Georgia)�6   $��20(�6&   $��Project Start Date��64   $
��Left=�6Q   $��138,253,0,0q�6l   $	��Top=�6�   �� 5   
   $��Georgia)�6   $��20(�6&   $��Project End Date��64   $
��Left=�6O   $��138,317,0,0q�6j   $	��Top=�6    J� RenderTransformOrigin$ 1.214,1.558&�6�   �� 5   
   $��Georgia)�6   $��20(�6&   $��No. of Tasks To do��64   $
��Left=�6Q   $��138,389,0,0q�6l   $	��Top=�6�   �� 5   
   $��Georgia)�6   $��20(�6&   $$��No. of Tasks in progress Limit��64   $
��Left=�6]   $��138,453,0,0q�6x   $	��Top=�6�   $	��298��6�   �� 5   
   $��Georgia)�6   $��20(�6&   $��No. of Tasks Done Limit��64   $
��Left=�6V   $��138,508,0,0q�6q   $	��Top=�6�   $ 0.847,1.344&�6�   �� 5   
   -   5         ��Name$ projectTitle��5   6   $��Georgia)�6   $��20(�6(    � ToolTip$" e.g. buy new car, learn java��6L   $
��Left=�6s   $��34��6�   $��
543,69,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��356��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 	startDate��5   9   $��Georgia)�6   $��20(�6+   $" Date should not be from past��6L   $
��Left=�6s   $��543,253,0,0q�6�   $	��Top=�6�   $ 
1.049,0.82&�6�   $��39��6�   $	��163��6�     5   
   -   5        $ endDate��5   9   $��Georgia)�6   $��20(�6+   $" Date should not be from past��6J   $
��Left=�6q   $��543,317,0,0q�6�   $	��Top=�6�   $	��163��6�   $��39��6�   �� 5   
   -   5        $ projectDescription��5   6   $��Georgia)�6   $��20(�6(   $
��Left=�6R   $	��105��6m   $��543,127,0,0q�6z   $
 Wrap=�6�   $	��Top=�6�   $	��356��6�   �� 5   
   -   5        $ 	toDoLimit��5   6   $��Georgia)�6   $��20(�6(   $ e.g. 6��6I   $
��Left=�6Z   $��39��6u   $��543,389,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��356��6�   $ 0.493,1.206&�6�   �� 5   
   -   5        $ workInProgressLimit��5   6   $��Georgia)�6   $��20(�6(   $$ Should be less than todo limit��6S   $
��Left=�6|   $��34��6�   $��543,452,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��356��6�   �� 5   
   -   5        $ 	doneLimit��5   6   $��Georgia)�6   $��20(�6(   $
��Left=�6I   $) #e.g. should be equal to to do limit��6d   $��34��6�   $��543,508,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��356��6�   �� 5   
   -   5         ��Name$ btn_createProject��5   J   ���#3498DB$��Georgia)�6&   $��20(�6<   $��Create Project��6f   $
��Left=�6   $��250,581,0,0q�6�   $	��Top=�6�   $	��132��6�   $��40��6�   6�   �� 5   
   -	   5        $ 
btn_Cancel��5   J   ���#3498DB$��Georgia)�6&   $��20(�6<   $��Cancel��6^   $
��Left=�6o   $��543,581,0,0q�6�   $	��Top=�6�   $	��148��6�   $��40��6�   6�   �� 5   
   ���#3498DB$
��Left=�6#   $��45��6>   
���   �$	��Top=�6Y   $
��1016��6q   �� 5   
   $��Georgia)�6   $��CREATE PROJECT��6'   $
��Left=�6@   $��	410,0,0,0q�6[   $	��Top=�6n   $��45��6�   $��22(�6�   $	��212��6�   �� 5   
   
���  ��$��Georgia)�6!   $��9(�68   $��*All Fields are mandatory��6F   $
��Left=�6j   $��
539,51,0,0q�6�   $	��Top=�6�   $	��167��6�   5      5      