using UnityEngine;
using System.Collections;

/// <summary>
/// displays top times scored within the game
/// @Author: Edgar Onukwugha
/// @Date: 12/24/2013
/// @Usage: place on empty game object
/// </summary>
public class TimesDisplayController : MonoBehaviour {

    public GUISkin mySkin;
    public float textWidth = 150.0f;

    float bestTime;
    bool timesVisible;    

    public bool TimesVisible {
        get { return timesVisible; }
    }

    void Start() {
        timesVisible = false;
    }

    void OnGUI() {
        GUI.skin = mySkin;
        bestTime = PlayerPrefs.GetFloat("bestTime");
        string bestTimeText = string.Format("{0}:{1:00}", (int)bestTime / 60, (int)bestTime % 60);

        if(timesVisible)
            GUI.Label(new Rect(Screen.width / 2 - textWidth/2, Screen.height / 2, textWidth, 30), "Time: " + bestTimeText);
    }

    //allows display of times
    public void ShowTimes() {
        timesVisible = true;
    }

    //denies display of times
    public void HideTimes() {
        timesVisible = false;
    }
}
