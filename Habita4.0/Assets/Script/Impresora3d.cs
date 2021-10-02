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
    public int objeto1;
    public int objeto2;
    public int objeto3;
    public int objeto4;
    public int impresiones;
    public float timePreparacion;
    public float time;
    private void Update()
    {
        objetoCreado = objeto1 + objeto2;
        if (objetoCreado!=0)
        {
            StartCoroutine("Convinaciones");
            switch (impresiones)
            {
                case 1:
                    StartCoroutine("Impresion");
                    objeto1 = 0;
                    objeto2 = 0;
                    objetoCreado = 0;
                    break;
                case 3:
                    StartCoroutine("Olivo");
                    objeto1 = 0;
                    objeto2 = 0;
                    objetoCreado = 0;
                    break;
            }
            

        }
        print(0);
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag== "Alga")
        {
            colliAlga = other.gameObject;
            objeto1 = 1;
        }
        else if (other.tag== "Grafeno")
        {
            colliGrafeno = other.gameObject;
            objeto2 = 2;
        }
        else if (other.tag!="Player"&&other.tag!="Impresora3d")
        {
            destruido = other.gameObject;
            Destroy(other.gameObject);
        }
    }
    IEnumerator Convinaciones()
    {
        yield return new WaitForSecondsRealtime(10f);
        impresiones = objetoCreado;
        print(1);
    }
    IEnumerator Impresion()
    {
        Destroy(colliAlga.gameObject);
        yield return new WaitForSecondsRealtime(0.2f);
        Instantiate(carcasa, instanciaImpresora3D.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(time);
        Instantiate(aglinato, instanciaAglinato.position, Quaternion.identity);
    }
    IEnumerator Olivo()
    {
        Destroy(colliGrafeno.gameObject);
        Destroy(colliAlga.gameObject);
        yield return new WaitForSecondsRealtime(0.2f);
        Instantiate(olivo, instanciaImpresora3D.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(time);
        Instantiate(aglinato, instanciaAglinato.position, Quaternion.identity);
        Instantiate(aglinato, instanciaAglinato.position, Quaternion.identity);
    }
}
