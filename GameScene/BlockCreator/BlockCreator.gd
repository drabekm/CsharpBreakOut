extends Node2D

var block = preload("res://GameScene/Block/Block.tscn");
# Called when the node enters the scene tree for the first time.
func _ready():
	MakeBlocks()
	

func MakeBlocks():
	for j in range(6):
		for i in range(9):
			var block_instance = block.instance()
			block_instance.global_position = Vector2(96 * i + 128, 60 * j + 64)
			add_child(block_instance)