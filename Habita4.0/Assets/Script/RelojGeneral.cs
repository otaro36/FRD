using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelojGeneral : MonoBehaviour
{
    public float tiempo;
    public Text tiempotxt;
    public GameObject player;
    public GameObject canvas;


    // Start is called before the first frame update
    void Start()
    {
        tiempo = 120;
        tiempotxt.text = "2:00";
    }

    // Update is called once per frame
    void Update()
    {
        CalcularTiempo();
        if (tiempo<=0)
        {
            tiempotxt.text = 0 + ":" + 0;
            player.GetComponent<CharacterController>().enabled = false;
            canvas.SetActive(true);
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
