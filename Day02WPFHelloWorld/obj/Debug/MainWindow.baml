   M S B A M L   `   `   `  ????M  IDay02WPFHelloWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Day02WPFHelloWorldDay02WPFHelloWorld  5   	   #    Day02WPFHelloWorld.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Day02WPFHelloWorld     5   	     ? 
ResizeMode$  NoResize=?5       ? Title$ 
MainWindow??5   	   $	??150??6   $	??304??6)   .??5	      ? .+?5
   
   ?? $??What is your name???6   $
??Left=?6-   $??	10,10,0,0q?6H   $	??Top=?6[   $	??107??6t   $??11(?6?   ?? 5   
   -   5         ??Name$ TbxName??5      $
??Left=?6#   $??
152,13,0,0q?6>    ?? TextWrapping$
 Wrap=?6R   $?? ??6f   $	??Top=?6n   $	??109??6?    J? RenderTransformOrigin$ 0.133,-2.283&?6?   ?? 5   
   -   5        $??Say Hello (label)??5      $
??Left=?6-   $??	19,47,0,0q?6H   $	??Top=?6[   6s   ?? 5   
   -   5        $??Say Hello (msg box)??5      $
??Left=?6/   $??
152,47,0,0q?6J   $	??Top=?6^   $ 0.478,0.603&?6v   6?   ?? 5   
   -   5         ??Name$ LblGreeting??5      $	??...??6%   $
??Left=?63   $??	19,87,0,0q?6N   $	??Top=?6a   $	??251??6y   5      5      