using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// clase padre que tendran que heredar todos los instrumentos
[RequireComponent(typeof(AudioSource))]
public abstract class Instrumento : MonoBehaviour
{
    // puntos que cuesta el instrumento
    protected float puntosCoste;
    // putnos que da el instrumento de forma pasiva cada segundo, si no los da iniciar con un 0
    protected float puntosInSegundo;
    // variable el cual se usa para controlar el aumento de precio en los instrumentos
    protected float incrementoCoste;
    // variable que guarda la cantidad de instrumentos que tienes, ej: cantidad_instrumento = 2 tendria 2 trompetas
    protected float cantidadInstrumento;
    // variable para poder controlar cuando el usuario quiere que active o desactive el sonido
    protected float sonidoVolumen = 0;
    // variable para controlar si es la primera compra
    protected bool primeracompra;

    // variable para que el instrumento reproduzca el sonido todo el rato.
    private AudioSource audioSource;
    // variable para controlar el tiempo.
    private float tiempo;

    // variable donde guardar el clip de audio que tendra el instrumento
    public AudioClip sonido;
    // variable para poder controlar el texto de la interface
    public Text costeNumText;

    // Start is called before the first frame update
    protected void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (costeNumText != null)
        {
            costeNumText.text = "" + puntosCoste;
        }
        if (audioSource != null)
        {
            audioSource.clip = sonido;
            audioSource.volume = sonidoVolumen;
            audioSource.Play();
        }
        tiempo = 0f;
    }

    // Update is called once per frame
    protected void Update()
    {
        // se cuenta el tiempo por cada segundo con la incrementacion del delta time para adaptarlo al frameRate
        if(tiempo >= 1f && cantidadInstrumento > 0){

            tiempo = 0f;
            CuentaPuntos();
        }
        tiempo += Time.deltaTime;
    }

    protected virtual void CuentaPuntos()
    {
        // llamada al GameManager para que sume puntos
        GameManager.instance.SumarPuntuacion(puntosInSegundo * cantidadInstrumento);
    }

    protected virtual void CosteInstrumento(){
        // se suma 1 instrumento
        cantidadInstrumento ++;
        // se recalcula el coste del mismo
        puntosCoste = puntosCoste * incrementoCoste;
        print("nuevo conste: " +puntosCoste);
        if (costeNumText != null) {
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

    // comprobacion de si se puede comprar
    protected virtual bool Compra(){
        if ((GameManager.instance.Puntuacion - puntosCoste) >= 0)
        {
            return true;
        }else{
            return false;
        }
    }

    protected void SonidoReproducir()
    {
        
        if (sonidoVolumen == 0f)
        {
            sonidoVolumen = 1f;
            audioSource.volume = sonidoVolumen;
            print("volumen cambiado");
        }
        else
        {
            sonidoVolumen = 0f;
            audioSource.volume = sonidoVolumen;
        }

    }

    // metodo que controla cuando el raton se pone encima del GO
    protected abstract void OnMouseOver();

    public void buton()
    {
        // comprobamos si tiene suficientes puntos para canjear.
        // En caso afirmativo, restamos los puntos de coste del instrumento
        // y actualizamos los puntos que costará el siguiente instrumento.
        if (Compra())
        {
            GameManager.instance.RestarPuntuacion(puntosCoste);
            CosteInstrumento();
            if (!primeracompra && cantidadInstrumento == 1)
            {
                primeracompra = true;
                OnMouseOver();
            }
        }

        
    }
}
