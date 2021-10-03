using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesadeRecoleccion : MonoBehaviour
{
    public GameObject placacircuitos;
    public GameObject carcasa;
    public GameObject celdaEnergia;
    public Transform instancia;
    public Animator encendido;
    public Animator recolecta;
    public Animator procesado;
    public Animator entrega;
    public int mezclas;
    public int placa;
    public int carca;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mezclas = placa + carca;
        if (Input.GetKeyDown(KeyCode.E))
        {
            //StartCoroutine("CeldaEnergia");
            print(1);
            switch (mezclas)
            {
                case 2:
                    StartCoroutine("CeldaEnergia");
                    mezclas = 0;
                    placa = 0;
                    carca = 0;
                    break;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag== "ObleaCircuitos")
        {
            placacircuitos = other.gameObject;
            placa = 1;
        }
        else if (other.tag=="Carcasa")
        {
            carcasa = other.gameObject;
            carca = 1;
        }
    }
    IEnumerator CeldaEnergia()
    {
        
        recolecta.SetBool("recolecta",true);
        yield return new WaitForSecondsRealtime(1f);
        Destroy(placacircuitos);
        Destroy(carcasa);
        yield return new WaitForSecondsRealtime(1f);
        recolecta.SetBool("procesado", true);
        yield return new WaitForSecondsRealtime(5f);
        recolecta.SetBool("entrega", true);
        yield return new WaitForSecondsRealtime(1f);
        Instantiate(celdaEnergia, instancia.position, Quaternion.identity);
        recolecta.SetBool("encendido", true);
        recolecta.SetBool("recolecta", false);
        recolecta.SetBool("procesado", false);
        recolecta.SetBool("entrega", false);



    }
}
