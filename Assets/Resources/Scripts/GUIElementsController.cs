using UnityEngine;
using System.Collections;

/// <summary>
/// controls what GUI elements are displayed on-screen
/// at a time
/// @Author: Edgar Onukwugha
/// @Date: 12/16/2013
/// @Usage: place on "$GameController" game object
/// only active in levels with gameplay
/// </summary>
public class GUIElementsController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject gameOverScreen;

    GameObject pauseMenuClone;
    GameObject gameOverScreenClone;

    public GameObject PauseMenu
    {
        get { return pauseMenuClone; }
    }

    public GameObject PauseButton
    {
        get { return pauseButton; }
    }

    public GameObject GameOverScreen
    {
        get { return gameOverScreenClone; }
    }

    void Start()
    {
        pauseMenuClone = Instantiate(pauseMenu, transform.position, Quaternion.identity) as GameObject;
        gameOverScreenClone = Instantiate(gameOverScreen, transform.position, Quaternion.identity) as GameObject;

        DisableGUIElement(gameOverScreenClone);
        DisableGUIElement(pauseMenuClone);
        EnableGUIElement(pauseButton);
    }

    public void DisableGUIElement(GameObject guiElement)
    {
        if (guiElement != null)
            guiElement.SetActive(false);
        else
        {
            print(guiElement.name + " is missing.  Please look for reference");
        }
    }

    public void EnableGUIElement(GameObject guiElement)
    {
        if (guiElement != null)
            guiElement.SetActive(true);
        else
        {
            print(guiElement.name + " is missing.  Please look for reference");
        }
    }
}