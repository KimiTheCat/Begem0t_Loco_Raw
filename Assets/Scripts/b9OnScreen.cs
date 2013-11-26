
//Stolen from Attila

using UnityEngine;
using System.Collections;

public class b9OnScreen : MonoBehaviour {


	void OnGUI () {
		// Make a background box
		GUIStyle infoStyle = new GUIStyle();
		
		infoStyle.fontSize = 9;
		infoStyle.font = GUI.skin.font;

//		GUI.Box(new Rect(10,10,100,90), "Hotkeys");

//		string s = player.speed.ToString();
//		string d = player.direction.ToString();
		
//		GUI.Box (new Rect (8,8,220,260), "Avatar Controller  (v"+version+")");
		
//		GUI.Label(new Rect(10, 25, 160,20), "Avatar: "+player.avatar.name);		
//		GUI.Label(new Rect(10,45, 100,20), "Speed:    "+s);		
//		GUI.Label(new Rect(10,55, 100,40), "Direction:"+d);
		
		GUI.Label(new Rect(10,10, 100,120), "KEYBOARD");
		GUI.Label(new Rect(10,40, 200,120), "Arrows, WASD : Move avatar");		
		GUI.Label(new Rect(10,60, 160,120), "LeftShift  : Run");
		GUI.Label(new Rect(10,80, 160,120), "< >  : Camera Left/Right");
		GUI.Label(new Rect(10,100, 160,120), "\" ?  : Camera Up/Down");

//		GUI.Label(new Rect(10,130, 160,120), "Z/X: Zoom camera");
//		GUI.Label(new Rect(10,150, 160,120), "R  : Reset avatar");

	}
}