using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

	public GameObject controller, pegaTarget;
	public bool pegaObj = false;

	void Start () {
		controller = GameObject.Find ("GameController");
	}

	void Update () {
		if (pegaObj) transform.position = pegaTarget.transform.position;
	}

	void OnTriggerStay (Collider other) {
		if (other.tag == "Player") {
			PegarSoltar ();
		}

		if (!pegaObj) {
			if (other.tag == "contAgua" || other.tag == "contComida") {
				controller.GetComponent<Control> ().EntregaComida (this.tag, other.tag);
				Destroy (this.gameObject);
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			PegarSoltar ();
		}

		if (!pegaObj) {
			if (other.tag == "contAgua" || other.tag == "contComida") {
				controller.GetComponent<Control> ().EntregaComida (this.tag, other.tag);
				Destroy (this.gameObject);
			}
		}
	}

	bool PegarSoltar () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			pegaObj = true;
			return false;
		}
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			pegaObj = false;
			return true;
		}
		return false;
	}
}