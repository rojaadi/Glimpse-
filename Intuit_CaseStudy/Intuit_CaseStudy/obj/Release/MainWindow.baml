   M S B A M L   `   `   `  ���� W  SIntuit_CaseStudy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b4fe802dfadc43d13clr-namespace:Intuit_CaseStudyIntuit_CaseStudy  !    Intuit_CaseStudy.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:Intuit_CaseStudy       � Title$  Glimpse��$��Georgia Pro Black)�$��DemiBold"�$	��450��$	��800�� J� SnapsToDevicePixels . ����  �� ImageSource$" /Resources/GlimpseGalaxy.JPG�� j� Stretch$
 Fill=� �� Opacity$
 0.85Q� � 	Resources  �� DataType   Intuit_CaseStudy.ItemType �� UpdateSourceTrigger �� Mode��%�   (��       *, +)�� "  .R��� .+��� $��UniformToFill=�$	��Top=�$��Center=����� *	OpenClose+$ PropertyChanged=�$ TwoWay=�.��� 	 � RowDefinitions	 �� $	��100 ��� $
��auto ��� $	��100 ��� $��* ��� $	��100 �+��� $��0��$��Glimpse Search��$��Matura MT Script Capitals)�$
��Bold"�$��10,10,10,10q�$��Normal$�
�������$��30(�$��Center=�$��Bottom=��� $��1��
�������$��0��$��1q�$��10,10,10,10q�
 �� CornerRadius$
 6��$��Center=�$	��Top=�._�� $��25�� � ColumnDefinitions �� $��* ��� $��* �.+��� $��0��$��0��$	��450��
������ $��0q�$��Center=�
�������$��Arial)�$��16(�����  �� Path$ SearchString�$ TwoWay=�.�� J� InputBindings �� 
 �� Key$ Enter�� �� Command �� *SearchButtonCommand+.���� $��0��$��1�� . 
������ $��0q����� *SearchButtonCommand+.���� $��/Resources/search.ico��$
��auto���� $��2��$��1q�$
 15��$
��auto��
������ |�.  ._�� 	 �� $��30 ��� $��* �.+��� $��0��$��Georgia Pro Black)�
�������$��14(�$��Bottom=�$��Center=����� *	TweetsFor+�� $��1��
������ $��0q�|�.  ���� *
TweetIDS+$ PropertyChanged=����� .R���  �� Orientation$ 
Horizontal=�$��Center=�$��Center=����� .R��� 
������ $��0q�|�.  .@��  �� �� .+��� $��0��$��/Resources/twitter.ico��$��30��|�.  $
��auto���� $��1��|�.  
�������
������ ���� �� $��3��$��1q�$
 15��$
��auto��
������ ._�� 	 �� $��65 ��� $��* �.+��� $��0��
�������$��20(�$��Center=����� *	ImagesFor+�� $��1��
������ ���� *Images+$ PropertyChanged=����� .R�A�  A� Columns$ 5������ .R��� $
��auto��$��	0,-2,0,-2q�$��UniformToFill=�$��Center=�$	��Top=�����  � ToolTip _�  �� ContentStringFormat$ Ping: {0}ms�� � DataContext �� *PlacementTarget+ �� RelativeSource �� *Self+.���� 
���   �$��1q�$��5,7,5,5q�._��� $��Uniform=�$	��500��$
��auto������ *Source+� $��4��$��10,10,10,10q�$��Bottom=�$��Center=� �� $	��500 ��� $	��100 ��� $
��auto �.+��� $��0��$��Center=�$��Bembo)�$1��+Glimpse Search © 2021. All Rights Reserved��
��������� $��1��$��Center=��� $��Bembo)�
������� �� Command �� *RequestFlickrPage+.�Flickr�� $��2��$��Center=��� $��Bembo)�
������� �� *RequestTwitterPage+.�	Twitter