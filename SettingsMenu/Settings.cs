using Godot;
using System;

public class Settings : Control
{
    AnimationPlayer ap;
    public override void _Ready()
    {
        ap = (AnimationPlayer)GetNode("ColorRect/AnimationPlayer");
		ap.Play("FadeIn");
    }

	private void _on_Button_pressed()
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
	
	
	private void _on_FullScreenBtn_toggled(bool button_pressed)
	{
		OS.WindowFullscreen = button_pressed;
	}
}







