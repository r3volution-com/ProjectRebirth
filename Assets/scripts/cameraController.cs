using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;

	private Vector3 offset;

	void Start () {
		offset = transform.position - player1.transform.position;
	}

	void LateUpdate () {
		if (player1.activeSelf) transform.position = player1.transform.position + offset;
		else if (player2.activeSelf) transform.position = player2.transform.position + offset;
		else if (player3.activeSelf) transform.position = player3.transform.position + offset;
	}
}