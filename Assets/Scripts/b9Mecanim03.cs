using UnityEngine;
using System.Collections;

public class b9Mecanim03 : MonoBehaviour {

	// public float animSpeed = 1.5f;				// a public setting for overall animator animation speed
    public float DampTime = 3f;
	private Animator anim;							// a reference to the animator on the character
    private AnimatorStateInfo animState;			// a reference to the current state of the animator, used for base layer
    float h = 0f;				// setup h variable as our horizontal input axis
    float v = 0f;				// setup v variables as our vertical input axis

    //animation state hashes
	static int idleState = Animator.StringToHash("Base Layer.Stand_Idle");
    static int idleStateSwitchFeet = Animator.StringToHash("Base Layer.Stand_Idle (change feet)");
    static int walkRunState = Animator.StringToHash("WALK-RUN.WALK-RUN");   //Walk-Run
    static int stand2walkState = Animator.StringToHash("WALK-RUN.Stand-2-Walk");
    static int walkState = Animator.StringToHash("WALK-RUN.Walk");
    static int standTurnState = Animator.StringToHash("TURN_ON_PLACE.TURN_SLOW_FAST"); //"TURN_ON_PLACE.STAND_TURN"   //"Base Layer.TUN" 

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
    }

    IEnumerator WaitSec()
    {
        float waitTime = Random.Range(0.0f, 100.0f);
        yield return new WaitForSeconds(waitTime);

        //yield return new WaitForSeconds(5);
        print(Time.time);
    }

	
	// Update is called once per frame
	void Update () 
	{
        h = Input.GetAxis("Horizontal");				// setup h variable as our horizontal input axis
        v = Input.GetAxis("Vertical");				// setup v variables as our vertical input axis
        anim.SetFloat("Speed", v);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
        anim.SetFloat("Direction", h); 						// set our animator's float parameter 'Direction' equal to the horizontal input axis		

        //anim.SetFloat("Speed", Input.GetAxis("Vertical"));							// set our animator's float parameter 'Speed' equal to the vertical input axis				
        //anim.SetFloat("Direction", Input.GetAxis("Horizontal"), DampTime, Time.deltaTime); 						// set our animator's float parameter 'Direction' equal to the horizontal input axis		
        animState = anim.GetCurrentAnimatorStateInfo(0);	// set our currentState variable to the current state of the Base Layer (0) of animation

        LogicStates();
    }

    void LogicStates() {
        if (animState.nameHash == idleState)
		{
            //print("horiz: " + h.ToString());
            // to Turn on place
            if (h != 0f) //(!Input.anyKeyDown)
            {
                anim.CrossFade(standTurnState, 0f, -1, 0f);
                print("turn");
            }
            //Idle variations
            else if (Input.GetKey(KeyCode.I)) //(!Input.anyKeyDown)
            {
                anim.CrossFade(idleStateSwitchFeet, .3f, -1, 0f);
            }

            // to Alert
            // to Sidestep
            // to Run - direct if shift pressed go directly to start-2-run

            // to Look Left, Right, Over Shoulder
            // to Walk
		}

        if (animState.nameHash == standTurnState)
        {
            if (Input.GetKey(KeyCode.LeftShift))		//While LeftShift pressed
            {
                anim.SetFloat("Shift", 1f, DampTime, Time.deltaTime);
            }
            else
            {
                anim.SetFloat("Shift", 0f, DampTime, Time.deltaTime);
            }

            if (h == 0f)
            {
                anim.CrossFade(idleState, 0f, -1, 0f);
            }

        }

        if (animState.nameHash == stand2walkState)
        {
            if (Input.GetKey(KeyCode.DownArrow))   //(Input.GetAxis("Vertical") == 0 && Input.GetKey(KeyCode.DownArrow))
            {
                anim.CrossFade(standTurnState, .2f, -1, .1f);
            }
            //Debug.Log("trans");

        }

        if (animState.nameHash == walkRunState)
		{
            //print("walkrun state");
            if (Input.GetKey(KeyCode.LeftShift))		//While LeftShift pressed
            {
                anim.SetFloat("Shift", 1f, DampTime, Time.deltaTime);
            }
            else
            {
                anim.SetFloat("Shift", 0f, DampTime, Time.deltaTime);
            }

            //Debug.Log("walkRun");
			
		}

	}
    

}
