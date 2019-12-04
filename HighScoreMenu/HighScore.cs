using Godot;
using System;
using System.Collections.Generic;

public class HighScore : Control
{
	const int maxLines = 10;
    Label[] scoreLines = new Label[maxLines];
	AnimationPlayer ap;
	//Gets nodes where the scores will be written
	private void GetScoreLines()
	{
		var children = GetNode("VBoxContainer/ScoreLines").GetChildren();
		ap = (AnimationPlayer)GetNode("ColorRect/AnimationPlayer");
		ap.Play("FadeIn");
		int i = 0;
		foreach(var child in children)
		{
			scoreLines[i] = (Label)child;
			i++;
		}
	}

	//Puts data stored in score.dat into label nodes in a scene
	private void LoadScores(File scoreFile)
	{
		scoreFile.Open("user://score.dat", 1); //open with READ flag
		string allData = scoreFile.GetAsText();
		string[] pairs = allData.Split(";"); // Creates pairs name:score
		for(int i = 0; i < maxLines; i++)
		{
			scoreLines[i].Text = pairs[i]; 
		}
	}

    //Creates a new save file with default values
	private void SaveEmptyScores(File scoreFile)
	{
		scoreFile.Open("user://score.dat", 2); //Open with WRITE flag
			
			for(int i = 0; i < maxLines; i++) //Saves an empty score list
			{   //All data is stored as NAME : SCORE ; NAME2 : SCORE2 ; ...
				scoreFile.StoreString("JohnDoe" + i + " : " + 0+";");
			}
	}

    public override void _Ready()
    {
    	GetScoreLines();    
		var scoreFile = new File();
		if (scoreFile.FileExists("user://score.dat")) //File exists
		{
			LoadScores(scoreFile);
		}
		else //File doesn't exist -> create a new one
		{
			SaveEmptyScores(scoreFile);
		}
		scoreFile.Close();
    }


	private void _on_ExitBtn_pressed()
	{
	    ap.Play("FadeOut");
	}


	private void _on_AnimationPlayer_animation_finished(String anim_name)
	{
	    if(anim_name == "FadeOut")
		{
			GetTree().ChangeScene("res://MainMenu/MainMenu.tscn");
		}
	}
}