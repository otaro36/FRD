using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    public bool coger = true;
    public bool creado = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {

            other.GetComponentInParent<CogerObjectos>().cogerObjeto = this.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag== "Player")
        {
            other.GetComponentInParent<CogerObjectos>().cogerObjeto = null;
        }
    }
}
