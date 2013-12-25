using UnityEngine;
using System.Collections;

/// <summary>
/// determines actions done when game is finished
/// @Author: Edgar Onukwugha
/// @Date: 12/16/2013
/// @Usage: place on "$GameController" game object
/// </summary>
public class GameEndController : MonoBehaviour
{

    CrystalController cc;
    PlayerController pc;
    GUIElementsController gec;
    GameTimer gt;

    GameObject[] turrets;
    bool gameEnded;
    string finishTimeText;
    string bestFinishTimeText;

    public bool GameEnded
    {
        get { return gameEnded; }
    }

    void Start()
    {
        //find refernces for in-game objects
        turrets = GameObject.FindGameObjectsWithTag(Tags.miniTurrret);
        cc = GameObject.FindGameObjectWithTag(Tags.crystal).GetComponent<CrystalController>();
        pc = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerController>();
        gec = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<GUIElementsController>();
        gt = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<GameTimer>();

        gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.Health <= 0)
            gameEnded = true;

        if (gameEnded)
            StopGame();
    }

    void StopGame()
    {
        //disable turrets
        foreach (GameObject turret in turrets)
        {
            turret.GetComponent<MiniturretController>().TurretEnabled = false;
        }

        //disable player movement
        pc.ControlsEnabled = false;

        //stop player from spawning in

        

        finishTimeText = "FINISH TIME: " + gt.FinishTime;
        bestFinishTimeText = "BEST TIME: " + gt.BestFinishTime;

        //set text for Game Over screen text
        GameObject.FindGameObjectWithTag(Tags.finishTimeText).
            GetComponent<GUIText>().text = finishTimeText;
        GameObject.FindGameObjectWithTag(Tags.bestTimeText).
            GetComponent<GUIText>().text = bestFinishTimeText;

        //dislplay Game Over screen        
        gec.EnableGUIElement(gec.GameOverScreen);

        //disable other GUI elements
        gec.DisableGUIElement(gec.PauseButton);
        gec.DisableGUIElement(gec.PauseMenu);
    }
}