   M S B A M L   `   `   `  ����I  EWpfApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfApplicationWpfApplication  5      A =DotNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/$clr-namespace:DotNet;assembly=DotNetDotNet 5      "    WpfApplication.ActorsControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WpfApplication     5      7DotNet$clr-namespace:DotNet;assembly=DotNet     5      -   5          � 	Resources  5
         actorViewSource  actorMoviesViewSource �� Source �� Source��%W   &	        &	      7   �� 5   
   6   �� 5   
    6=   �� *Movies+8   5      .��5      �  � DataContext# [  6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ actorDataGrid��5         RowDetailsVisibilityMode$ VisibleWhenSelected=�6*   $��	10,10,0,0q�6Y      EnableRowVirtualization .    AutoGenerateColumns .  $
��Left=�6�   $	��Top=�6�   $	��284��6�   $	��171��6�   ��6l   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        actorIdColumn��,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 SizeToHeader 5   <   
   Header$
 Actor Id��6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6c   �� *	ActorId+  5      -   5        firstNameColumn��$	 SizeToHeader 5   >   $
 
First Name��6S    6g   �� *	FirstName+  5      -   5        lastNameColumn��$	 SizeToHeader 5   =   $
 	Last Name��6R    6e   �� *
LastName+4  .System.Windows.Controls.DataGridTemplateColumn  5      -   5        birthDateColumn��$	 SizeToHeader 5   B   $
 
Birth Date��6W      CellTemplate 5      �� 5      .R�5      (  "System.Windows.Controls.DatePicker     SelectedDate 6)   �� *	BirthDate+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 5      5      5        5   
   -   5        $ moviesDataGrid��5       .   . $��10,186,315,10q�6�   $ VisibleWhenSelected=�6�   $	��284��6�   $
��Left=�6�   ��6f   �� # [  5        5       -   5        movieIdColumn��$
 Movie Id��5    X   $	 SizeToHeader 6j    6<   �� *	MovieId+6j     5!      -	   5        titleColumn��$
 Title��5!   T   $	 SizeToHeader 6c    6:   �� *Title+6c     5"      -
   5        durationColumn��$
 Duration��5"   Z   $	 SizeToHeader 6l    6=   �� *
Duration+6l     5#      -   5        genreColumn��$
 Genre��5#   T   $	 SizeToHeader 6c    6:   �� *Genre+6c     5$      -   5        ageRestrictionColumn��$
 Age Restriction��5$   f   $	 SizeToHeader 6    6C   �� *AgeRestriction+6   5&      �� 5'   
   $	��Id:��6   $
��Left=�6   $��
349,47,0,0q�69   $	��Top=�6M   �� 5(   
   $��First name:��6   $
��Left=�6&   $��
349,78,0,0q�6A   $	��Top=�6U   �� 5)   
   $��
Last name:��6   $
��Left=�6%   $��349,109,0,0q�6@   $	��Top=�6U   �� 5*   
   $��
Birthdate:��6   $
��Left=�6%   $��349,140,0,0q�6@   $	��Top=�6U   �� 5+   
   -   5         ��Name$ ActorId��5+      $
��Left=�6#   $��23��6>   $��
450,51,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��120��6�   �� 5,   
   -   5        $ 	FirstName��5,      $
��Left=�6%   $��23��6@   $��
450,82,0,0q�6L   $
 Wrap=�6`   $	��Top=�6u   $	��120��6�   �� 5-   
   -   5        $ LastName��5-      $
��Left=�6$   $��23��6?   $��450,113,0,0q�6K   $
 Wrap=�6`   $	��Top=�6u   $	��120��6�   �� 5.   
   -   5        $ 	BirthDate��5.      $
��Left=�6%   $��23��6@   $��450,144,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��120��6�   �� 5/   
   -   5         ��Name$ Create��5/      $��Create��6!   $
��Left=�62   $��325,200,0,0q�6M   $	��Top=�6b   $��75��6z   6�   �� 50   
   -   5        $ Update��50      $��Update��6!   $
��Left=�62   $��426,200,0,0q�6M   $	��Top=�6b   $��75��6z   6�   �� 51   
   -   5        $ Delete��51      $��Delete��6!   $
��Left=�62   $��523,200,0,0q�6M   $	��Top=�6b   $��75��6z   6�   �� 52   
   -   5         ��Name$ Message��52      $
��Left=�6"   $��325,280,0,0q�6=   $	��Top=�6R   $	��273��6j   �� 53   
   $��	Id movie:��6   $
��Left=�6$   $��355,221,0,0q�6?   $	��Top=�6T   �� 54   
   -   5        $ MovieId��54      $
��Left=�6#   $��23��6>   $��450,224,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��120��6�   �� 55   
   -   5        $ AddMovie��55      $��	Add movie��6#   $
��Left=�67   $��349,255,0,0q�6R   $	��Top=�6g   $��75��6   6�   �� 56   
   -   5        $ RemoveMovie��56      $��Remove movie��6&   $
��Left=�6=   $��450,255,0,0q�6X   $	��Top=�6m   $��75��6�   6�   58      59      