   M S B A M L   `   `   `  ????L  HTimeManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TimeManagementAppTimeManagementApp  5   	   "    TimeManagementApp.InfoWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TimeManagementApp     5   	   -   5          ?Name$  wndInfoWindow??5   	    ? Title$ Time Manager??5   	   $	??450??6   $	??800??6+    ? 
ResizeMode$ CanMinimize=?67    ? WindowStartupLocation$ CenterScreen=?6P   .??5
      ? $??
20,0,20,20q?6    ? ColumnDefinitions 5   
   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??5* ?6   .+?5   
   ?? -   5         ??Name$ 	lblHeader??5      $??Semester Name??6#   $??Center=?6;   $??Center=?6X   $??24(?6s   $??Normal"?6?   ???	#FFAAABFF6?   ?? 5   
   -   5        $ lblDate??5      $
??Date??6!   $
??Left=?60   $??Center=?6K   $??18(?6f   $??Normal"?6t   ???	#FFAAABFF6?   ?? 5   
   -   5         ??Name$ btnBack??5      $
??Back??6"   $??16(?61   $??40??6?   $??Right=?6J   $??Center=?6f   
??????????	#FFFF9292???	#FFFF92926?   ?? 5   
   -   5        $ btnAddModule??5      $??
New Module??6'   $??16(?6<   $	??110??6K   $??Right=?6W   $??Center=?6s   
??????????	#FFAAABFF???	#FFAAABFF$??0,0,50,0q?6?   6?    ? 5   
   -   5          ?Name$ 	DataFrame??5      	  ? NavigationUIVisibility$	 Hidden=?6#   $??1??6C   ???	#FF4A98FF6P   5      5      