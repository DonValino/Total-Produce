   M S B A M L   `   `   `  ����@  <DonTP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DonTP.ViewModelsDonTP.ViewModels  5   P       DonTP.Views.AddCarView   5      a ]DevExpress.Xpf.Core.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  6Q   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ] YDevExpress.Mvvm.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   5      1
ViewModelsclr-namespace:DonTP.ViewModels   6P   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5        � DataContext  5	      1  +DevExpress.Mvvm.UI.ViewModelSourceExtension     Type&    DonTP.ViewModels.AddCarViewModel"  2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   	Behaviors 5      -  'DevExpress.Xpf.Core.DXMessageBoxService  5   
   -  'DevExpress.Mvvm.UI.CurrentWindowService  5   
   .��5      �� .+�5   
   (  "DevExpress.Xpf.Bars.ToolBarControl  $��Stretch=�6   $��30��69   ,  &DevExpress.Xpf.Bars.ToolBarControlBase   Items. 5      '  !DevExpress.Xpf.Bars.BarButtonItem  !	  DevExpress.Xpf.Bars.BarItem 	  Content)
  #DevExpress.Xpf.Core.ObjectConverter$
 Save
 6     	  Command 6/   �� *SaveCommand+  5      $ Cancel
 6     61   �� *RevertCommand+5      �� 5   
   -   5         ��Name$ 	Makelabel��5      $
��Make��6#   %  DevExpress.Xpf.Editors.TextEdit  5   
   )  #DevExpress.Xpf.Editors.TextEditBase   Text 6   �� *Make+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   -   5        $ 
Modellabel��5      $��Model��6$     5   
    6   �� *Model+$ PropertyChanged=��� 5   
   -   5        $ 	Yearlabel��5      $
��Year��6#     5   
    6   �� *Year+$ PropertyChanged=��� 5   
   -   5        $ Mileagelabel��5      $��Mileage��6&     5   
    6   �� *	Mileage+$ PropertyChanged=��� 5   
   -   5        $ 
Pricelabel��5      $��Price��6$     5   
    6   �� *Price+$ PropertyChanged=�5!      5"      