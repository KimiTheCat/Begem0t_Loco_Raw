using UnityEngine;
using System.Collections;

public class AnimScript : MonoBehaviour {
	
	//bool walking = false;
	//bool aiming = false;
	//bool run = false;
	//bool idle = true;
		private Animator anim;							// a reference to the animator on the character
	
	// Use this for initialization
	void Start () {
	 		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

//		if(walking == true && run == false){
//        animation.CrossFade("fpsWalk", 0.2);
//        idle = false;
//	    }
//	    else if(walking == true && run == true){
//	        animation.CrossFade("fpsRun", 0.2);
//	        idle = false;
//	    }
//	    else if(aiming){
//	        animation.CrossFade("fpsAim", 0.2);
//	        idle = false;
//	    }
//	    else if(idle){
//	        animation.CrossFade("fpsIdle", 0.2);
//	        run = false;
//	        walking = false;
//	        aiming = false;
//	    }
		
		//animation.Play("Idle-2-Walk", PlayMode.StopAll);
		
	
		anim.SetBool ("Jump", Input.GetKey(KeyCode.J));
//			if(Input.GetKeyDown(KeyCode.J)) {  //Top View
//
//				}
	}
}
