using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour {

	float x, y;

	void Update () {
		x = Screen.width;
		y = Screen.height;
	}

	void OnGUI () {
		GUI.Box (new Rect (x / 4, y / 4, x / 2, y / 2), "VOCÊ PERDEU\nAPERTE ESC PARA REINICIAR");
	}
}