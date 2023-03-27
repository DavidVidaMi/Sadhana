using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batuta : Instrumento
{
    private int puntosClic;
    public Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        puntosInstrumento = 1;   
        cantidadInstrumento = 1;
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)){
            CuentaPuntos();
        }
    }

    protected override void OnMouseOver(){

    }

}
