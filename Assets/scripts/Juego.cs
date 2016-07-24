using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Juego : MonoBehaviour {
    
    private Vector2 checkActual;

    public int lvl;
    public Canvas pedos;
    public Canvas msgFinal;
    public Canvas escap;
    public huevo huevoncio;
    public playerTierra playerUno;
    public playerAire playerDos;
    public playerAgua playerTres;
    public int vidas;
    public Text countText;
    public Button tierra;
    public Button mar;
    public Button aire;
	public Image imagen;
	public Button boton;
	public Image imagenfin;

	// Use this for initialization
	void Start () {
        tierra = tierra.GetComponent<Button>();
        mar = mar.GetComponent<Button>();
        aire = aire.GetComponent<Button>();
        tierra.enabled = false;
        mar.enabled = false;
        aire.enabled = false;
        checkActual = huevoncio.transform.position;
        playerUno.transform.position = checkActual;
        playerDos.transform.position = checkActual;
        playerDos.gameObject.SetActive(false);
        playerTres.transform.position = checkActual;
        playerTres.gameObject.SetActive(false);
        msgFinal = msgFinal.GetComponent<Canvas>();
        msgFinal.enabled = false;
        escap = escap.GetComponent<Canvas>();
        escap.enabled = false;
        pedos = pedos.GetComponent<Canvas>();
        pedos.enabled = false;
        countText.text = "REENCARNACIONES " + vidas.ToString();
        huevoncio.animationRespawn();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            escap.enabled = true;
        }
	}

	void DisplayWinImage (){
		imagen.gameObject.SetActive (true);
		boton.gameObject.SetActive (true);
	}

    public void Respawn(int i)
    {
        tierra.enabled = false;
        mar.enabled = false;
        aire.enabled = false;
        pedos.enabled = false;
      
        if (vidas > 0)
        {
            vidas--;
            countText.text = "REENCARNACIONES: " + vidas.ToString();
            
            if (i == 1)
            {
                playerUno.transform.position = checkActual;
                playerUno.gameObject.SetActive(true);
				playerUno.SendMessage ("Revivir");
                playerDos.transform.position = checkActual;
                playerDos.gameObject.SetActive(false);
                playerTres.transform.position = checkActual;
                playerTres.gameObject.SetActive(false);
                huevoncio.animationRespawn();
                esperar(1.5f);
            }
            if (i == 2)
            {
                playerDos.transform.position = checkActual;
				playerDos.gameObject.SetActive(true);
				playerDos.SendMessage ("Revivir");
                playerUno.transform.position = checkActual;
                playerUno.gameObject.SetActive(false);
                playerTres.transform.position = checkActual;
                playerTres.gameObject.SetActive(false);
                huevoncio.animationRespawn();
                esperar(1.5f);
            }
            if (i == 3)
            {
                playerTres.transform.position = checkActual;
				playerTres.gameObject.SetActive(true);
				playerTres.SendMessage ("Revivir");
                playerDos.transform.position = checkActual;
                playerDos.gameObject.SetActive(false);
                playerUno.transform.position = checkActual;
                playerUno.gameObject.SetActive(false);

                huevoncio.animationRespawn();
                esperar(1.5f);
            }
        }
        else
        {
            gameOver();
        }

    }

    public void cambiaCheckpoint(Vector2 ckpoint)
    {
        checkActual = ckpoint;
    }

    public void gameOver()
    {
        msgFinal.enabled = true;
    }

    public void pressYes()
    {
        Application.LoadLevel(lvl);
    }
    public void pressNo()
    {
        Application.LoadLevel(0);
    }

    public void pressContinue()
    {
        escap.enabled = false;
    }

    public void salir()
    {
        Application.Quit();
    }

    public void dameVida()
    {
        if (vidas >= 1)
        {
         pedos.enabled = true;
         tierra.enabled = true;
         mar.enabled = true;
         aire.enabled = true;
        }
        else
        {
            gameOver();
        }
    }
    IEnumerator esperar(float i)
    {
        yield return new WaitForSeconds(i);
    }

    public void nextLevel()
	{
		if (lvl == 3) {
			imagenfin.gameObject.SetActive(true);
		} else DisplayWinImage ();

    }

	public void changeLevel() {
		if (lvl == 1) {
			Application.LoadLevel (2);
		} else if (lvl == 2) {
			Application.LoadLevel (3);
		} else if (lvl == 3) {
			//Lo hago arriba
		} else {
			Application.LoadLevel(0);
		}
	}
}
