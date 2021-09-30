using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impresora3d : MonoBehaviour
{
    public GameObject carcasa;
    public GameObject aglinato;
    public GameObject fabrica;
    public GameObject destruido;
    public Transform instanciaCarcasa;
    public Transform instanciaAglinato;
    public Transform instanciaGrafeno;
    public Transform instanciaAntena;
    public int objetoCreado;
    public float time;
    private void Update()
    {
        switch (objetoCreado)
        {
            case 1:            
                StartCoroutine("Impresion");
                Instantiate(aglinato, instanciaAglinato.position, Quaternion.identity);
                objetoCreado = 0;
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag== "Alga")
        {
            fabrica = other.gameObject;
            objetoCreado = 1;
        }
        else if (other.tag!="Player"&&other.tag!="Impresora3d")
        {
            destruido = other.gameObject;
            Destroy(other.gameObject);
        }
    }
    IEnumerator Impresion()
    {

        yield return new WaitForSecondsRealtime(time);
        Destroy(fabrica.gameObject);
        yield return new WaitForSecondsRealtime(0.2f);
        Instantiate(carcasa, instanciaCarcasa.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(time);
    }
}
