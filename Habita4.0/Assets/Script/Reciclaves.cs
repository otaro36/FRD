using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciclaves : MonoBehaviour
{
    public GameObject recoleta;
    public GameObject objetoRecogido=null;
    public int j;
    public int i;





    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Objetos")
        {
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.position = recoleta.transform.position;
            other.gameObject.transform.SetParent(recoleta.gameObject.transform);
            objetoRecogido = other.gameObject;
            print(i);
        }
    }
}
