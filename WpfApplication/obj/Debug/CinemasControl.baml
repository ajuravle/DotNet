   M S B A M L   `   `   `  ����I  EWpfApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfApplicationWpfApplication  5      A =DotNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/$clr-namespace:DotNet;assembly=DotNetDotNet 5      #    WpfApplication.CinemasControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WpfApplication     5      7DotNet$clr-namespace:DotNet;assembly=DotNet     5      -   5          � 	Resources  5
         cinemaViewSource��%   &	        �� 5   
   6   5      .��5      �  � DataContext# [  6   $��	0,0,-82,0q�6;   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ cinemaDataGrid��5         AutoGenerateColumns .     EnableRowVirtualization . $��
10,10,0,10q�6~      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   $
��Left=�6�   $	��259��6�   ��6f   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        cinemaIdColumn��,  &System.Windows.Controls.DataGridColumn   Header$ 	Cinema Id��5   Z      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6m   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6=   �� *
CinemaId+6m     5      -   5        
nameColumn��$
 Name��5   R   $ SizeToHeader 6`   	 69   �� *Name+6`     5      -   5        
cityColumn��$
 City��5   R   $ SizeToHeader 6`   	 69   �� *City+6`     5      -   5        addressColumn��$ Address��5   X   $ SizeToHeader 6i   	 6<   �� *	Address+6i     5      -   5        nrRoomsColumn��$ Nr Rooms��5   X   $ SizeToHeader 6j   	 6<   �� *	NrRooms+6j   5      �� 5   
   $	��Id:��6   $
��Left=�6   $��
370,16,0,0q�69   $	��Top=�6M   �� 5   
   $��Name:��6   $
��Left=�6    $��
370,47,0,0q�6;   $	��Top=�6O   �� 5   
   $��City:��6   $
��Left=�6    $��
370,78,0,0q�6;   $	��Top=�6O   �� 5   
   $��Address:��6   $
��Left=�6#   $��370,109,0,0q�6>   $	��Top=�6S   �� 5   
   $��
Nr. rooms:��6   $
��Left=�6%   $��370,140,0,0q�6@   $	��Top=�6U   �� 5   
   -   5        
 ��Name$
 CinemaID��5      $
��Left=�6$   $��23��6?   $��
471,20,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��120��6�   �� 5   
   -	   5        $

 Name��5      $
��Left=�6    $��23��6;   $��
471,51,0,0q�6G   $
 Wrap=�6[   $	��Top=�6p   $	��120��6�   �� 5   
   -
   5        $

 City��5      $
��Left=�6    $��23��6;   $��
471,82,0,0q�6G   $
 Wrap=�6[   $	��Top=�6p   $	��120��6�   �� 5   
   -   5        $
 Address��5      $
��Left=�6#   $��23��6>   $��471,113,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��120��6�   �� 5    
   -   5        $
 NrRooms��5       $
��Left=�6#   $��23��6>   $��471,144,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��120��6�   �� 5!   
   -   5         ��Name$ Create��5!      $��Create��6!   $
��Left=�62   $��341,190,0,0q�6M   $	��Top=�6b   $��75��6z   6�   �� 5"   
   -   5        $ Update��5"      $��Update��6!   $
��Left=�62   $��442,190,0,0q�6M   $	��Top=�6b   $��75��6z   6�   �� 5#   
   -   5        $ Delete��5#      $��Delete��6!   $
��Left=�62   $��539,190,0,0q�6M   $	��Top=�6b   $��75��6z   6�   �� 5$   
   -   5         ��Name$ Message��5$      $
��Left=�6"   $��341,231,0,0q�6=   $	��Top=�6R   $	��273��6j   5%      5&      