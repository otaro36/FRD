using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Timer : MonoBehaviour
{
    [Header("Timer UI reference:")]
    [SerializeField] private Image fillImage;
    [SerializeField] private Text textReloj;

    public int duracion;
    private int remainingDuracion;
    // Start is called before the first frame update
    private void Awake()
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        textReloj.text = "00:00";
        fillImage.fillAmount = 0f;

        duracion = remainingDuracion = 0;
    }
    public Timer SetDuration(int segundos)
    {
        duracion = remainingDuracion = segundos;
        return this;
    }
    public void Comienzo()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuracion > 0)
        {
            UpdateUI(remainingDuracion);
            remainingDuracion--;
            yield return new WaitForSeconds(1f);
        }
        End();
    }

    private void UpdateUI(int segundos)
    {
        textReloj.text = string.Format("{0:D2}:{1:D2}", segundos / 60, segundos % 60);
        fillImage.fillAmount = Mathf.InverseLerp(0, duracion, segundos);
    }
    public void End()
    {
        ResetTimer();
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
