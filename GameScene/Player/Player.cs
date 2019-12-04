using Godot;
using System;

public class Player : KinematicBody2D
{
    public int lives = 3;
	
	
    public override void _Ready()
    {
        
    }
	
	public override void _PhysicsProcess(float delta)
	{
		this.SetGlobalPosition(new Vector2(GetViewport().GetMousePosition().x, this.GlobalPosition.y));
		
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
