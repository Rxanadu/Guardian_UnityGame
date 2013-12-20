using UnityEngine;
using System.Collections;

/// <summary>
/// controls aspects of specific option button
/// @Usage: place on an option button game object
/// @Author: Edgar Onukwugha
/// @Date: 12/14/2013
/// </summary>
public class OptionButtonController : MonoBehaviour {

	public enum ButtonMenu{
        PlayGame,
        Times,
        Resume,
        QuitLevel,
        Replay,
        Pause,
        Back,
        QuitGame
    }

    public ButtonMenu menu = ButtonMenu.PlayGame;

    public string levelName;
    public Transform target;
    PauseController pc = new PauseController();
    GUIElementsController gec = new GUIElementsController();

    void OnMouseDown() {
        PerformAction();
    }

    void PerformAction()
    {
        switch (menu) { 
            case ButtonMenu.PlayGame:
                print("PlayGame button pressed");
                Application.LoadLevel(levelName);
                break;
            case ButtonMenu.Times:
                print("Times button pressed");                
                Camera.main.transform.LookAt(target);                
                break;
            case ButtonMenu.Resume:
                print("Resume button pressed");
                //pause game
                pc.UnpauseGame();

                //disable pause menu
                gec.DisableGUIElement(gec.pauseMenu);

                //enable pause button
                gec.EnableGUIElement(gec.pauseButton);
                break;
            case ButtonMenu.QuitLevel:
                print("QuitGame button pressed");
                Application.LoadLevel(levelName);
                break;
            case ButtonMenu.Replay:
                print("Replay button pressed");
                Application.LoadLevel(Application.loadedLevel);
                break;
            case ButtonMenu.Pause:
                print("Pause button pressed");
                //pause game
                pc.PauseGame();

                //enable pause menu
                gec.EnableGUIElement(gec.pauseMenu);

                //display pause button
                gec.DisableGUIElement(gec.pauseButton);
                break;
            case ButtonMenu.Back:
                print("Times button pressed");
                Camera.main.transform.LookAt(target);
                break;
            case ButtonMenu.QuitGame:
                Application.Quit();
                break;
        }
    }
}
