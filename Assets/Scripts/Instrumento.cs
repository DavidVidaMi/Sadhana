using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// clase padre que tendran que heredar todos los instrumentos
public abstract class Instrumento : MonoBehaviour
{
    // puntos que da el intrumento al hacer click
    protected int puntosInstrumento;
    // putnos que da el instrumento de forma pasiva cada segundo, si no los da iniciar con un 0
    protected int puntosInSegundo;
    // variable el cual se usa para controlar el aumento de precio en los instrumentos
    protected float incrementoCoste;
    // variable que guarda la cantidad de instrumentos que tienes, ej: cantidad_instrumento = 2 tendria 2 trompetas
    protected int cantidadInstrumento;
    // variable donde guardar el clip de audio que tendra el instrumento
    public AudioClip sonido;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void CuentaPuntos()
    {
        // depuracion TODO eliminar en versiones finales
        print("clase padre puntos:" + puntosInstrumento);
        // llamada al GameManager para que sume puntos
        GameManager.instance.SumarPuntuacion(puntosInstrumento * cantidadInstrumento);
    }


    protected void SonidoReproducir()
    {
        GameManager.instance.Sonido(sonido);
    }

    // metodo que controla cuando el raton se pone encima del GO
    protected abstract void OnMouseOver();
}
