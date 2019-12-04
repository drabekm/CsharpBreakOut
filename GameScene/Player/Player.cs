using Godot;
using System;

public class Player : KinematicBody2D
{
    public int lives = 3;
	Ball ball;
	
    public override void _Ready()
    {
        ball = (Ball)GetParent().GetNode("Ball");
    }
	
	public override void _PhysicsProcess(float delta)
	{
		this.SetGlobalPosition(new Vector2(GetViewport().GetMousePosition().x, this.GlobalPosition.y));
		if (Input.IsActionPressed("left_click"))
    	{
        	ball.Start();
			GD.Print("AAA");
    	}
	}

}
