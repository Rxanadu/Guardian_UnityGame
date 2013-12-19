using UnityEngine;
using System.Collections;

/// <summary>
/// controls what GUI elements are displayed on-screen
/// at a time
/// @Author: Edgar Onukwugha
/// @Date: 12/16/2013
/// @Usage: place on "$GameController" game object
/// </summary>
public class GUIElementsController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject gameOverScreen;

    public void DisableGUIElement(GameObject guiElement)
    {
        guiElement.SetActive(false);
    }

    public void EnableGUIElement(GameObject guiElement)
    {
        guiElement.SetActive(true);
    }
}