using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightManager : MonoBehaviour {

	bool isOn;
	bool haveLantern;

	private void Awake() {
			this.gameObject.GetComponentInChildren<Light>().enabled = false;		
	}

	public void PegarLanterna () {
		haveLantern = true;
		isOn = true;
		this.gameObject.GetComponentInChildren<Light>().enabled = true;
		Debug.Log("Esta Acontecendo");
	}

	public void TurnLanternOnOff () {
		if (isOn && haveLantern) {
			if (Input.GetKeyDown(KeyCode.Mouse0)) {
				isOn = false;
				this.gameObject.GetComponentInChildren<Light>().enabled = false;
			}
		} else if (!isOn && haveLantern) {
			if (Input.GetKeyDown(KeyCode.Mouse0)) {
				isOn = true;
				this.gameObject.GetComponentInChildren<Light>().enabled = true;
			}

		}
	}

	private void Update () {
		TurnLanternOnOff ();
	}
}
