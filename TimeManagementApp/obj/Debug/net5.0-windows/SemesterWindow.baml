   M S B A M L   `   `   `  ????L  HTimeManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TimeManagementAppTimeManagementApp  5   	   &     TimeManagementApp.SemesterWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TimeManagementApp     5   	   -   5          ?Name$  wndNewSemester??5   	    ? Title$ New Semester??5   	   $	??400??6   $	??300??6+    ? 
ResizeMode$ CanMinimize=?67    ? WindowStartupLocation$ CenterScreen=?6P    ? Topmost$
 True??6u   .??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      $??* ?6   ?? 5      $??2* ?6    ? RowDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??2* ?6   ?? 5      $??* ?6   .+?5   
   ?? -   5         ??Name$ lblSemesterName??5      $??Semester Name:??6)   $??Center=?6B   $??Right=?6]   $??0??6y   $??0??6?   ?? 5   
   -   5         ??Name$ txtSemesterName??5      	 ?? 	MaxLength$	 50??6+   $??	20,0,20,0q?6:   $??20??6M   $??Center=?6Y   $??0??6{   $??1??6?   ?? 5   
   -   5        $ lblNumWeeks??5      $??
Num Weeks:??6%   $??Center=?6:   $??Right=?6U   $??0??6q   $??1??6?   ?? 5   
   -   5        $ txtNumWeeks??5      $	 2??6'   $??	20,0,20,0q?65   $??20??6H   $??Center=?6T   $??1??6?   $??1??6?   ?? 5   
   -   5        $ lblStartDate??5      $??Start Date:??6&   $??Center=?6<   $??Right=?6W   $??0??6s   $??2??6?   (  "System.Windows.Controls.DatePicker  5   
   -   5        
  Name$
 dtpStartDate??5      $??1??6+   $??	20,0,20,0q?6;   $??2??6N   $??Center=?6[   ???	#FFABADB36v   ?? 5   
   -   5        $ 
lblModules??5      $??Modules:??6$   $??0,0,20,0q?67   $??Center=?6I   $??Right=?6d   $??0??6?   $??3??6?   ?? 5    
   -	   5         ??Name$ btnPlusModule??5       $??+??6(   $??Right=?64   $??0,-4,0,0q?6P   $??Center=?6c   $??0??6?   $??3??6?   $??20??6?   $??20??6?   $??0,0,0,25q?6?   
??????????	#FFAAABFF???	#FFAAABFF$??16(?6  6  ?? 5!   
   -
   5        $ btnMinusModule??5!      $??-??6)   $??Right=?65   $??0,-4,0,0q?6Q   $??Center=?6d   $??0??6?   $??3??6?   $??20??6?   $??20??6?   $??0,25,0,0q?6?   
??????????	#FFFF9292???	#FFFF9292$??16(?6  6  ?? 5"   
   -   5         ??Name$ 
lstModules??5"      $??	20,0,20,0q?6&   $??80??69   $??Center=?6E   $??3??6g   $??1??6t   ?? 5$   
   -   5        $ 	btnSubmit??5$      $??Submit??6$   $??	20,0,20,0q?65   $??30??6H   $??1??6T   $??7??6d   
??????????	#FFAAABFF???	#FFAAABFF6?   5%      5&      