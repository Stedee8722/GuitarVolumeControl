extends HBoxContainer

func _ready():
	pass

func _on_gtr_vol_value_changed(value):
	OptionsMenu._on_guitar_vol_value_changed(value)


func _on_radio_vol_value_changed(value):
	OptionsMenu._on_radio_vol_value_changed(value)
