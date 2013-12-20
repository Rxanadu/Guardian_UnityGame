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
    GameObject finishTime;
    GameObject bestTime;
    bool gameEnded;
    string finishTimeText;
    string bestFinishTimeText;
    
    public bool GameEnded {
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

        finishTime = GameObject.FindGameObjectWithTag(Tags.finishTimeText);
        bestTime = GameObject.FindGameObjectWithTag(Tags.bestTimeText);

        finishTimeText = finishTime.GetComponent<GUIText>().guiText.text;
        bestFinishTimeText = bestTime.GetComponent<GUIText>().guiText.text;

        //set text for Game Over screen text
        finishTimeText = "FINISH TIME: ";
        bestFinishTimeText = "BEST TIME: ";

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
		print ("Oh no! Game over :(");

        //disable turrets
        foreach (GameObject turret in turrets)
        {
            turret.GetComponent<MiniturretController>().TurretEnabled = false;
        }

        //disable player movement
        pc.ControlsEnabled = false;

        //stop player from spawning in

        //dislplay Game Over screen        
        gec.EnableGUIElement(gec.GameOverScreen);

        //set game over text
        finishTimeText += gt.FinishTime.ToString();
        bestFinishTimeText += gt.BestFinishTime.ToString();

		//disable other GUI elements
		gec.DisableGUIElement(gec.PauseButton);
    }
}