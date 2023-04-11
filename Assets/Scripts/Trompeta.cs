using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trompeta : Instrumento {

    // Start is called before the first frame update
    new void Start() {

        puntosCoste = 25f;
        puntosInSegundo = 1.4f;
        incrementoCoste = 1.8f;
        cantidadInstrumento = 0f;
        base.Start();

    }

    // Update is called once per frame
    new void Update() {
        base.Update();
    }

    protected override void OnMouseOver()
    {
        // Si pulsa con el botón principal del ratón en el instrumento, se activa o desactiva el sonido del mismo
        if (Input.GetMouseButtonDown(0) || primeracompra)
        {
            SonidoReproducir();
            if (sonidoVolumen == 1)
            {
                GetComponentInChildren<SpriteRenderer>().color = Color.white;
            }
            else
            {
                GetComponentInChildren<SpriteRenderer>().color = Color.black;
            }


            primeracompra = false;
        }
    }

}