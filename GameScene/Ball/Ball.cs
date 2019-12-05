using Godot;
using System;


public class Ball : RigidBody2D
{
	const int startSpeed = 250;
    public int speed = startSpeed;
	bool isStarted = false;
	public int skore = 0;
	Vector2 direction = new Vector2(0,0);
	Random rnd = new Random();
	
    public override void _Ready()
    {
		var playerVariables = (vars)GetNode("/root/vars");
		playerVariables.inGame = true; // Instance field.
    }
	
	public void Start()
	{
		if(!isStarted)
		{
			this.GlobalPosition = new Vector2(520, 540);
			isStarted = true;
			double angle = (double)rnd.Next(0,20) - 100.0;
			double rad =  Math.PI * angle / 180.0;
			direction = new Vector2((float)Math.Cos(rad), (float)Math.Sin(rad));
			SetAxisVelocity(direction * speed);
		}
	}

	private void Reset()
	{
		isStarted = false;
		this.SetLinearVelocity(new Vector2(0,0));
		this.GlobalPosition = new Vector2(520, 540);
		var playerVariables = (vars)GetNode("/root/vars");
		playerVariables.lives -= 1; // Instance field.
	}

	public override void _PhysicsProcess(float delta)
	{
		if(this.GlobalPosition.y >  660)
		{
			Reset();
		}
	}
	
	private void _on_Ball_body_entered(object body)
	{
		if(body is Block)
		{
			Block block = (Block)body;
			
			this.speed += 5;
			
			var playerVariables = (vars)GetNode("/root/vars");
			playerVariables.skore += 5; // Instance field.
			
			block.QueueFree();
		}
		else if(body is Player)
		{
			GD.Print("AAAAAAAAAAAAA");
			Player player = (Player)body;
			Vector2 direction = this.GlobalPosition - ((Position2D)player.GetNode("HelpPos")).GlobalPosition;
			Vector2 velocity = direction.Normalized() * speed;
			speed += 5;
			this.SetLinearVelocity(velocity);
		}
	}
}