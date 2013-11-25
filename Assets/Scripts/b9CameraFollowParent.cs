using UnityEngine;
using System.Collections;

public class b9CameraFollowParent : MonoBehaviour {

	Vector3 displace;  			// position of camera relative to DefaultAvatar
	Transform targetPos;		// camera look-at object
	float camHeight_Y = .75f;    // height of camera

	void Start () {
		targetPos = GameObject.Find ("CameraRotionParent").transform;

		displace.x = 0f;
		displace.y = camHeight_Y;
		displace.z = -2f;
//		targetDir = targetPos.forward;

		transform.position=targetPos.position+displace;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
}
