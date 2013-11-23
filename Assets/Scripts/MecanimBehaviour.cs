using UnityEngine;
using System;
using System.Collections;

public class MecanimBehaviour : MonoBehaviour {
	
	//private float Speed = 1f;
	//private float Direction = 1f;
	private Animator anim;							// a reference to the animator on the character
	public float DirDampTime = .25f;				//smooth turns	
	

	// Use this for initialization
	void Start () {
		// initialising reference variables
 		anim = GetComponent<Animator>();

	
	}
	
	// Update is called once per frame
	void Update () {
		
		anim.SetBool ("Jump", Input.GetKey(KeyCode.J));
		//Debug.Log ("Jump state");
		
		float v = Input.GetAxis("Vertical");					// setup v variables as our vertical input axis
		float h = Input.GetAxis("Horizontal");					// setup h variable as our horizontal input axis
		//anim.SetFloat("Speed", v);						// animator's 'Speed' equal to the vertical input axis				
		//anim.SetFloat("Direction", h); 					// animator's 'Direction' equal to the horizontal input axis	

		anim.SetFloat("Speed", h*h+v*v);						// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.SetFloat("Direction", h, DirDampTime, Time.deltaTime); // set our animator's float parameter 'Direction' equal to the horizontal input axis	

	}
	
		void FixedUpdate ()
	{
	}
}
