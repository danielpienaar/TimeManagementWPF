   M S B A M L   `   `   `  ????L  HTimeManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TimeManagementAppTimeManagementApp  5          TimeManagementApp.App   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      1localclr-namespace:TimeManagementApp     5        ?? 	Resources  5         ScrollThumbs ?? 
TargetType ?? Property ?? Value ?Name ??Name ?? CornerRadius ?? Triggers P? Property	 P? Value
 ?? 
TargetName ?? 
TargetType ]?Name ]? Thumb n?Name ]? IncreaseRepeatButton ??Name J? Opacity ]? DecreaseRepeatButton P? 
SourceName  ButtonSelectBrush  	DarkBrush ?? Angle?? 5   
   %	  &	        '?? H    ?? 5      " n?6)   .?5      ??  ? ?? 5      ?? 5      .R?5      ? $
 Grid??6#   .+?5   "   ?? $??Stretch=?6,   $??Stretch=?6J   $
??Auto??6f   $
??Auto??5   ,   
?????? 6:   ?? 5   "   $ 
Rectangle1??6)   $ 3 3 3 3??6=   $??Stretch=?6T   $??Stretch=?5   )   $??5??6E   $
??Auto??6O   #??z??5   )   5       5      P? 5   "    ?@?Tag$	 
Horizontal??69   . ?5   &   ?? $
 
Rectangle1??6-    ? ??$
 Auto??6V   ?? 5   &   $
 
Rectangle1??6-    ? ??$ 7??6W   5   #   5      5!      5"      ?? 5%      " ??6/   .?5&      ??  ?@??IsFlicksEnabled$ False??6;   ?? 5'       ? ?? ?	#FFFF92926/   ?? 5(       ? ??
 ?????6/   ?? 5)       ? ??$ 10??6*   ?? 5*       ? ?? 5+      ?? 5,      " ??6*   .R?5-      ? $ GridRoot??6#   $??12??65   ??6@   Z? .+?5.   "   ]? $ 
PART_Track??6(   $??0??6<   $
??true??6I   $|?False??6d    5/   &   n? 50   *   $ Thumb??60   #??z??6?   #???   51   0    53   &   ?? 54   *   $ PageUp??67   $??ScrollBar.PageDownCommand??6G   $ 0Q?6k   $|?False??6w    56   &   ?? 57   *   $ PageDown??67   $??ScrollBar.PageUpCommand??6I   $ 0Q?6k   $|?False??6w   59   #   5:       5<      P? 5=   "   $ Thumb??6*    ?@J?IsMouseOver$
	 true??6T   . ?5>   &   ?? # ?  6-   $
 Thumb??5?   -    ? ??6@   5@   #   P? 5A   "   $ Thumb??6*    ?@n?
IsDragging$
	 true??6S   . ?5B   &   ?? # ?  6-   $
 Thumb??6Q    ? ??6d   5C   #   P? 5E   "    ? {?$	 false??6?   . ?5F   &   ?? $
 Thumb??6-    ? y?$ 	Collapsed=?6V   5G   #   P? 5H   "    ?@??Orientation$	 
Horizontal=?6A   . ?5I   &   ?? $
 GridRoot??6-    ?@?LayoutTransform 5J   *   ?? 5K   .   $	 -90Q?6>   5M   '   ?? 5N   &   $
 
PART_Track??6-    ?@?LayoutTransform 5O   *   ?? 5P   .   $	 -90Q?6>   5R   '   ?? 5S   &    ? ??$
 Auto??6>   ?? 5T   &    ? ??$ 12??6?   ?? 5U   &   $
 Thumb??6-    ?@?Tag$ 
Horizontal??6O   ?? 5V   &   $
 PageDown??6-    ? ??$ ScrollBar.PageLeftCommand??6V   ?? 5W   &   $
 PageUp??6-    ? ??$  ScrollBar.PageRightCommand??6T   5X   #   5Z      5\      5]      5^      5a      