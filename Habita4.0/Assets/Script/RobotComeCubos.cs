using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotComeCubos : MonoBehaviour
{
    public GameObject encendido;
    private void OnTriggerEnter(Collider other)
    {
        encendido.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        encendido.SetActive(false);
    }
}
