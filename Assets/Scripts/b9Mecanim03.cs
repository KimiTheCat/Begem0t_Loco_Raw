using UnityEngine;
using System.Collections;

public class b9Mecanim03 : MonoBehaviour {

	// public float animSpeed = 1.5f;				// a public setting for overall animator animation speed
	public float DampTime = 25f;
	private Animator anim;							// a reference to the animator on the character
    private AnimatorStateInfo animState;			// a reference to the current state of the animator, used for base layer

    //animation state hashes
	static int idleState = Animator.StringToHash("Base Layer.Stand_Idle");	
	static int walkRunState = Animator.StringToHash("WALK-RUN.Walk-Run");
    static int stand2walkState = Animator.StringToHash("WALK-RUN.Stand-2-Walk");

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () 
	{
		//Input.GetAxis("Horizontal");				// setup h variable as our horizontal input axis
		//Input.GetAxis("Vertical");				// setup v variables as our vertical input axis
        anim.SetFloat("Speed", Input.GetAxis("Vertical"));							// set our animator's float parameter 'Speed' equal to the vertical input axis				
        anim.SetFloat("Direction", Input.GetAxis("Horizontal"), DampTime, Time.deltaTime); 						// set our animator's float parameter 'Direction' equal to the horizontal input axis		
        animState = anim.GetCurrentAnimatorStateInfo(0);	// set our currentState variable to the current state of the Base Layer (0) of animation

        //Logic_IfBased();
        LogicStates();
    }

    void LogicStates() {
        if (animState.nameHash == idleState)
		{
			// to Alert
            // to Sidestep
            // to Run - direct if shift pressed go directly to start-2-run
            // to Turn on place
            // to Look Left, Right, Over Shoulder
            // to Walk
		}


        if (animState.nameHash == stand2walkState)
        {
            if (Input.GetAxis("Vertical") == 0 && Input.GetKey(KeyCode.DownArrow))
            {
                anim.CrossFade(idleState, .1f, -1, .5f);
            }
        }

        if (animState.nameHash == walkRunState)
		{
				//Debug.Log("walk");
			
		}

	}
    

    //void Logic_IfBased() //no, thanx
    //{
    //    if (Input.GetKey(KeyCode.LeftShift))		//While LeftShift pressed
    //    {
    //        //anim.SetBool("Sprint", true);					//Turn on boolean
    //        anim.SetFloat("Walk-Run", 1f, DampTime, Time.deltaTime);
    //    }
    //    else
    //    {
    //        anim.SetFloat("Walk-Run", 0f, DampTime, Time.deltaTime);
    //    }
    //}

}
