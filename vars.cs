using Godot;
using System;

public class vars : Node
{
    public int skore = 0;
	public int previousSkore = -1;
	public int lives = 3;
	public int music = 100;
	public int sound = 100;
	public bool fullscreen = false;
	public bool inGame = false;
    public override void _Ready()
    {
        if(inGame)
		{
			Label liveslbl = (Label)GetNode("/Game/lives");
			Label score = (Label)GetNode("/Game/score");
		}
    }
	
	public override void _Process(float delta)
	{
		if(inGame)
		{
			
			Label liveslbl = (Label)GetNode("/root/Game/lives");
			Label score = (Label)GetNode("/root/Game/score");
			var bc = GetNode("/root/Game/BlockCreator");
			if(bc is BlockCreator)
			{
				
				if(skore % 270 == 0 && skore != 0 && skore != previousSkore)
				{
					previousSkore = skore;
					var creator = (BlockCreator)bc;
					creator.MakeBlocks();
				}
			}
			if(lives < 0)
			{
				inGame = false;
				GetTree().ChangeScene("res://GameOverScene/GameOver.tscn");
				return;
			}
			//Zajebanej C#, v godotu to skoro nefunguje. Příště to budu dělat v pythonu
			liveslbl.SetText("x" + lives);
			score.SetText("Score: " + skore);
		}
	}

	
}
