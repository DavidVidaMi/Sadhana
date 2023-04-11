using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batuta : Instrumento
{
    public Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    private float incrementoClick;
    private float puntosClick;
    // Start is called before the first frame update
    new void Start()
    {
        puntosClick = 1;
        puntosCoste = 5f;  
        puntosInSegundo = 0f; 
        cantidadInstrumento = 0f;
        incrementoCoste = 1.2f;
        incrementoClick = 1f;
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        base.Start();
    }

    // Update is called once per frame
   new void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && !GameManager.instance.ElementoUI)
        {
            CuentaPuntos();
            

        }
    }

    protected override void CuentaPuntos(){
        GameManager.instance.SumarPuntuacion(puntosClick * incrementoClick);
    }

    protected override void CosteInstrumento(){
        // se recalcula el coste del mismo
        puntosCoste = puntosCoste * incrementoCoste;
        incrementoClick += 0.1f;
        if (costeNumText != null)
        {
            if ((puntosCoste * 100 - Mathf.Floor(puntosCoste * 100) != 0))
            {
                costeNumText.text = puntosCoste.ToString("F2");
            }
            else
            {
                costeNumText.text = "" + puntosCoste;
            }
        }
    }

    protected override void OnMouseOver(){
       
    }


}
