   M S B A M L   `   `   `  ????P  LUpload_videos_demoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Upload_videos_demoAppUpload_videos_demoApp  5   	   &     Upload_videos_demoApp.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Upload_videos_demoApp     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)   .??5	      ? .+?5
   
   ?? .+?5      ?? $	??300??6   $??20??6$   64Type http address into texbox below then press enter5      ?? 5      -   5        $??httpAddress??5   M   $??http://localhost:8787/??6   $	??300??65   $??30??6A   6`   ?? 5      -   5        $??
textBlock1??5   0   $	??451??6   $??24??6$   60   5      ? 5   
   -   5         ?Name$ previous??5      $
??Left=?6!   $	??249??6<   $??129,175,0,0q?6I   $	??Top=?6^   $	??563??6v   .+?5      ?? -   5        $??	txtEditor??5      ?? 5      
???   ?$??1q?6)   $??Center=?6=   $	??249??6Z   $??Center=?6g   $	??563??6?   5      ? 5   
   -   5        $ upload1??5      $
??Left=?6    $??56??6;   $??
129,77,0,0q?6G   $	??Top=?6[   $	??563??6s   .+?5      ? -   5         ?Name$ uploadProgress??5      $??92,22,96,21q?63    J? Opacity$	 0.3Q?6H    ? SmallChange$	 0.1Q?6V   ?? 5      -   5         ??Name$ btnOpenFile_Click??5      $??Choose file??6K   $
??Left=?6a   $??36??6|   $??10,0,0,0q?6?   $??Center=?6?   $??72??6?   $
??Bold"?6?   
??????????	#FFD9D9D96?   ?? 5      -   5        $ btnSubmit_Click??5      $??Submit??6H   $??Right=?6Y   $??36??6u   $??10,0,0,0q?6?   $??Center=?6?   $??72??6?   $
??Bold"?6?   
??????????	#FFD9D9D96?   ?? 5      
???   ?$??1q?6)   $??Center=?6=   $??56??6Z   $??Center=?6f   $	??563??6?   ._?5      ?? -	   5         ??Name$ filePath??5      $
??Left=?6,   $??22??6G   $??	89,17,0,0q?6S    ?? TextWrapping$
 Wrap=?6f   $	??...??6z   $	??Top=?6?   $	??380??6?   $	 0.5Q?6?   5      5       (? 5!   
   5#      5$      