using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // instancia para metodologia singlenton
    public static GameManager instance;
    // variable para enlazar la casilla donde se monstrara la puntuacion
    public Text textoPuntos;
    // variable para la reproduccion de sonidos
    private AudioSource audioSource;
    // variable para controlar puntuacion
    private float puntuacion = 0;
    public float Puntuacion{
        get{ return puntuacion; }
    }
    private bool elementoUI = false;
    public bool ElementoUI
    {
        get { return elementoUI; }
    }

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        textoPuntos.text = $"{puntuacion}";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // metodo para la suma de puntos
    public void SumarPuntuacion(float puntos)
    {
        if (!MenuPausa.GameIsPaused)
        {
            puntuacion += puntos;
            textoPuntos.text = $"{puntuacion}";
            // depuracion por consola TODO eliminar en implementacion final
            print("puntuacion: " + puntuacion);
        }
    }

    public void RestarPuntuacion(float puntos){
        if (!MenuPausa.GameIsPaused)
        {
            puntuacion -= puntos;
            textoPuntos.text = $"{puntuacion}";
        }
    }

    // metodo para que reproduzca el sonido
    public void Sonido(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }

    public void DetectadoBoton()
    {
        print("detectado boton");
        elementoUI = true;
    }

    public void NoDetectadoBoton()
    {
        print("no detectado");
        elementoUI = false;
    }
}
