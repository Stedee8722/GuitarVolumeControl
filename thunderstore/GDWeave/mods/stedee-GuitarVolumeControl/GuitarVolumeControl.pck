GDPC                                                                            	       res://Assets/Themes/main.tres   0              ��ُ ��	���B~4   res://Scenes/Menus/Main Menu/ui_generic_button.gd   0              ��ُ ��	���B~   res://icon.png  �      �      G1?��z�c��vN��@   res://mods/stedee.GuitarVolumeControl/Scenes/gtr_vol.gd.remap   0      I       [����'�f����x�>C8   res://mods/stedee.GuitarVolumeControl/Scenes/gtr_vol.gdc0      o      ����.�)7�b��ŝ�<   res://mods/stedee.GuitarVolumeControl/Scenes/gtr_vol.tscn   �      �      A��6�1oG���04   res://mods/stedee.GuitarVolumeControl/main.gd.remap �      ?       ;wB������nqM,��0   res://mods/stedee.GuitarVolumeControl/main.gdc  �	      �      �U$��#���7����   res://project.binary�      ?      ��J�����cq7h    GDSC             '      ������������Ķ��   �����϶�   ������������������������Ҷ��   ����Ӷ��   ����������ö    ���������������������������Ҷ���                                                 	   	   
   
                           !      "      #      $      %      3YYYYYYYYY0�  PQV�  -YY0�  P�  QV�  �  T�  P�  QYYYYY` [gd_scene load_steps=4 format=2]

[ext_resource path="res://Assets/Themes/main.tres" type="Theme" id=1]
[ext_resource path="res://Scenes/Menus/Main Menu/ui_generic_button.gd" type="Script" id=2]
[ext_resource path="res://mods/stedee.GuitarVolumeControl/Scenes/gtr_vol.gd" type="Script" id=3]

[node name="gtr_vol" type="HBoxContainer"]
margin_right = 40.0
margin_bottom = 40.0
script = ExtResource( 3 )

[node name="Label" type="Label" parent="."]
margin_top = 13.0
margin_right = 162.0
margin_bottom = 47.0
size_flags_horizontal = 3
theme = ExtResource( 1 )
text = "Guitar Volume: "

[node name="VBoxContainer" type="VBoxContainer" parent="."]
margin_left = 166.0
margin_right = 218.0
margin_bottom = 60.0
size_flags_horizontal = 3
size_flags_vertical = 3
theme = ExtResource( 1 )
custom_constants/separation = -6

[node name="gtr_label" type="Label" parent="VBoxContainer"]
margin_right = 52.0
margin_bottom = 34.0
text = "100%"
align = 2

[node name="gtr_vol" type="HSlider" parent="VBoxContainer"]
margin_top = 28.0
margin_right = 52.0
margin_bottom = 60.0
size_flags_horizontal = 3
size_flags_vertical = 2
max_value = 2.0
step = 0.01
script = ExtResource( 2 )

[connection signal="value_changed" from="VBoxContainer/gtr_vol" to="." method="_on_gtr_vol_value_changed"]
       GDSC            K      ���Ӷ���   ������ڶ   �����϶�   ������ڶ   ������������Ķ��   �������Ӷ���   ��������Ķ��   ����������ö   �������Ӷ���   ��������Ҷ��   ���������Ҷ�   ��������ζ��   9   res://mods/stedee.GuitarVolumeControl/Scenes/gtr_vol.tscn      H   Control/Panel/tabs_main/main/ScrollContainer/HBoxContainer/VBoxContainer      muc_vol                                                           	      
               $      .      5      I      3YY:�  V?PQYYYYYYYY0�  PQV�  ;�  V�  �  T�  PQ�  ;�  �  T�  P�  Q�  �  T�	  P�  Q�  �  T�
  P�  R�  T�  P�  QT�  PQ�  QY`  [remap]

path="res://mods/stedee.GuitarVolumeControl/Scenes/gtr_vol.gdc"
       [remap]

path="res://mods/stedee.GuitarVolumeControl/main.gdc"
 �PNG

   IHDR   @   @   �iq�   sRGB ���  �IDATx��ytTU��?�ի%���@ȞY1JZ �iA�i�[P��e��c;�.`Ow+4�>�(}z�EF�Dm�:�h��IHHB�BR!{%�Zߛ?��	U�T�
���:��]~�������-�	Ì�{q*�h$e-
�)��'�d�b(��.�B�6��J�ĩ=;���Cv�j��E~Z��+��CQ�AA�����;�.�	�^P	���ARkUjQ�b�,#;�8�6��P~,� �0�h%*QzE� �"��T��
�=1p:lX�Pd�Y���(:g����kZx ��A���띊3G�Di� !�6����A҆ @�$JkD�$��/�nYE��< Q���<]V�5O!���>2<��f��8�I��8��f:a�|+�/�l9�DEp�-�t]9)C�o��M~�k��tw�r������w��|r�Ξ�	�S�)^� ��c�eg$�vE17ϟ�(�|���Ѧ*����
����^���uD�̴D����h�����R��O�bv�Y����j^�SN֝
������PP���������Y>����&�P��.3+�$��ݷ�����{n����_5c�99�fbסF&�k�mv���bN�T���F���A�9�
(.�'*"��[��c�{ԛmNު8���3�~V� az
�沵�f�sD��&+[���ke3o>r��������T�]����* ���f�~nX�Ȉ���w+�G���F�,U�� D�Դ0赍�!�B�q�c�(
ܱ��f�yT�:��1�� +����C|��-�T��D�M��\|�K�j��<yJ, ����n��1.FZ�d$I0݀8]��Jn_� ���j~����ցV���������1@M�)`F�BM����^x�>
����`��I�˿��wΛ	����W[�����v��E�����u��~��{R�(����3���������y����C��!��nHe�T�Z�����K�P`ǁF´�nH啝���=>id,�>�GW-糓F������m<P8�{o[D����w�Q��=N}�!+�����-�<{[���������w�u�L�����4�����Uc�s��F�륟��c�g�u�s��N��lu���}ן($D��ת8m�Q�V	l�;��(��ڌ���k�
s\��JDIͦOzp��مh����T���IDI���W�Iǧ�X���g��O��a�\:���>����g���%|����i)	�v��]u.�^�:Gk��i)	>��T@k{'	=�������@a�$zZ�;}�󩀒��T�6�Xq&1aWO�,&L�cřT�4P���g[�
p�2��~;� ��Ҭ�29�xri� ��?��)��_��@s[��^�ܴhnɝ4&'
��NanZ4��^Js[ǘ��2���x?Oܷ�$��3�$r����Q��1@�����~��Y�Qܑ�Hjl(}�v�4vSr�iT�1���f������(���A�ᥕ�$� X,�3'�0s����×ƺk~2~'�[�ё�&F�8{2O�y�n�-`^/FPB�?.�N�AO]]�� �n]β[�SR�kN%;>�k��5������]8������=p����Ցh������`}�
�J�8-��ʺ����� �fl˫[8�?E9q�2&������p��<�r�8x� [^݂��2�X��z�V+7N����V@j�A����hl��/+/'5�3�?;9
�(�Ef'Gyҍ���̣�h4RSS� ����������j�Z��jI��x��dE-y�a�X�/�����:��� +k�� �"˖/���+`��],[��UVV4u��P �˻�AA`��)*ZB\\��9lܸ�]{N��礑]6�Hnnqqq-a��Qxy�7�`=8A�Sm&�Q�����u�0hsPz����yJt�[�>�/ޫ�il�����.��ǳ���9��
_
��<s���wT�S������;F����-{k�����T�Z^���z�!t�۰؝^�^*���؝c
���;��7]h^
��PA��+@��gA*+�K��ˌ�)S�1��(Ե��ǯ�h����õ�M�`��p�cC�T")�z�j�w��V��@��D��N�^M\����m�zY��C�Ҙ�I����N�Ϭ��{�9�)����o���C���h�����ʆ.��׏(�ҫ���@�Tf%yZt���wg�4s�]f�q뗣�ǆi�l�⵲3t��I���O��v;Z�g��l��l��kAJѩU^wj�(��������{���)�9�T���KrE�V!�D���aw���x[�I��tZ�0Y �%E�͹���n�G�P�"5FӨ��M�K�!>R���$�.x����h=gϝ�K&@-F��=}�=�����5���s �CFwa���8��u?_����D#���x:R!5&��_�]���*�O��;�)Ȉ�@�g�����ou�Q�v���J�G�6�P�������7��-���	պ^#�C�S��[]3��1���IY��.Ȉ!6\K�:��?9�Ev��S]�l;��?/� ��5�p�X��f�1�;5�S�ye��Ƅ���,Da�>�� O.�AJL(���pL�C5ij޿hBƾ���ڎ�)s��9$D�p���I��e�,ə�+;?�t��v�p�-��&����	V���x���yuo-G&8->�xt�t������Rv��Y�4ZnT�4P]�HA�4�a�T�ǅ1`u\�,���hZ����S������o翿���{�릨ZRq��Y��fat�[����[z9��4�U�V��Anb$Kg������]������8�M0(WeU�H�\n_��¹�C�F�F�}����8d�N��.��]���u�,%Z�F-���E�'����q�L�\������=H�W'�L{�BP0Z���Y�̞���DE��I�N7���c��S���7�Xm�/`�	�+`����X_��KI��^��F\�aD�����~�+M����ㅤ��	SY��/�.�`���:�9Q�c �38K�j�0Y�D�8����W;ܲ�pTt��6P,� Nǵ��Æ�:(���&�N�/ X��i%�?�_P	�n�F�.^�G�E���鬫>?���"@v�2���A~�aԹ_[P, n��N������_rƢ��    IEND�B`�       ECFG      application/config/name         GuitarVolumeControl    application/config/icon         res://icon.png  +   gui/common/drop_mouse_on_gui_input_disabled         )   physics/common/enable_pause_aware_picking         )   rendering/environment/default_environment          res://default_env.tres   