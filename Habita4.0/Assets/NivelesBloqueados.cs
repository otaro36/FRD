using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NivelesBloqueados : MonoBehaviour
{
    public Button[] botones_menu;
    public DesbloqueoNIveles nivelDesbloqueado;
    public int i;
    // Start is called before the first frame update

    void Update()
    {
        while (nivelDesbloqueado.nivelDesbloqueado>=i)
        {
            botones_menu[i].interactable = true;
            i++;
        }
        
    }
}
