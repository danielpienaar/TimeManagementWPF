   M S B A M L   `   `   `  ????L  HTimeManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TimeManagementAppTimeManagementApp  5      &     TimeManagementApp.ModuleDataPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TimeManagementApp     5      -   5          N?Name$  pgModuleData??5       N? Title$ ModuleDataPage??5	      .??5      ? 
??????? ? ColumnDefinitions 5   
   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      $??* ?6   ?? 5      -   5         ??Name$ DataRow??5      $??3* ?6-   .+?5   
   ?? -   5         ??Name$ lblHoursWorked??5      $??Enter Hours Worked:??6(   $??Center=?6F   $??Center=?6a   $??0,0,0,40q?6~   ?? 5   
   -   5         ??Name$ stkInput??5       ?? Orientation$ 
Horizontal=?6'   $??0??6@   $??35??6M   $??Center=?6Y   $??Bottom=?6v   $??0,0,0,20q?6?   .+?5      ?? -   5         ??Name$ chkToday??5      $??Today??6)   $??Center=?6s   $??24??6?   $??5q?6?   $??Center=?6?   (  "System.Windows.Controls.DatePicker  5      -   5        	  Name$	 dtpHoursWorked??5      $??Center=?61   $??24??6L   $??5q?6X   ?? 5      -   5        
 ??Name$
 txtHoursWorked??5       ?? TextWrapping$
 Wrap=?6R   $	??120??6f   $??24??6r   $??5q?6~   $??Center=?6?   $??Center=?6?   ?? 5      -   5         ??Name$ 
btnConfirm??5      $??Confirm??6)   $??24??6;   $??Center=?6G   $??5q?6b   6m   5      ?? 5   
   -	   5         ??Name$ brdData??5      $	??300??6"   $	??225??6.   $	??Top=?6;   ???	#FFFFAAAA$??2q?6k    ?? CornerRadius$ 8??6   $??1??6?   $??0,0,0,18q?6?   ._?5      ? $	??300??6   .+?5       ?? $
??Auto=?6   $??10, 0, 10, 0q?6B   .??5!      ?? -
   5         ??Name$ txbModuleData??5!       $
??Wrap=?67   $?? ??6K    ?? TextAlignment$ Justify=?6S   6m   5"      5#      5$      ?? 5%   
   -   5        $ btnViewSemester??5%      $??View Semester??6*   $??16(?6B   $	??120??6P   $
??Left=?6\   $??Bottom=?6w   $??1??6?   
??????????	#FFFF9292???	#FFFF92926?   5'      5(      