   M S B A M L   `   `   `  ���� H  DWixard, Version=0.1.6667.19389, Culture=neutral, PublicKeyToken=nullclr-namespace:WixardWixard      Wixard.AppInfo   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     &localclr-namespace:Wixard     .���   � ColumnDefinitions  �� $	��40* ��� $	��60* � � RowDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+�(� $��0��$��2��$��0��.���� $��Application Information��$��Center=�(� $��0��$��2��$
��Left=� (� Stretch$ Uniform=�.���� $��Application Name��(� $��0��$��3��$
��Left=�$ Uniform=�.���� $��Version��(� $��0��$��4��$
��Left=�$ Uniform=�.���� $��Publisher Name��(� $��0��$��5��$
��Left=�$ Uniform=�.���� $��	Help Link��(� $��0��$��6��$
��Left=�$ Uniform=�.���� $��Application Icon��(� $��1��$��2��$
��Left=�$ Uniform=�.���� -    ��Name$ 
txtAppName��$	��160������ *ApplicationName+(� $��1��$��3��$
��Left=�$ Uniform=�.���   �� $	��80* ��� $	��20* �.+��� -   $ txtAppVersion��$��0��$	��140������ *
AppVersion+�� -    ��Name$ btnGetVersion��$��1��$��	From File��(� $��1��$��4��$
��Left=�$ Uniform=�.���� -   $ 
txtPubName��$	��160������ *PublisherName+(� $��1��$��5��$
��Left=�$ Uniform=�.���� -   $ txtHelpLink��$	��160������ *
HelpLink+� $��1��$��6��$��2��  �� $	��70* ��� $	��30* � �� $��* ��� $��* �.+�(� $��0��$��2��.���� -    ��Name$ Appicon������ *IconLocation+ �� UpdateSourceTrigger$ PropertyChanged=�(� $��1��$��0��.���� -   $ btnchangeicon��$
��Find��(� $��1��$��1��.���� -   $ btnRemoveicon��$��Remove��