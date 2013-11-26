using UnityEngine;
using System.Collections;

public class b9Camera2 : MonoBehaviour {

	float smooth = 1.5f;	    // a public variable to adjust smoothing of camera motion
	float camDist = -2f;
	float camHeight = 1.1f;

	Transform avatarTransf;                       //target avatar object
	Transform camNullTransf;                      //camera Parent object
	Vector3 camLookOffset = new Vector3(0,1,0);   //camera LookAt offset


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
		//lerp Camera position
		transform.position=Vector3.Lerp(transform.position, camNullTransf.position, Time.deltaTime * smooth);	
		transform.LookAt(avatarTransf.position+camLookOffset, Vector3.up);
	}


}

