using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bajo : Instrumento {

    // Start is called before the first frame update
    void Start() {

        puntosCoste = 15f;
        puntosInSegundo = 1f;
        incrementoCoste = 1.4f;
        cantidadInstrumento = 0f;
        base.Start();

    }

    // Update is called once per frame
    void Update() {
        base.Update();
    }

    protected override void OnMouseOver() {

        if (Input.GetMouseButtonDown(0)) {
            if (Compra()) {
                GameManager.instance.RestarPuntos(puntosCoste);
                CosteInstrumento();
            }
        }

    }

}