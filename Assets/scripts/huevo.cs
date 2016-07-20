using UnityEngine;
//using System;
using System.Collections;

public class huevo : MonoBehaviour {


	private Animator animator;
    private bool CheckpointActive = false;
    private Vector2 checkpoint;

    public Juego juego;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CheckpointActive = true;
            checkpoint = (Vector2)gameObject.transform.position;
            if (checkpoint != null)
            {
                juego.cambiaCheckpoint(checkpoint);
            }
        }
    }

	public void animationRespawn() {
		animator.SetTrigger ("nidoRespawn");
	}

    // Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	    
	}
	
	// Update is called once per frame
	void Update () {

	}
}
