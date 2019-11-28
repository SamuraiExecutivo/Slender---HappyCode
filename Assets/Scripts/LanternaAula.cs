using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternaAula : MonoBehaviour {

	private GameObject go;
	private bool estaLigado;


	void Start () {
		go = this.gameObject;
		go.GetComponentInChildren<Light> ().enabled = false;
		estaLigado = false;
	}
	

	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			estaLigado = !estaLigado;
			go.GetComponentInChildren<Light> ().enabled = estaLigado;
		}
	}
}
