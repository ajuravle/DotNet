   M S B A M L   `   `   `  ����I  EWpfApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfApplicationWpfApplication  5      A =DotNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/$clr-namespace:DotNet;assembly=DotNetDotNet 5      #    WpfApplication.TicketsControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WpfApplication     5      7DotNet$clr-namespace:DotNet;assembly=DotNet     5      -   5          � 	Resources  5
         ticketViewSource��%   &	        �� 5   
   6   5      .��5      �  � DataContext# [  6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ticketDataGrid��5         RowDetailsVisibilityMode$ VisibleWhenSelected=�6+   $��10,10,226,10q�6Z      EnableRowVirtualization .    AutoGenerateColumns .  $
��Left=�6�   ��6p   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        ticketIdColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 5   =      Header$ 	Ticket Id��6R   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6e   �� *
TicketId+  5      -   5        cinemaCinemaIdColumn��$ SizeToHeader 5   C   $ Cinema Cinema Id��6X   	 6r   �� *CinemaCinemaId+  5      -   5        movieMovieIdColumn��$ SizeToHeader 5   A   $ Movie Movie Id��6V   	 6n   �� *MovieMovieId+  5      -   5        priceColumn��$ SizeToHeader 5   :   $ Price��6O   	 6^   �� *Price+4  .System.Windows.Controls.DataGridTemplateColumn  5      -   5        dateTimeColumn��$ SizeToHeader 5   A   $ 	Date Time��6V   
   CellTemplate
 5      �� 5      .R�5      (  "System.Windows.Controls.DatePicker     SelectedDate 6)   �� *
DateTime+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 5      5      5      �� 5   
   $	��Id:��6   $
��Left=�6   $��
390,27,0,0q�69   $	��Top=�6M   �� 5    
   $��
Cinema Id:��6   $
��Left=�6%   $��
390,58,0,0q�6@   $	��Top=�6T   �� 5!   
   $��	Movie Id:��6   $
��Left=�6$   $��
390,89,0,0q�6?   $	��Top=�6S   �� 5"   
   $��Price:��6   $
��Left=�6!   $��390,120,0,0q�6<   $	��Top=�6Q   �� 5#   
   $��
Date time:��6   $
��Left=�6%   $��390,151,0,0q�6@   $	��Top=�6U   �� 5$   
   -   5         ��Name$ TicketId��5$      $
��Left=�6$   $��23��6?   $��491,31,-13,0q�6K    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��120��6�   �� 5%   
   -	   5        $ Cinema��5%      $
��Left=�6"   $��23��6=   $��491,62,-13,0q�6I   $
 Wrap=�6_   $	��Top=�6t   $	��120��6�   �� 5&   
   -
   5        $ Movie��5&      $
��Left=�6!   $��23��6<   $��491,93,-13,0q�6H   $
 Wrap=�6^   $	��Top=�6s   $	��120��6�   �� 5'   
   -   5        $ Price��5'      $
��Left=�6!   $��23��6<   $��491,124,-13,0q�6H   $
 Wrap=�6_   $	��Top=�6s   $	��120��6�   �� 5(   
   -   5        $
 Time��5(      $
��Left=�6    $��23��6;   $��491,155,-13,0q�6G   $
 Wrap=�6^   $	��Top=�6r   $	��120��6�   �� 5)   
   -   5         ��Name$ Create��5)      $��Create��6!   $
��Left=�62   $��405,201,0,0q�6M   $	��Top=�6b   $��75��6z   6�   �� 5*   
   -   5        $ Delete��5*      $��Delete��6!   $
��Left=�62   $��515,201,0,0q�6M   $	��Top=�6b   $��75��6z   6�   �� 5+   
   -   5         ��Name$ Message��5+      $
��Left=�6!   $��405,238,0,0q�6<   $	��Top=�6Q   $	��229��6i   $��30��6u   5-      5.      