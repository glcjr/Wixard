   M S B A M L   `   `   `  ���� H  DWixard, Version=0.1.6667.19389, Culture=neutral, PublicKeyToken=nullclr-namespace:WixardWixard  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem !    Wixard.EnvironmentVarsPanel   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     &localclr-namespace:Wixard     6sys&clr-namespace:System;assembly=mscorlib     .���   � RowDefinitions  �� $	��12* ��� $	��40* ��� $	��60* ��� $	��10* �.+�(� $��0��.���� $��Environment Variables��$��Center=�� -    �Name$ EvarList��$��1�� � ColumnDefinitions �� $	��20* ��� $	��70* ��� $	��30* �.+��� -    ��Name$ 	EvarsList��$��1��$��20(�$��Visible=�����  �� ElementName$ CertList�� �� Path$ ActualHeight����� *	Evarslist+� -   $ EvarListButtons��$��2��  �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+�(� $��1��$��2��.���� -    ��Name$ 
btnAddEvar��$	��Add��$��60��(� $��3��$��2��.���� -   $ 
btnRmvEvar��$��Remove��$��60��� -   $ 
AddNewEvar��$��2�� �� $	��40* ��� $	��60* �  �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+�(� $��0��$��0��.���� $��Name:��(� $��0��$��1��.���� $��
Directory:��(� $��0��$��2��.���� $��
Placement:��(� $��0��$��6��.���� $��
Condition:��(� $��0��$��3��.���� $��Action:��(� $��0��$��4��.���� $��
Permanent:��(� $��0��$��5��.���� $��System:��(� $��1��$��0��.���� $	��160��$
��Left=����� *
EVarName+(� $��1��$��1��.���� $	��160��$
��Left=����� *EVarDirectory+(� $��1��$��2��.���� $	��160��$
��Left=� �� SelectedValue �� *EVarPlacement+.@���all����	first����last��(� $��1��$��6��.���� $	��160��$
��Left=����� *EVarCondition+(� $��1��$��3��.���� $	��160��$
��Left=� �� *
EVarAction+.@���
create����set����
remove��(� $��1��$��4��.����  d� 	IsChecked �� *EvarPermanent+(� $��1��$��5��.����  �� *
EvarSystem+(� $��1��$��8��.���� -   $ btnupdateaddevar��$	��Add��$	��100��	 J� RenderTransformOrigin$	 0.717,0.717&�