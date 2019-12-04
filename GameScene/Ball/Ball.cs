using Godot;
using System;

public class Ball : RigidBody2D
{
	const int startSpeed = 250;
    public int speed = startSpeed;
	bool isStarted = false;
	
	Vector2 direction = new Vector2(0,0);
	Random rnd = new Random();
	
    public override void _Ready()
    {
    }
	
	public void Start()
	{
		if(!isStarted)
		{
			this.GlobalPosition = new Vector2(520, 540);
			isStarted = true;
			int angle = rnd.Next(30,150);
			direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
			SetAxisVelocity(direction * speed);
		}
	}

	private void Reset()
	{
		isStarted = false;
		this.SetLinearVelocity(new Vector2(0,0));
		this.GlobalPosition = new Vector2(520, 540);
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
			block.QueueFree();
			this.speed += 5;
			SetAxisVelocity(direction * speed);
		}
	}
}