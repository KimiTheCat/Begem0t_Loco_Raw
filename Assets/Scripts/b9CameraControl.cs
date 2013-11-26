using UnityEngine;
using System.Collections;
using System;

public class b9CameraControl : MonoBehaviour {

	float smooth = 2f;	    // a public variable to adjust smoothing of camera motion
	float camDist = -1.7f;
	float camHeight = .8f;
	float rotPower = 0f;        //cameraNull rotation
	float vertOffset = 0f;       //camer vertial offset
	float dolly;

	Transform avatarTransf;                       //target avatar object
	Transform camNullTransf;                      //camera Parent object
	Vector3 camOffset;  //camera offset
	Vector3 lookTarget;      //camera LookAt target position

	public GameObject cameraNull;

	// Use this for initialization
	void Start () {
		cameraNull = new GameObject("cameraNull");                   //create camera parent object
		camNullTransf = GameObject.Find ("cameraNull").transform;    //get camera parent transform
		avatarTransf = GameObject.Find ("DefaultAvatar").transform;  //get target avatar transform

		//parent cameraNull to the avatar
		cameraNull.transform.parent=avatarTransf;
		cameraNull.transform.localPosition=new Vector3(0, camHeight, camDist); //cameraNull.transform.localPosition=-Vector3.forward*1;

	}
	
	// Update is called once per frame
	void Update () {
		dolly=(Math.Abs (cameraNull.transform.rotation.y));

		camOffset = new Vector3(camNullTransf.position.x, camNullTransf.position.y-(vertOffset/1f), camNullTransf.position.z+dolly);   
		lookTarget=new Vector3(avatarTransf.position.x,(avatarTransf.position.y+camHeight+(vertOffset/10f)),avatarTransf.position.z);   

		//lerp Camera position
		transform.position=Vector3.Lerp(transform.position, camOffset, Time.deltaTime * smooth);	
		transform.LookAt(lookTarget, Vector3.up);
		cameraNull.transform.RotateAround (avatarTransf.position, Vector3.up, rotPower);

		PositionChange();

	}

	//Camera Control
	void PositionChange () {
		if (Input.GetKey(KeyCode.Period))
		{
			rotPower=rotPower-(2.5f * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.Comma))
		{
			rotPower=rotPower+(2.5f * Time.deltaTime);
		}
		else
		{
			rotPower=0f;
		}

		if (Input.GetKey(KeyCode.Quote))
		{
			vertOffset=vertOffset-(1 * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.Slash))
		{
			vertOffset=vertOffset+(1 * Time.deltaTime);
		}

	}

}

