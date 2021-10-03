using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscenaManager : MonoBehaviour
{
    static public int nivel_esdesbloqueados = 1;
    public int nivel_actual;
    public Button[] botones_menu;
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "menu niveles")
        {
            actualizar_botones();
        }
    }
    public void CambiarNivel(int nivel)
    {
        if (nivel == 0)
        {
            SceneManager.LoadScene("Inicio");
        }
        else if (nivel == 1)
        {
            SceneManager.LoadScene("menu niveles");
        }
        else
        {
            SceneManager.LoadScene("Game_" + nivel);
        }
    }
    public void Desbloquear_Nivel()
    {
        if (nivel_esdesbloqueados < nivel_actual)
        {
            nivel_esdesbloqueados = nivel_actual;
            nivel_actual++;
        }
        Menu_niveles();
    }
    public void Menu_niveles()
    {
        CambiarNivel(0);
    }
    public void actualizar_botones()
    {
        for (int i = 0; i < nivel_esdesbloqueados; i++)
        {
            botones_menu[i].interactable = true;
        }
    }
}
