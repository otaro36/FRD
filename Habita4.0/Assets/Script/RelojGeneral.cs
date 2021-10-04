using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelojGeneral : MonoBehaviour
{
    public float tiempo;
    public Text tiempotxt;
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
        tiempo = 60;
        //tiempotxt.text = "2:00";
    }

    // Update is called once per frame
    void Update()
    {
        CalcularTiempo();
        if (tiempo<=0)
        {
            tiempotxt.text = 0 + ":" + 0;

            player.GetComponent<CharacterController>().enabled = false;
            panel.SetActive(true);
            if (monedas.total >= minimoPuntaje)
            {
                botonNivelSuperado.SetActive(true);
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
