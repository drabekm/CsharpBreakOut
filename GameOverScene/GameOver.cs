using Godot;
using System;

public class GameOver : Control
{
    
	Label skoreLbl;
	AnimationPlayer ap;
    public override void _Ready()
    {
        skoreLbl = (Label)GetNode("VBoxContainer/Score");
		ap = (AnimationPlayer)GetNode("ColorRect/AnimationPlayer");
		ap.Play("FadeIn");
		var vars = (vars)GetNode("/root/vars");
		skoreLbl.SetText("Your score was: " + vars.skore);
    }
	
	private void _on_Button_pressed()
	{
		ap.Play("FadeOut");
	}
	
	private void _on_AnimationPlayer_animation_finished(String anim_name)
	{
		GD.Print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
		    if(anim_name == "FadeOut")
			{
				LineEdit input = (LineEdit)GetNode("VBoxContainer/CenterContainer/VBoxContainer/input");
				var vars = (vars)GetNode("/root/vars");
				
				LoadScore(vars.skore, input.Text);
				
			}
	}
	
	private void LoadScore(int newScore, string name)
	{
		File scoreFile = new File();
		scoreFile.Open("user://score.dat", 1); //open with READ flag
		string allData = scoreFile.GetAsText();
		string[] pairs = allData.Split(";"); // Creates pairs name:score
		int[] scores = new int[10];
		int index = -1;
		for(int i = 0; i < 10; i++)
		{
			var str = (pairs[i].Split(':'))[1];
			var charsToRemove = new string[] { ":", ",", ".", ";", "'" };
			foreach (var c in charsToRemove)
			{
    			str = str.Replace(c, string.Empty);
			}
			scores[i] = int.Parse(str); 
			GD.Print(scores[i]);
		}
		scoreFile.Close();
		
		for(int i = 0; i < 10; i++)
		{
			if(newScore > scores[i])
			{
				index = i;
				break;
			}
		}
		
		scoreFile.Open("user://score.dat", 3);
		for(int i = 0; i < 10; i++)
		{
			if(i == index)
			{
				scoreFile.StoreString(name + ":" + newScore + ";");
			}
			else
				scoreFile.StoreString(pairs[i] + ";");
		}
		scoreFile.Close();
		GetTree().ChangeScene("res://MainMenu/MainMenu.tscn");
	}
}






