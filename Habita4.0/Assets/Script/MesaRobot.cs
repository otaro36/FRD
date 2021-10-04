using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaRobot : MonoBehaviour
{
    public GameObject placacircuitos;
    public GameObject carcasa;
    public GameObject celdaEnergia;
    public Transform instancia;
    public Animator animaRobot;
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
        if (other.tag == "ObleaCircuitos")
        {
            placacircuitos = other.gameObject;
            placa = 1;
        }
        else if (other.tag == "Carcasa")
        {
            carcasa = other.gameObject;
            carca = 1;
        }
    }
    IEnumerator CeldaEnergia()
    {

        animaRobot.SetBool("recolecta", true);
        yield return new WaitForSecondsRealtime(1f);
        Destroy(placacircuitos);
        Destroy(carcasa);
        yield return new WaitForSecondsRealtime(1f);
        animaRobot.SetBool("procesado", true);
        yield return new WaitForSecondsRealtime(5f);
        animaRobot.SetBool("entrega", true);
        yield return new WaitForSecondsRealtime(1f);
        Instantiate(celdaEnergia, instancia.position, Quaternion.identity);
        animaRobot.SetBool("encendido", true);
        animaRobot.SetBool("recolecta", false);
        animaRobot.SetBool("procesado", false);
        animaRobot.SetBool("entrega", false);



    }
}
