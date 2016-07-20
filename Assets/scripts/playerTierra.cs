using UnityEngine;
using System.Collections;

public class playerTierra : MonoBehaviour {

	private Animator animator;
	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;

	private bool goingRight = true;

    public Juego juego;

	public bool muerto = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		boxCollider = GetComponent <BoxCollider2D> ();
		rb2D = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		int horizontal = 0;

		if (!muerto) horizontal = (int)Input.GetAxisRaw ("Horizontal");

		if (horizontal > 0) {
			animator.SetTrigger ("playerTierraWalk");
			if (goingRight != true) {
				animator.transform.Rotate (0, 180, 0);
				goingRight = true;
			}
		} else if (horizontal < 0) {
			animator.SetTrigger ("playerTierraWalk");
			if (goingRight == true) {
				animator.transform.Rotate (0, 180, 0);
				goingRight = false;
			}

		} else if (muerto == false) {
			animator.CrossFade ("playerTierraIdle", 0);
		}

		if (rb2D.velocity.y == 0 && Input.GetButtonDown ("Jump") && muerto == false) {
			rb2D.AddForce (new Vector2 (0, 5), ForceMode2D.Impulse);
		}

		if (Input.GetKeyDown (KeyCode.X) && muerto == false) {
			Die ();
		}

		if (Input.GetButtonDown ("Fire1") && muerto == false) {
			animator.CrossFade ("playerTierraChop", 0.5f);
		}

		Vector3 move = new Vector3 (horizontal, 0, 0)/25;
		transform.position = transform.position + move;
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Wall") {
			if (Input.GetButtonDown ("Fire1")) {
				other.gameObject.SetActive (false);
			}
		} else if (other.gameObject.tag == "Spikes") {
			Die ();
		} else if (other.gameObject.tag == "Water") {
			Die ();
		} else if (other.gameObject.tag == "Switch") {
			other.gameObject.SendMessage ("onActivated");
		} else if (other.gameObject.tag == "Exit") {
			if (!muerto) animator.CrossFade ("playerTierraDie", 1.0f);
			muerto = true;
			esperar(1.0f);
			juego.nextLevel ();
		}
	}

	void Revivir(){
		muerto = false;
	}

	void Die() {
		if (!muerto) animator.CrossFade("playerTierraDie", 1.0f);
		muerto = true;
		esperar(1.5f);
		juego.dameVida();
    }

    IEnumerator esperar(float i)
    {
        yield return new WaitForSeconds(i);
    }
}
