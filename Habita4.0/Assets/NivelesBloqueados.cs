using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NivelesBloqueados : MonoBehaviour
{
    public Button[] botones_menu;
    public DesbloqueoNIveles nivelDesbloqueado;
    // Start is called before the first frame update

    void Update()
    {
        botones_menu[nivelDesbloqueado.nivelDesbloqueado].interactable = true;
    }
}
