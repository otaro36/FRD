using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Impresora3d : MonoBehaviour
{   //Instancia elementos de la mesa
    public GameObject aglinato;
    public GameObject grafeno;
    public GameObject antena5G;
    public Transform instanciaGrafeno;
    public Transform instanciaAglinato;
    public Transform instanciaAntena;
    //Instancia elemento en la impresora
    public GameObject carcasa;
    public GameObject olivo;
    public Transform instanciaImpresora3D;
    //Asignacion a elementos vacios en colision
    public GameObject colliAlga;
    public GameObject colliGrafeno;
    public GameObject colliDestruido;

    public GameObject destruido;
    public Slider tiempoCreacion;
    public int objetoCreado;
    public float time;
    private void Update()
    {
            switch (objetoCreado)
            {
                case 1:
                    StartCoroutine("Carcasa");
                    objetoCreado = 0;
                    break;
                case 2:
                    StartCoroutine("Olivo");
                    objetoCreado = 0;
                    break;
            }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag== "Alga")
        {
            colliAlga = other.gameObject;
            objetoCreado = 1;
        }
        else if (other.tag== "Grafeno")
        {
            colliGrafeno = other.gameObject;
            objetoCreado = 2;
        }
        else if (other.tag!="Player"&&other.tag!="Impresora3d")
        {
            destruido = other.gameObject;
            Instantiate(antena5G, instanciaAntena.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
    IEnumerator Carcasa()
    {
        yield return new WaitForSecondsRealtime(5F);
        Destroy(colliAlga.gameObject);
        yield return new WaitForSecondsRealtime(0.2f);
        Instantiate(carcasa, instanciaImpresora3D.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(time);
        Instantiate(aglinato, instanciaAglinato.position, Quaternion.identity);
    }
    IEnumerator Olivo()
    {
        yield return new WaitForSecondsRealtime(5F);
        Destroy(colliGrafeno.gameObject);
        yield return new WaitForSecondsRealtime(0.2f);
        Instantiate(olivo, instanciaImpresora3D.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(time);
        Instantiate(grafeno, instanciaGrafeno.position, Quaternion.identity);
    }
}
