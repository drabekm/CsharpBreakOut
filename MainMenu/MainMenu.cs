/* MainMenu.cs
 * Matěj Drábek
*/
  

using Godot;
using System;

public class MainMenu : Control
{
	
    enum buttonStates {NewGame, HighScore, Settings, Exit};
    int pressedButton = -1;
    AnimationPlayer ap; //Used for fade in/out
    public override void _Ready()
    {
		
        ap = (AnimationPlayer)GetNode("FadeOut/AnimationPlayer");
        BrigtenScreen();
    }

    private void DimScreen()
    {
        ap.Play("FadeOut");
    }

    private void BrigtenScreen()
    {
        ap.Play("FadeIn");
    }

	public override void _Process(float delta)
    {

    }

    public void _on_NewGameBtn_pressed()
    {
        DimScreen();
        pressedButton = (int)buttonStates.NewGame;
    }

    public void _on_HighScoreBtn_pressed()
    {
        DimScreen();
        pressedButton = (int)buttonStates.HighScore;
    }

    public void _on_SettingsBtn_pressed()
    {
        DimScreen();
        pressedButton = (int)buttonStates.Settings;
    }

    public void _on_ExitBtn_pressed()
    {
        DimScreen();
        pressedButton = (int)buttonStates.Exit;
    }

   private void _on_AnimationPlayer_animation_finished(String anim_name)
   {
        GD.Print("Animation finished");
        switch(pressedButton)
        {
            case (int)buttonStates.NewGame:
                GetTree().ChangeScene("res://GameScene/Game.tscn");
				var vars = (vars)GetNode("/root/vars");
				vars.skore = 0;
				vars.lives = 3;
				vars.previousSkore = -1;
            break;

            case (int)buttonStates.HighScore:
                GetTree().ChangeScene("res://HighScoreMenu/HighScore.tscn");
            break;

            case (int)buttonStates.Settings:
                GetTree().ChangeScene("res://SettingsMenu/Settings.tscn");
            break;

            case (int)buttonStates.Exit:
                GetTree().Quit();
            break;
       }
   }
}




