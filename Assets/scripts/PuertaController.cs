using UnityEngine;
using System.Collections;

public class PuertaController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
   public void changeStatus()
    {
        gameObject.SetActive(false);
    }

    public void changeStatusUp()
    {
        gameObject.SetActive(true);
    }
}
