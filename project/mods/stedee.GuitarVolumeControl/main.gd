extends Node

const gtr_vol := preload("res://mods/stedee.GuitarVolumeControl/Scenes/gtr_vol.tscn")

# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	var vol_ctl: HBoxContainer = gtr_vol.instance()
	var container = OptionsMenu.get_node("Control/Panel/tabs_main/main/ScrollContainer/HBoxContainer/VBoxContainer")
	container.add_child(vol_ctl)
	container.move_child(vol_ctl, container.get_node("muc_vol").get_index() + 1)
