using Godot;
using System;

public class Block : StaticBody2D
{

	public int special = 2458;
    public override void _Ready()
    {
        
    }
	
	
/*	private void _on_Block_body_entered(object body)
	{
		Ball ball = (Ball)body;
	    if(ball.speed > 50)
		{
			ball.speed = ball.speed + 5;
		}
		this.QueueFree();
	}*/
}



