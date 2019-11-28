using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	private GameObject player;
	NavMeshAgent agent;
	public float teleportTime;
	bool canTeleport;
	public GameObject gameC;
	private Animator anim;
	public bool isDamaging;
	private GameObject Canvas;

	private void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		agent = this.gameObject.GetComponent<NavMeshAgent> ();
		canTeleport = true;
		anim = GetComponentInChildren<Animator> ();
		Canvas = GameObject.Find ("Canvas");
		isDamaging = false;
	}

	public void ChasePlayer () {
		Transform aux = player.GetComponent<Transform> ();
		float distance = Vector3.Distance (aux.position, transform.position);

		if (distance <= 3f) {
			agent.enabled = false;
			anim.SetInteger ("state", 1);
		} else {
			agent.enabled = true;
			anim.SetInteger ("state", 1);
			agent.destination = player.transform.position;
		}
	}

	public void Teleport () {
		if (canTeleport) {
			this.gameObject.transform.position = new Vector3 (player.transform.position.x - 10,
				player.transform.position.y,
				player.transform.position.z - 10);
			anim.SetInteger ("state", 0);
		} else {
			StartCoroutine (CDTeleport ());
			anim.SetInteger ("state", 0);
		}
	}

	IEnumerator CDTeleport () {
		yield return new WaitForSeconds (teleportTime);
		canTeleport = true;
	}

	void StopAttacking () {
		if (gameC.GetComponent<GameController> ().vida <= 0) {
			anim.SetInteger ("state", 0);
		}
	}

	private void Update () {
		Transform aux = player.GetComponent<Transform> ();
		float dist = Vector3.Distance (aux.position, transform.position);

		if (dist >= 60f) {
			Teleport ();
			isDamaging = false;
		} else if (dist <= 30f) {
			ChasePlayer ();
			isDamaging = false;
		}

		if (dist <= 1) {
			gameC.gameObject.GetComponent<GameController> ().TakeDamage ();
			anim.SetInteger ("state", 2);
			isDamaging = true;
		}

		StopAttacking ();

		if (isDamaging) {
			Canvas.GetComponent<CanvasController> ().IsDamageImage (true);
		} else {
			Canvas.GetComponent<CanvasController> ().IsDamageImage (false);
		}

	}

}