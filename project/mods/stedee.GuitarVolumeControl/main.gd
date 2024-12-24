extends Node

const gtr_vol := preload("res://mods/stedee.GuitarVolumeControl/Scenes/gtr_vol.tscn")
const radio_vol := preload("res://mods/stedee.GuitarVolumeControl/Scenes/radio_vol.tscn")

# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	var vol_ctl: HBoxContainer = gtr_vol.instance()
	var radio_ctl: HBoxContainer = radio_vol.instance()
	var container = OptionsMenu.get_node("Control/Panel/tabs_main/main/ScrollContainer/HBoxContainer/VBoxContainer")
	container.add_child(vol_ctl)
	container.add_child(radio_ctl)
	container.move_child(vol_ctl, container.get_node("muc_vol").get_index() + 1)
	container.move_child(radio_ctl, container.get_node("muc_vol").get_index() + 2)
