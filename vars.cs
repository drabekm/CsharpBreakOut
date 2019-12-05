using Godot;
using System;

public class vars : Node
{
    public int skore = 0;
	public int previousSkore = -1;
	public int lives = 3;
	public int music;
	public int sound;
	public bool fullscreen;
	public bool inGame = false;
    public override void _Ready()
    {
        if(inGame)
		{
			Label liveslbl = (Label)GetNode("/Game/lives");
			Label score = (Label)GetNode("/Game/score");
		}
		
		var settingFile = new File();
		if (settingFile.FileExists("user://settings.dat")) //File exists
		{
			LoadSettings(settingFile);
		}
		else //File doesn't exist -> create a new one
		{
			SaveDefault(settingFile);
		}
		settingFile.Close();
    }
	
	void LoadSettings (File settingFile)
	{
		settingFile.Open("user://settings.dat", 1); //Open with READ flag
		string allData = settingFile.GetAsText();
		string[] data = allData.Split(';');
		music = int.Parse(data[0]);
		sound = int.Parse(data[1]);
		if(data[2] == ('1').ToString())
		{
			OS.WindowFullscreen = true;
			fullscreen = true;
		}
		else
		{
			OS.WindowFullscreen = false;
			fullscreen = false;
		}
		settingFile.Close();
	}
	
	void SaveDefault (File settingFile)
	{
		settingFile.Open("user://settings.dat", 2); //Open with WRITE flag
		//Music value ; Soundfx value ; isFullscreen
		settingFile.StoreString("100;100;0");
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
