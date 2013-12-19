using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller for the game
/// @Author: Edgar Onukwugha
/// @Date: 12/13/2012
/// </summary>
public class PlayerController : MonoBehaviour
{   

    public float speed = 2.0f;
    public Transform spawnPoint;

    float scaleStep;

    bool controlsEnabled;

    public bool ControlsEnabled { 
        get { return controlsEnabled;}
        set { controlsEnabled = value; }
    }

    #region Functions
    void Start()
    {
        PlacePlayerAtSpawnPoint();
        controlsEnabled = true;
    }

    void FixedUpdate()
    {
        //allow player to move if controls are enabled
        if (controlsEnabled)
            MoveCharacter();
    }

    //moves the character around the world
    void MoveCharacter()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        float movementSpeed = speed * Time.deltaTime;

        //move the player based on frame speed 
        rigidbody.AddForce(movement * movementSpeed);
    }

    //places player at spawn point position at start of stage
    void PlacePlayerAtSpawnPoint()
    {
        if (spawnPoint == null)
        {
            Debug.Log("No spawn point detected: please place at least one spawn point within scene");
        }
        else
        {
            transform.position = spawnPoint.transform.position;
        }
    }

    //disables control of player, resets player's velocity
    public void DisablePlayer()
    {
        controlsEnabled = false;
        rigidbody.velocity = Vector3.zero;
    }

    //enables control of player
    public void EnablePlayer()
    {
        controlsEnabled = true;
    }
    #endregion
}