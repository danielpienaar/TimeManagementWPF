   M S B A M L   `   `   `  ????L  HTimeManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TimeManagementAppTimeManagementApp  5      (    "TimeManagementApp.SemesterDataPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TimeManagementApp     5      -   5          N?Name$  pgSemesterData??5       N? Title$ SemesterDataPage??5	      .??5      ? 
???????.+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
dtgModules??5         AutoGenerateColumns$ False??6'      
IsReadOnly$
 True??6C      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6U      CanUserAddRows$ False??6e      CanUserDeleteRows$ False??6|      CanUserReorderColumns$ False??6?   $??0,0,0,45q?6?   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Code??6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   ?? *Code+  5      $

 Name??6%    63   ?? *Name+  5      $
 Credits??6%    66   ?? *
NumCredits+  5      $
 Weekly Class Hours??6%    6A   ?? *ClassHoursPerWeek+  5         Width$ 2* 6%   $&
  Required Weekly Self-Study Hours??60    6Z   ?? *SelfStudyHoursPerWeek+5      ?? 5   
   -   5         ??Name$ btnViewModule??5      $??View Module??6(   $??16(?6>   $	??120??6L   $
??Left=?6X   $??Bottom=?6s   
??????????	#FFAAABFF???	#FFAAABFF6?   ?? 5   
   -   5        $ btnDeleteModule??5      $??Delete Module??6*   $??	130,0,0,0q?6B   $??16(?6U   $	??120??6c   $
??Left=?6o   $??Bottom=?6?   
??????????	#FFFF9292???	#FFFF92926?   5      5      