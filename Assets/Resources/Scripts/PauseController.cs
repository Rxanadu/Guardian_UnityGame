using UnityEngine;
using System.Collections;

/// <summary>
/// controls what happens when pausing,
/// unpausing game
/// @Author: Edgar Onukwugha
/// @Date: 12/16/13
/// </summary>
public class PauseController : MonoBehaviour
{

    //bool isPaused = false;

    //public bool IsPaused
    //{
    //    get { return isPaused; }
    //}

    public void PauseGame()
    {
        Time.timeScale = 0;
       // isPaused = true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        //isPaused = false;
    }
}