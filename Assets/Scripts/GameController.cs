using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public  float       vida;
    public  bool        estaVivo;
            int         qtdDicas;
    public  int         multiplicador;
    public  GameObject  boteDeFuga;
    private GameObject  jogarNovamente, sair, voceConseguiu, ajudaBote;

    private void Awake () {

        jogarNovamente  = GameObject.Find ("Canvas");
        voceConseguiu   = GameObject.Find ("Canvas");
        sair            = GameObject.Find ("Canvas");
        ajudaBote       = GameObject.Find ("Canvas");
                
        jogarNovamente.transform.GetChild(4).gameObject.SetActive(false); 
        voceConseguiu.transform.GetChild(2).gameObject.SetActive(false);
        voceConseguiu.transform.GetChild(2).gameObject.SetActive(false);     
        ajudaBote.transform.GetChild(5).gameObject.SetActive(false);
        sair.transform.GetChild(3).gameObject.SetActive(false);
    
    }

    void Start () {
        vida        = 100;
        estaVivo    = true;
        qtdDicas    = 0;
    }

    void Update () {
        ChecarVida ();
        FugaAutorizada();
    }

    public void AddObjetivos () {
        qtdDicas++;
    }

    public void TakeDamage () {
        vida -= multiplicador * Time.deltaTime;
    }

    public void ChecarVida () {
        if (vida <=0) {
            estaVivo = false;
        }
        if (!estaVivo) {
            Debug.Log ("Morreu!");
        }
    }

    public bool IsAliveCallback () {
        return this.estaVivo;
    }

    public void FugaAutorizada () {
        if (qtdDicas == 7) {
            Instantiate (boteDeFuga, new Vector3 (0.24f, 0.02f, 197.01f), Quaternion.identity);
            qtdDicas = 0;
            ajudaBote.transform.GetChild(5).gameObject.SetActive(true);
        }
    }

    public void FecharJogo () {
        Application.Quit();
    }

    public void CarregarJogo () {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }


}
 