using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerObjectos : MonoBehaviour
{
    public GameObject cogerObjeto;
    public GameObject objetoCogido;
    public Transform zonaInteraccion;
    public Animator anim;


    // Update is called once per frame
    void Update()
    {
        if (cogerObjeto != null && cogerObjeto.GetComponent<Objetos>().coger == true && cogerObjeto.GetComponent<Objetos>().creado == false && objetoCogido == null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //objetoCogido = cogerObjeto;
                anim.SetBool("Coger", true);
                objetoCogido = Instantiate(cogerObjeto, zonaInteraccion.position, Quaternion.identity);
                objetoCogido.GetComponent<Objetos>().coger = false;
                objetoCogido.GetComponent<Objetos>().creado = true;
                objetoCogido.transform.SetParent(zonaInteraccion);
                objetoCogido.transform.position = zonaInteraccion.position;
                objetoCogido.GetComponent<BoxCollider>().isTrigger = true;
                objetoCogido.GetComponent<Rigidbody>().useGravity = false;
                objetoCogido.GetComponent<Rigidbody>().isKinematic = true;
            }

        }
        else if (cogerObjeto != null && cogerObjeto.GetComponent<Objetos>().coger == true && cogerObjeto.GetComponent<Objetos>().creado == true && objetoCogido == null)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Coger", true);
                objetoCogido = cogerObjeto;
                objetoCogido.GetComponent<Objetos>().coger = false;
                objetoCogido.transform.SetParent(zonaInteraccion);
                objetoCogido.transform.position = zonaInteraccion.position;
                objetoCogido.GetComponent<BoxCollider>().isTrigger = true;
                objetoCogido.GetComponent<Rigidbody>().useGravity = false;
                objetoCogido.GetComponent<Rigidbody>().isKinematic = true;
            }

        }
        else if (objetoCogido != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Coger", false);
                objetoCogido.GetComponent<Objetos>().coger = true;
                objetoCogido.transform.SetParent(null);
                objetoCogido.GetComponent<Rigidbody>().useGravity = true;
                objetoCogido.GetComponent<Rigidbody>().isKinematic = false;
                objetoCogido.GetComponent<BoxCollider>().isTrigger = false;
                objetoCogido = null;
            }
        }

    }
}
