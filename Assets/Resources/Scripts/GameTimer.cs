using UnityEngine;
using System.Collections;

/// <summary>
/// counts the time in-game for as long as the player is
/// in the stage
/// @Author: Edgar Onukwugha
/// @Date: 12/19/2013
/// @Usage: place on a "$GameController" game object
/// </summary>
public class GameTimer : MonoBehaviour
{
    GameEndController gec;

    float timer;
    float seconds, minutes, hours;
    float finishTime;
    float bestFinishTime;
    bool updateTimer;

    public float FinishTime {
        get { return finishTime; }
    }

    public float BestFinishTime {
        get { return bestFinishTime; }
    }

    // Use this for initialization
    void Start()
    {
        gec = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<GameEndController>();

        //initialize timer
        timer = 0;

        //initialize finish time
        finishTime = 0;

        //initialize hours
        hours = 0;

        //clamp seconds, minutes
        minutes = Mathf.Clamp(minutes, 0, 59);
        seconds = Mathf.Clamp(seconds, 0, 59);

        if (PlayerPrefs.GetFloat("bestTime") != null)
        {
            bestFinishTime = PlayerPrefs.GetFloat("bestTime");
        }
        else {
            PlayerPrefs.SetFloat("bestTime", bestFinishTime);
            bestFinishTime = 0;
        }

        updateTimer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gec.GameEnded &&
            updateTimer)
            CountTime();

        if (gec.GameEnded)
        {
            updateTimer = false;
            SaveBestTime();
        }
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 120, 30), timer.ToString());
    }

    //count time for the game
    void CountTime()
    {
        timer += Time.deltaTime;     
    }

    void SaveBestTime() {
        
        finishTime = timer;

        //only save best time if previous time has been surpassed
        if (finishTime > bestFinishTime) {
            bestFinishTime = finishTime;
            PlayerPrefs.SetFloat("bestTime", bestFinishTime);
        }
    }
}