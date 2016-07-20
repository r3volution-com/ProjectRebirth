using UnityEngine;
using System.Collections;

public class PalancaController : MonoBehaviour {
    private bool activada=false;
    private SpriteRenderer spriteRenderer;

    public Sprite sprite1;
    public Sprite sprite2;
    public PuertaController puerta;
	// Use this for initialization
	void Start () {
        activada = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = sprite1;
        }
	}
	
    public void onActivated()
    {
        if (activada == false)
        {
            activada = true;
            spriteRenderer.sprite = sprite2;
            puerta.changeStatus();
        }
    }
}
