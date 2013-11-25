using UnityEngine;
using System.Collections;

public class b9AttachedCamera : MonoBehaviour {

	public float smooth = 3f;	// a public variable to adjust smoothing of camera motion
	Transform targetPos;		// camera look-at object
	Vector3 targetDir;			// Direction of camera
	Vector3 displace;  			// position of camera relative to DefaultAvatar
	float camHeight_Y = .75f;    // height of camera

	// Use this for initialization
	void Start () {
		targetPos = GameObject.Find ("DefaultAvatar").transform;
		
		displace.x = 0f;
		displace.y = camHeight_Y;
		displace.z = -2f;
		targetDir = targetPos.forward;
	}
	
	// Update is called once per frame
	void Update () {
		//PositionChange ();
		
		
		// return the camera to standard position and direction
		//transform.RotateAround (targetPos.position, Vector3.up, 20 * Time.deltaTime);
		//transform.position = Vector3.Lerp(transform.position, targetPos.position+displace, Time.deltaTime * smooth);	
		//transform.forward = Vector3.Lerp(transform.forward, targetDir, Time.deltaTime * smooth);	

		//transform.LookAt(targetPos.position, Vector3.up);

		//transform.RotateAround (targetPos.position, Vector3.up, 10 * Time.deltaTime);
		transform.RotateAround (targetPos.position+displace, Vector3.up, 2);
		transform.position=targetPos.position+displace;

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
			transform.RotateAround (targetPos.position, Vector3.up, 20 * Time.deltaTime);
		}
		if(Input.GetKeyDown(KeyCode.Comma)){
			Debug.Log("left");
			transform.RotateAround (Vector3.zero, Vector3.up, 20 * Time.deltaTime);

		}
		
	}

	void Orbit(){
		// ***************** THIS SECTION IS FOR ORBITING THE CAMERA ***************** //
		
		// Calculate the current rotation angles
		float wantedRotationAngle = targetPos.eulerAngles.y;
		float currentRotationAngle = transform.eulerAngles.y;
		
		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle( currentRotationAngle, wantedRotationAngle, 2 * Time.deltaTime );
		
		// Convert the angle into a rotation
		Quaternion currentRotation = Quaternion.Euler( 0, currentRotationAngle, 0 );
		
		// Set the position of the camera on the x-z plane to distance meters behind the target
		/// That's the part I can't hook into my final smooth camera code, since I can only make it work when using 'target.position',
		/// but I really need to use the smooth camera position 'camPosXYZ' instead...
		Vector3 camPos = targetPos.position - ( currentRotation * Vector3.forward * 21 );
		
		// ***************** END OF SECTION FOR ORBITING THE CAMERA ***************** //

	}

}
