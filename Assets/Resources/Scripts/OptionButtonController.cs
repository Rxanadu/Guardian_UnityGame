using UnityEngine;
using System.Collections;

/// <summary>
/// controls aspects of specific option button
/// @Usage: place on an option button game object
/// @Author: Edgar Onukwugha
/// @Date: 12/14/2013
/// </summary>
public class OptionButtonController : MonoBehaviour
{

    public enum ButtonMenu
    {
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

    GameObject gameController;
    PauseController pc;
    GUIElementsController gec;
    TimesDisplayController tdc;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag(Tags.gameController))
        {
            gameController = GameObject.FindGameObjectWithTag(Tags.gameController);
            pc = gameController.GetComponent<PauseController>();
            gec = gameController.GetComponent<GUIElementsController>();
        }

        if (GameObject.FindGameObjectWithTag(Tags.timesDisplay)) {
            tdc = GameObject.FindGameObjectWithTag(Tags.timesDisplay).GetComponent<TimesDisplayController>();
        }
        
    }

    void OnMouseDown()
    {
        PerformAction();
    }

    void PerformAction()
    {
        switch (menu)
        {
            case ButtonMenu.PlayGame:
                print("PlayGame button pressed");
                Application.LoadLevel(levelName);
                break;
            case ButtonMenu.Times:
                print("Times button pressed");
                Camera.main.transform.LookAt(target);

                //display best times
                if (!tdc.TimesVisible)
                    tdc.ShowTimes();
                break;
            case ButtonMenu.Resume:
                print("Resume button pressed");
                //unpause game
                pc.UnpauseGame();

                //disable pause menu
                gec.DisableGUIElement(gec.PauseMenu);

                //enable pause button
                gec.EnableGUIElement(gec.PauseButton);
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
                gec.EnableGUIElement(gec.PauseMenu);

                //display pause button
                gec.DisableGUIElement(gec.PauseButton);
                break;
            case ButtonMenu.Back:
                print("Back button pressed");
                Camera.main.transform.LookAt(target);

                //hide best times
                if (tdc.TimesVisible)
                    tdc.HideTimes();
                break;
            case ButtonMenu.QuitGame:
                Application.Quit();
                break;
        }
    }
}