using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpresoraCircuitos : MonoBehaviour
{
    public GameObject obleadeCircuitos;
    public Transform instanciaOblea;
    public GameObject material;
    public GameObject creado;
    public int objetoCreado;

    private void Update()
    {
        switch (objetoCreado)
        {
            case 1:
                StartCoroutine("Impresion");
                objetoCreado = 0;
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grafeno")
        {
            material = other.gameObject;
            objetoCreado = 1;
        }
        else if (other.tag != "Player" && other.tag != "Impresora3d")
        {
            Destroy(other.gameObject);
        }
    }
    IEnumerator Impresion()
    {
        objetoCreado = 0;
        Destroy(material.gameObject);
        yield return new WaitForSecondsRealtime(5F);
        creado = Instantiate(obleadeCircuitos, instanciaOblea.position, Quaternion.identity);
    }
}
