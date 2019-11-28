using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightManager : MonoBehaviour {

	bool haveLantern;

	private GameObject go;
	private bool estaLigado;

	private void Awake () {
		go = this.gameObject;
		go.GetComponentInChildren<Light> ().enabled = false;
	}

	public void PegarLanterna () {
		haveLantern = true;
		estaLigado = true;
		this.gameObject.GetComponentInChildren<Light> ().enabled = true;
		Debug.Log ("Esta Acontecendo");
	}

	// public void ToggleLantern () {
	// 	if (Input.GetKeyDown (KeyCode.Mouse0)) estaLigado = !estaLigado;
	// 	go.GetComponentInChildren<Light> ().enabled = estaLigado;
	// }
	
	
	public void TurnLanternOnOff () {
		if (estaLigado) {
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				estaLigado = false;
				go.GetComponentInChildren<Light> ().enabled = false;
			}
		} else {
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				estaLigado = true;
				go.GetComponentInChildren<Light> ().enabled = true;
			}
		}
	}

	private void Update () {
		TurnLanternOnOff ();
	}

}