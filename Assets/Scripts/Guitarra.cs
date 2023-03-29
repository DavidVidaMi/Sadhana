using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guitarra : Instrumento {

    // Start is called before the first frame update
    new void Start() {

        puntosCoste = 20f;
        puntosInSegundo = 1.2f;
        incrementoCoste = 1.6f;
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
        if (Input.GetMouseButtonDown(0)) {
            if (Compra()) {
                GameManager.instance.RestarPuntuacion(puntosCoste);
                CosteInstrumento();
            }
        }

    }

}