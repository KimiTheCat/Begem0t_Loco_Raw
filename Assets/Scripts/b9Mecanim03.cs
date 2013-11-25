using UnityEngine;
using System.Collections;

public class b9Mecanim03 : MonoBehaviour {

	// public float animSpeed = 1.5f;				// a public setting for overall animator animation speed
	public float DampTime = 25f;
	private Animator anim;							// a reference to the animator on the character
	private AnimatorStateInfo currentBaseState;			// a reference to the current state of the animator, used for base layer
	static int idleState = Animator.StringToHash("Base Layer.Stand_Idle");	
	//static int locoState = Animator.StringToHash("Base Layer.Locomotion");
	static int walkState = Animator.StringToHash("Base Layer.Walk");
	static int runState = Animator.StringToHash("Base Layer.Run");
	


	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float h = Input.GetAxis("Horizontal");				// setup h variable as our horizontal input axis
		float v = Input.GetAxis("Vertical");				// setup v variables as our vertical input axis
		anim.SetFloat("Speed", v);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.SetFloat("Direction", h, DampTime, Time.deltaTime); 						// set our animator's float parameter 'Direction' equal to the horizontal input axis		
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	// set our currentState variable to the current state of the Base Layer (0) of animation

		if (Input.GetKey(KeyCode.LeftShift))		//While LeftShift pressed
		{
			//anim.SetBool("Sprint", true);					//Turn on boolean
			anim.SetFloat("Walk-Run", 1f, DampTime, Time.deltaTime);
		}
		else
		{
			anim.SetFloat("Walk-Run", 0f, DampTime, Time.deltaTime);					
		}



		if (currentBaseState.nameHash == idleState)
		{
				// Debug.Log("idle");

		}

		if (currentBaseState.nameHash == walkState)
		{
				// Debug.Log("walk");
			
		}

		if (currentBaseState.nameHash == runState)
		{
				// Debug.Log("run");
			
		}

	}
}
