using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegaDica : MonoBehaviour {

	private GameObject aux;

	private void Start() {
		aux = GameObject.Find("GameController");
		YellowCollorChanger(false);
	}

	// Pode também criar dois métodos, um para habilitar e outro para dersabilitar
	public void YellowCollorChanger (bool estado) {
		transform.GetChild(0).gameObject.SetActive(estado);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			YellowCollorChanger(true);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			YellowCollorChanger(false);
		}
	}

	private void OnTriggerStay(Collider other) {
		if (other.tag == "Player") {
			if (Input.GetKeyDown(KeyCode.E)) {
				aux.GetComponent<GameController>().AddObjetivos();
				Destroy(this.gameObject);
			}
		}
	}
}
