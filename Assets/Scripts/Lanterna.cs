using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanterna : MonoBehaviour {

	bool flashLightRequest;
	private GameObject aux;

	private void Start() {
		flashLightRequest = false;
	}

	private void OnTriggerStay(Collider collider) {
		if (collider.tag == "Player") {
			if (Input.GetKeyDown(KeyCode.E)) {
				aux = collider.gameObject;
				flashLightRequest = true;				
			}
		}
	}

	private void Update() {
		aux.GetComponentInChildren<FlashLightManager>().PegarLanterna();
		Destroy(this.gameObject);
	}
}
