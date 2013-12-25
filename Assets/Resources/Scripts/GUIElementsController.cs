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
    Vector3 disabledPos;
    Vector3 enabledPos;

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
        InitializeGUIElementsForGame();
    }

    /// <summary>
    /// sets all GUI Elements
    /// </summary>

    void InitializeGUIElementsForGame() {
        pauseMenuClone = Instantiate(pauseMenu, transform.position, Quaternion.identity) as GameObject;
        gameOverScreenClone = Instantiate(gameOverScreen, transform.position, Quaternion.identity) as GameObject;

        disabledPos = new Vector3(-1, -1, 0);
        enabledPos = new Vector3(.5f, .5f, 0);

        DisableGUIElement(gameOverScreenClone);
        DisableGUIElement(pauseMenuClone);
        EnableGUIElement(pauseButton);
    }

    /// <summary>
    /// moves GUI Element out of view of the camera
    /// </summary>
    /// <param name="guiElement"></param>
    public void DisableGUIElement(GameObject guiElement)
    {
        if (guiElement != null)
        {
            if (guiElement.collider == null)
                guiElement.transform.position = disabledPos;
            else
                guiElement.SetActive(false);
        }
    }

    /// <summary>
    /// moves GUI Element in view of the camera
    /// </summary>
    /// <param name="guiElement"></param>
    public void EnableGUIElement(GameObject guiElement)
    {
        if (guiElement != null)
        {
            if (guiElement.collider == null)
                guiElement.transform.position = enabledPos;
            else
                guiElement.SetActive(true);
        }
    }
}