using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscenaManager : MonoBehaviour
{
    public DesbloqueoNIveles nivelDesbloqueado;
    public void CambiarNivel(int nivel)
    {
        if (nivel == 0)
        {
            SceneManager.LoadScene("Inicio");
        }
        else if (nivel == 1)
        {
            StartCoroutine("PausaEscena");
        }
        else
        {
            SceneManager.LoadScene("Game_" + nivel);
        }
    }
    public void Desbloquear_Nivel(int nivel_desbloqueado)
    {
        nivelDesbloqueado.nivelDesbloqueado = nivel_desbloqueado;
    }
    IEnumerator PausaEscena()
    {
        yield return new WaitForSecondsRealtime(10f);
        SceneManager.LoadScene("menu niveles");
    }
}
