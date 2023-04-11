using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    // variable que nos sirve para controlar desde otros scripts y este funciones cuando el menu esta pausado
    public static bool GameIsPaused = false;

    // gos necesarios para poder manejar el menu de pausa
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public GameObject buyButton;
    public GameObject buyMenuUI;

    // Update is called once per frame
    void Update()
    {
        // controlamos que se pueda pausar el menu con la tecla esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        // desactivamos el menu de pausa
        pauseMenuUI.SetActive(false);
        // activamos el boton que sirve para pausar
        pauseButton.SetActive(true);
        buyButton.SetActive(true);
        // devolvemos la escala de tiempo del juego a 1
        Time.timeScale = 1f;
        // ponemos que el juego ya no esta pausado
        GameIsPaused = false;
    }

    public void Pause()
    {
        // ponemos que el juego esta pausado
        GameIsPaused = true;
        // activamos el menu de pausa
        pauseMenuUI.SetActive(true);
        // desactivamos el boton que pausa el juego 
        pauseButton.SetActive(false);
        buyButton.SetActive(false);
        buyMenuUI.SetActive(false);
        // hacemos que la escala de tiempo del juego sea 0 para que no pase el mismo
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        // aqui se hace la llamda para cargar la escena del menu comando comentado y tenemos un debug en su lugar
        Debug.Log("Cargando menu.....");
        //SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        // aqui se hace la llamada para cerrar el juego
        // como no tiene sentido tenerla mientras estamos en modo desarrollo esta comentada y tenemos un debug en su lugar
        Debug.Log("Cerrando juego.....");
        //Application.Quit();
    }
}
