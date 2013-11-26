using UnityEngine;
using System.Collections;

public class Mecanim2 : MonoBehaviour {

		public float animSpeed = 1.5f;				// a public setting for overall animator animation speed
		private Animator anim;							// a reference to the animator on the character

	// Use this for initialization
	void Start () {
			anim = GetComponent<Animator>();					  

	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");				// setup h variable as our horizontal input axis
		float v = Input.GetAxis("Vertical");				// setup v variables as our vertical input axis
		anim.SetFloat("Speed", v);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.SetFloat("Direction", h); 						// set our animator's float parameter 'Direction' equal to the horizontal input axis		
	
		Debug.Log ("State" + h.ToString());

	}
}
