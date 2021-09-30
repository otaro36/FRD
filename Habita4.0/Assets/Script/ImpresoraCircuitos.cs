using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpresoraCircuitos : MonoBehaviour
{
    public GameObject obleadeCircuitos;
    public GameObject grafeno;
    public GameObject fabrica;
    public Transform instanciaCarcasa;
    public Transform instanciaAglinato;
    public int objetoCreado;
    public float time;
    private void Update()
    {
        switch (objetoCreado)
        {
            case 1:
                StartCoroutine("Impresion");
                Instantiate(grafeno, instanciaAglinato.position, Quaternion.identity);
                objetoCreado = 0;
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grafeno")
        {
            fabrica = other.gameObject;
            objetoCreado = 1;
        }
        else if (other.tag != "Player" && other.tag != "Impresora3d")
        {
            Destroy(other.gameObject);
        }
    }
    IEnumerator Impresion()
    {

        yield return new WaitForSecondsRealtime(time);
        Destroy(fabrica.gameObject);
        yield return new WaitForSecondsRealtime(0.2f);
        Instantiate(obleadeCircuitos, instanciaCarcasa.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(time);
    }
}
