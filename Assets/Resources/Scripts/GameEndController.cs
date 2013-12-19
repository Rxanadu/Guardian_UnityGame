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

    CrystalController cc = new CrystalController();
    PlayerController pc = new PlayerController();
    GUIElementsController gec;
    GameObject[] turrets;

    void Start()
    {
        //find refernces for in-game objects
        turrets = GameObject.FindGameObjectsWithTag(Tags.miniTurrret);
        cc = GameObject.FindGameObjectWithTag(Tags.crystal).GetComponent<CrystalController>();
        pc = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerController>();
        gec = GetComponent<GUIElementsController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.Health <= 0)
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

        //dislplay Game Over screen        
        gec.EnableGUIElement(gec.gameOverScreen);
    }
}