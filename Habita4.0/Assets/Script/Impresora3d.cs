using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impresora3d : MonoBehaviour
{
    public GameObject carcasa;
    public GameObject aglinato;
    public GameObject fabrica;
    public Transform instanciaCarcasa;
    public Transform instanciaAglinato;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag== "Alga")
        {
            Destroy(other.gameObject);
            Instantiate(carcasa, instanciaCarcasa.position, Quaternion.identity);
            Instantiate(aglinato, instanciaAglinato.position, Quaternion.identity);
        }
        else if (other.tag!="Player")
        {
            Destroy(other.gameObject);
        }

    }
}
