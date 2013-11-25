using UnityEngine;
using System.Collections;

public class b9CameraParent : MonoBehaviour {

	public float smooth = 3f;	// a public variable to adjust smoothing of camera motion
	float rotPower = 0f;

	Transform targetPos;		// camera look-at object

	//Vector3 targetDir;			// Direction of camera
	//Vector3 displace;  			// position of camera relative to DefaultAvatar
	//float camHeight_Y = .75f;    // height of camera
	// Use this for initialization
	void Start () {
		targetPos = GameObject.Find ("DefaultAvatar").transform;
		
	}
	
	// Update is called once per frame
	void Update () {
				
		// return the camera to standard position and direction
		//transform.RotateAround (targetPos.position, Vector3.up, 20 * Time.deltaTime);
		//transform.position = Vector3.Lerp(transform.position, targetPos.position+displace, Time.deltaTime * smooth);	
		//transform.forward = Vector3.Lerp(transform.forward, targetDir, Time.deltaTime * smooth);	

		//transform.LookAt(targetPos.position, Vector3.up);

		//transform.RotateAround (targetPos.position, Vector3.up, 10 * Time.deltaTime);
		transform.position=targetPos.position;
		transform.RotateAround (targetPos.position, Vector3.up, rotPower);

		PositionChange ();

	}

	//Camera Control
	void PositionChange () {
		if (Input.GetKey(KeyCode.Period))
		{
			rotPower=rotPower-(2 * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.Comma))
		{
			rotPower=rotPower+(2 * Time.deltaTime);
		}
		else
		{
			rotPower=0f;
		}
	}

}
