using UnityEngine;
using System.Collections;

/// <summary>
/// Cause platform to fall
/// @Author: Edgar Onukwugha
/// @Date: 11/22/2013
/// Versions:
///     v1.1 (12/02/2013): 
///         *sets initPosition to localPosition for use with parent object
///         *return transform.localPosition to initPosition rather than 
///             transform.position for use with parent object
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlatformFall : MonoBehaviour {

	#region Fields
	GameObject player;
	bool isFalling;
	bool isResetting;
	float timer;
	Vector3 initPosition;

	public float timeLimit = 2.0f;
	public float resetTimeLimit = 2.0f;
	public Color startColor = Color.green;
	public Color endColor = Color.red;
	#endregion

	#region Functions
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (Tags.player);
		isFalling=false;
		isResetting=false;
		timer=0;
		initPosition = this.transform.localPosition;

		InitializePlaform ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(isFalling){
			StartFalling (timeLimit);
		}
		if(isResetting){
			ResetPlatform(resetTimeLimit);
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject == player){
			isFalling=true;
		}
	}

	//makes sure plaform is not falling at start
	void InitializePlaform(){
		rigidbody.useGravity=false;
		rigidbody.isKinematic=true;
		renderer.material.color = startColor;

	}

	//causes platform to start falling
	void StartFalling(float timeLimit){
			timer+=Time.deltaTime;
			renderer.material.color = Color.Lerp(renderer.material.color, 
			                                     endColor, 
			                                     timer/timeLimit);

		//make platform fall
		if(timer/timeLimit>=1){
			DeactivatePlatform();
			isFalling=false;
			isResetting=true;
		}
	}

	//cause platform to fall
	void DeactivatePlatform(){
		rigidbody.useGravity=true;
		rigidbody.isKinematic=false;
		timer = 0;
	}

	//set platform at initial position
	void ResetPlatform(float timeLimit){
		timer+= Time.deltaTime;

		if(timer/timeLimit>=1){
			InitializePlaform ();
			transform.localPosition = initPosition;
			isResetting=false;
			timer = 0;
		}

	}
	#endregion
}
