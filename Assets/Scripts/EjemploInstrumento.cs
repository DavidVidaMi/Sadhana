using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploInstrumento : Instrumento
{
    // Start is called before the first frame update
    void Start()
    {
        puntosCoste = 10f;
        puntosInSegundo = 1f;
        incrementoCoste = 1.2f;
        cantidadInstrumento = 1f;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    protected override void OnMouseOver(){
        if (Input.GetMouseButtonDown(0)){
            if(Compra()){
                GameManager.instance.RestarPuntuacion(puntosCoste);
                CosteInstrumento();
            }
        }
    }
}
