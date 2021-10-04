using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] canvasTutorial;
    public GameObject panel;
    public int i;
    public int j;
    // Start is called before the first frame update
    void Start()
    {
        j = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (j==4)
        {
            panel.SetActive(false);
            
        }
        canvasTutorial[i].SetActive(false);
        canvasTutorial[j].SetActive(true);
    }
    public void Desactivar()
    {
        i++;
    }
    public void Activar()
    {
        j++;
    }
}
