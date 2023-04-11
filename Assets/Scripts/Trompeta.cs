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

    protected override void OnMouseOver() {

        // Si pulsa con el botón principal del ratón en el instrumento,
        // comprobamos si tiene suficientes puntos para canjear.
        // En caso afirmativo, restamos los puntos de coste del instrumento
        // y actualizamos los puntos que costará el siguiente instrumento.
        if (Input.GetMouseButtonDown(0) || buttonPresed) {
            if (Compra()) {
                GameManager.instance.RestarPuntuacion(puntosCoste);
                CosteInstrumento();
            }
        }

    }

}