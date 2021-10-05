using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelojGeneral : MonoBehaviour
{
    public float tiempo;
    public Text tiempotxt;
    public Sprite[] estrellas;
    public Image estrel;
    public GameObject player;
    public GameObject panel;
    public GameObject botonNivelSuperado;
    public GameObject botonNivelNoSuperado;
    public EscenaManager nivel_superado;
    public Entregador monedas;
    public int minimoPuntaje;

    // Start is called before the first frame update
    private void Awake()
    {
       

    }
    void Start()
    {
        //tiempotxt.text = "2:00";
    }

    // Update is called once per frame
    void Update()
    {
        estrel.sprite = estrellas[1];
        CalcularTiempo();
        if (tiempo<=0)
        {
            tiempotxt.text = 0 + ":" + 0;

            player.GetComponent<CharacterController>().enabled = false;
            panel.SetActive(true);
            estrel.sprite = estrellas[0];
            if (monedas.total >= minimoPuntaje)
            {
                botonNivelSuperado.SetActive(true);
                if (monedas.total==minimoPuntaje)
                {
                    estrel.sprite = estrellas[1];
                }
                else if (monedas.total>=minimoPuntaje*2&&monedas.total<minimoPuntaje*4)
                {
                    estrel.sprite = estrellas[2];
                }
                else if (monedas.total>=minimoPuntaje*4)
                {
                    estrel.sprite = estrellas[3];
                }
            }
            else
            {
                botonNivelNoSuperado.SetActive(true);
            }
        }


    }
    void CalcularTiempo()
    {
        tiempo -= Time.deltaTime;
        int minutos = (int)tiempo / 60;
        int segundos = (int)tiempo % 60;
        tiempotxt.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2, '0');
    }
}
