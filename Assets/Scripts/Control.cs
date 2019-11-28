using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour {

	public bool venceu, perdeu, comidaColider;

	public int comidaTotal, comidaCerto, comidaErrado, vida;
	public MonoBehaviour GameWinUI, GameOverUI;
	private string txtComidaTotal, txtComidaCerto, txtComidaErrado;
	private float x, y;

	void Awake () {
		comidaTotal = 10;
		comidaCerto = 0;
		comidaErrado = 0;
		venceu = false;
		perdeu = false;
		vida = 3;

		GameWinUI = GetComponent<GameWin>() as GameWin;
		GameOverUI = GetComponent<GameOver>() as GameOver;
		GameWinUI.enabled = false;
		GameOverUI.enabled = false;
	}

	void Update () {
		txtComidaTotal = "Comida: " + comidaTotal;
		txtComidaErrado = "Errou: " + comidaErrado;
		txtComidaCerto = "Acertou: " + comidaCerto;

		x = Screen.width;
		y = Screen.height;

		if (comidaTotal == 0 && comidaErrado < vida) GameWin ();
		if (vida <= 0) GameOver ();

	}

	public void GameWin () {
		venceu = true;
		GameWinUI.enabled = true;
		Time.timeScale = 0;
		if (Input.GetKeyDown (KeyCode.Escape)) SceneManager.LoadScene ("Game");
	}

	public void GameOver () {
		perdeu = true;
		GameOverUI.enabled = false;
		Time.timeScale = 0;
		if (Input.GetKeyDown (KeyCode.Escape)) SceneManager.LoadScene ("Game");
	}

	public void EntregaComida (string item, string cont) {
		comidaTotal--;
		if ((item == "agua" && cont == "contAgua") ||
			(item == "comida" && cont == "contComida"))
			comidaCerto++;
		else {
			vida--;
			comidaErrado++;
		}
	}

	void OnGUI () {
		GUI.Box (new Rect (2 * x / 5, 0, x / 5, y / 10), txtComidaTotal);
		GUI.Box (new Rect (2 * x / 5, y / 10, x / 5, y / 10), txtComidaCerto);
		GUI.Box (new Rect (2 * x / 5, 2 * y / 10, x / 5, y / 10), txtComidaErrado);
	}
}