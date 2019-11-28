using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {

	public Text voceMorreu;
	public Text subTitulo;

	public Image damageImage;
	public Color flashColor = new Color (1f, 0f, 0f, 0.1f);
	public float flashSpeed = 5f;

	public GameObject aux;
	public GameObject aux2;

	private void Awake () {
		aux = GameObject.Find("GameController");
		aux2 = GameObject.FindGameObjectWithTag("Player");
		GameOverTextChanger (false);
	}

	private void Update () {
		CallCanvasGameOver ();
	}

	public void IsDamageImage (bool isDamageImageTrue) {
		if (isDamageImageTrue) {
			damageImage.color = flashColor;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
	}

	public void PressioneParaReiniciar () {
		if (Input.anyKeyDown) {
			SceneManager.LoadScene("Game Scene");
		}
	}

	public void GameOverTextChanger (bool state) {
		voceMorreu.enabled = state;
		subTitulo.enabled = state;
	}

	public void CallCanvasGameOver () {
		if (aux.GetComponent<GameController>().IsAliveCallback() == false) {
			aux2.GetComponent<CharacterController>().enabled = false;
			GameOverTextChanger (true);
			PressioneParaReiniciar ();
		}
	}
}
