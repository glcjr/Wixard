   M S B A M L   `   `   `  ���� H  DWixard, Version=0.1.6667.19389, Culture=neutral, PublicKeyToken=nullclr-namespace:WixardWixard      Wixard.EditorPanel   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     &localclr-namespace:Wixard     .���   � RowDefinitions  �� $	��10* ��� $	��80* ��� $	��20* ��� $��5* �.+�] YICSharpCode.AvalonEdit, Version=5.0.3.0, Culture=neutral, PublicKeyToken=9cc39be672370310'  !ICSharpCode.AvalonEdit.TextEditor  ?
avalonEdit.http://icsharpcode.net/sharpdevelop/avalonedit  -   $��
textEditor��   SyntaxHighlightingM  GICSharpCode.AvalonEdit.Highlighting.HighlightingDefinitionTypeConverter$ C# $��Consolas)�$
��10pt(�$��1��   Text.  � ContextMenu �� .@�m�  m� Command$
 Undo��m� $
 Redo���� m� $	 Cut��m� $
 Copy��m� $ Paste��. �� $��0�� �� Orientation$ 
Horizontal=�.+��� -    ��Name$ btnEditorCopy��$	��100��.���� $ 
Horizontal=�.+��� $��Resource\copy.png���� -   $ btnEditorPaste��$	��100��.���� $ 
Horizontal=�.+��� $��Resource\paste.png���� -   $ btnEditorCut��$	��100��.���� $ 
Horizontal=�.+��� $��Resource\cut.png���� -   $ btnEditorSelectAll��$	��100��.���� $ 
Horizontal=�.+��� $��Resource\select.png����  �� TextWrapping$
 Wrap=� �� AcceptsReturn . "	 �� VerticalScrollBarVisibility$
	 Auto=�$��2������ *Compileresult+