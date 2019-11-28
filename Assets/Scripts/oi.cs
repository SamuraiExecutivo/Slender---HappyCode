using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class oi : MonoBehaviour {

	public bool venceu;
	public bool perdeu;

	public int comidaTotal;
	public int comidaCerto;
	public int comidaErrado;
	public int vida;

	public bool comidaColider;

	void Awake () {
		comidaTotal = 10;
		comidaCerto = 0;
		comidaErrado = 0;
		venceu = false;
		perdeu = false;
		vida = 3;
	}

	void Update () {

	}

	public void GameWin () {
		if (comidaTotal == 0 && comidaCerto >= 7) {
			venceu = true;
		}
	}

	public void GameOver () {
		if (comidaErrado >= 3 || vida == 0) {
			perdeu = true;
			SceneManager.LoadScene (0);
		}
	}

	public void PegaComida () {

	}

	public void EntregaComida (string comida, string container) {
		if (comida == "agua" && container == "aguaContainer") {
			comidaCerto++;
		} else if (comida == "coco" && container == "cocoContainer") {
			comidaCerto++;
		} else {
			comidaErrado++;
		}
	}

	public void EntregaComidaOK (int value) {
		comidaTotal--;
		comidaCerto += value;
		comidaErrado -= value;
	}

	public void EntregaComidaREs (string comida, string cont) {
		if ((comida == "agua" && cont == "aguaContainer") ||
			(comida == "coco" && cont == "cocoContainer"))
			comidaCerto++;
		else
			comidaErrado++;
	}
}