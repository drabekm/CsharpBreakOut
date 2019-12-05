using Godot;
using System;

public class Settings : Control
{
    AnimationPlayer ap;
	HSlider music, sound;
	CheckButton fullscreen;
    public override void _Ready()
    {
        ap = (AnimationPlayer)GetNode("ColorRect/AnimationPlayer");
		music = (HSlider)GetNode("VBoxContainer/HBoxContainer2/Music");
		sound = (HSlider)GetNode("VBoxContainer/HBoxContainer/Sound");
		fullscreen = (CheckButton)GetNode("VBoxContainer/CenterContainer/FullScreenBtn");
		var settingFile = new File();
		settingFile.Open("user://settings.dat", 1); //Open with WRITE flag
		//Music value ; Soundfx value ; isFullscreen
		string allData = settingFile.GetAsText();
		string[] data = allData.Split(';');
		GD.Print(data[0]);
		GD.Print(data[1]);
		GD.Print(data[2]);
		music.Value = int.Parse(data[0]);
		sound.Value = int.Parse(data[1]);
		if(data[2] == "1")
		{
			fullscreen.Pressed = true;
		}
		else
		{
			fullscreen.Pressed = false;
		}
		
		ap.Play("FadeIn");
    }

	private void _on_Button_pressed()
	{
		var settingFile = new File();
		settingFile.Open("user://settings.dat", 3); //Open with WRITE flag
		//Music value ; Soundfx value ; isFullscreen
		GD.Print(music.Value);
		GD.Print(sound.Value);
		GD.Print(fullscreen.Pressed);
		if(fullscreen.Pressed)
			settingFile.StoreString(music.Value + ";" + sound.Value + ";" + 1);
		else
			settingFile.StoreString(music.Value + ";" + sound.Value + ";" + 0);
		settingFile.Close();
	    ap.Play("FadeOut");
	}

	private void _on_AnimationPlayer_animation_finished(String anim_name)
	{
		if(anim_name == "FadeOut")
		{
			GetTree().ChangeScene("res://MainMenu/MainMenu.tscn");
		}
	}
	
	
	private void _on_FullScreenBtn_toggled(bool button_pressed)
	{
		OS.WindowFullscreen = button_pressed;
	}
}







