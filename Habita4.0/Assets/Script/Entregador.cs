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
    public Animator anim;
    
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
            receta[2].SetActive(false);


        }
        else if (i==1)
        {
            receta[0].SetActive(false);
            receta[1].SetActive(true);
            receta[2].SetActive(false);
        }
        else if (i==2)
        {
            receta[0].SetActive(false);
            receta[1].SetActive(false);
            receta[2].SetActive(true);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag==receta[i].tag)
        {
            if (other.tag== "Carcasa"||other.tag== "ObleaCircuitos")
            {
                total += 100;
            }
            else if (other.tag== "CeldaEnergia")
            {
                total += 200;
            }
            
            Destroy(other.gameObject);
            i++;
            if (i>2)
            {
                i = 0;
            }
        }
        else if (other.tag!=receta[i].tag&&other.tag!="Player")
        {

            Destroy(other.gameObject);
            total -= 100;
            
        }
        else if (other.tag== "Player")
        {
            anim.SetBool("Coger",false);
        }
        monedas.text = total.ToString();
    }
}
