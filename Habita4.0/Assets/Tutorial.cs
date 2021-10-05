using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] canvasTutorial;
    public GameObject panel;
    public int i;
    public int j;
    public bool pausa;
    // Start is called before the first frame update
    void Start()
    {
        j = 1;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (i==8)
        {
            panel.SetActive(false);
            
        }
        if (i==3)
        {
            Time.timeScale = 1;
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
