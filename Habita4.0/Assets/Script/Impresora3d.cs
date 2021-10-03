using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Impresora3d : MonoBehaviour
   
{

    //Instancia elemento en la impresora
    public GameObject carcasa;
    public Transform instanciaImpresora3D;
    //Asignacion a elementos vacios en colision
    public GameObject materia;
    public GameObject creado;
    public int objetoCreado;
    public Animator imprimiendo;
    public Timer time;
    public GameObject timer;
    void Update()
    {
        switch (objetoCreado)
        {
            case 1:
                StartCoroutine("Carcasa");
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Alga")
        {
            materia = other.gameObject;
            objetoCreado = 1;
        }
        else if (other.tag != "Player" && other.tag != "Impresora3d")
        {
            Destroy(other.gameObject);
        }
    }
    IEnumerator Carcasa()
    {
        timer.SetActive(true);
        time.SetDuration(5).Comienzo();
        objetoCreado = 0;
        Destroy(materia.gameObject);
        imprimiendo.SetBool("imprimiendo", true);
        yield return new WaitForSecondsRealtime(5F);
        timer.SetActive(false);
        imprimiendo.SetBool("imprimiendo", false);
        creado = Instantiate(carcasa, instanciaImpresora3D.position, Quaternion.identity);
    }
}
