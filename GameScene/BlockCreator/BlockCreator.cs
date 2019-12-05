using Godot;
using System;

public class BlockCreator : Node2D
{
	
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        MakeBlocks();
    }
	
	public void MakeBlocks()
	{
		for(int j = 0; j < 6; j++)
		{
			for(int i = 0; i < 9; i++)
			{
				var block = ResourceLoader.Load("res://GameScene/Block/Block.tscn") as PackedScene;
				if (block != null)
				{
					var blockInstance = (Block)block.Instance();
					blockInstance.GlobalPosition = new Vector2(96 * i + 128, 60 * j + 64);
    				AddChild(blockInstance);
				}
			}
		}
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
