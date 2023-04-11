using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCompra : MonoBehaviour
{
    public static bool MenuOpen = false;

    public GameObject compraMenuUI;
    public GameObject buyButton;
    public GameObject closebuyButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // controlamos que se pueda pausar el menu con la tecla esc
        if (Input.GetKeyDown(KeyCode.I) && !MenuPausa.GameIsPaused)
        {
            if (MenuOpen)
            {
                CloseBuyMenu();
            }
            else
            {
                OpenBuyMenu();
            }
        }
    }

    public void OpenBuyMenu()
    {
        compraMenuUI.SetActive(true);

        buyButton.SetActive(false);

        MenuOpen = true;
    }

    public void CloseBuyMenu()
    {
        compraMenuUI.SetActive(false);

        buyButton.SetActive(true);

        MenuOpen = false;
    }
}
