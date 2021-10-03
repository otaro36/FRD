using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entregador : MonoBehaviour
{
    public GameObject entrega;
    public GameObject[] receta;
    public Text monedas;
    public Transform objetoDestruido;
    public int i;
    public int precioCarcasa;
    public int total;
    
    // Start is called before the first frame update
    void Start()
    {
        monedas.text = 0.ToString();
        i = Random.Range(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (i==0)
        {
            receta[0].SetActive(true);
            receta[1].SetActive(false);

        }
        if (i==1)
        {
            receta[0].SetActive(false);
            receta[1].SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag==receta[i].tag)
        {
            precioCarcasa += 100;
            total = precioCarcasa;
            monedas.text = total.ToString();
            Destroy(other.gameObject);
            i++;
            if (i>1)
            {
                i = 0;
            }
        }
        else if (other.tag!=receta[i].tag&&other.tag!="Player")
        {
            Destroy(other.gameObject);
            precioCarcasa -= 100;
            monedas.text = total.ToString();
        }
    }
}
