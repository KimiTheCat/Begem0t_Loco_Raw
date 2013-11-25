using UnityEngine;
using System.Collections;

public class b9FollowCamera : MonoBehaviour {
	
	public float smooth = 3f;	// a public variable to adjust smoothing of camera motion
	Transform targetPos;		// camera look-at object
	Vector3 targetDir;			// Direction of camera
	Vector3 displace;  			// position of camera relative to DefaultAvatar
	float camHeight_Y = .75f;    // height of camera
	
	// Use this for initialization
	void Start () {
		
		targetPos = GameObject.Find ("DefaultAvatar").transform;
		
		//initial camera position - Behind
//		    displace.x = 0f;
//			displace.y = camHeight_Y;
//			displace.z = -2f;
//			targetDir = targetPos.forward;
		//initial camera position - Right
		    displace.x = 2.5f;
			displace.y = camHeight_Y;
			displace.z = .5f;
			targetDir = -targetPos.right;

	}
	
	void Update () {
		PositionChange ();


		// return the camera to standard position and direction
		transform.position = Vector3.Lerp(transform.position, targetPos.position+displace, Time.deltaTime * smooth);	
		transform.forward = Vector3.Lerp(transform.forward, targetDir, Time.deltaTime * smooth);
	}
	
		//Camera Control
	void PositionChange () {
		if(Input.GetKeyDown(KeyCode.R)) {  //Right View
            displace.x = 2.5f;
			displace.y = camHeight_Y;
			displace.z = .5f;
			targetDir = -targetPos.right;
		}
		if(Input.GetKeyDown(KeyCode.F)) {  //Front View
            displace.x = 0f;
			displace.y = camHeight_Y;
			displace.z = 2.5f;
			targetDir = -targetPos.forward;
		}
		if(Input.GetKeyDown(KeyCode.B)) {  //Back View
            displace.x = 0f;
			displace.y = camHeight_Y;
			displace.z = -2f;
			targetDir = targetPos.forward;
		}
		if(Input.GetKeyDown(KeyCode.T)) {  //Top View
            displace.x = 0f;
            displace.y = 2.5f;
			displace.z = 0f;
			targetDir = -targetPos.up;
			}
		//Camera Move
		if(Input.GetKeyDown(KeyCode.Period)){
			Debug.Log("right");
		}
		if(Input.GetKeyDown(KeyCode.Comma)){
			Debug.Log("left");
		}

		}
	}


	

