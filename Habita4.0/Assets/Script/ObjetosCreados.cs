using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosCreados : MonoBehaviour
{
    public bool coger = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            other.GetComponentInParent<CogerObjectos>().cogerObjeto = this.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInParent<CogerObjectos>().cogerObjeto = null;
        }
    }
}
