using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuManegerButtons : MonoBehaviour
{
    public List<GameObject> buttons;


    [Header("Animations")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;


    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        HiderAllButtons();
        ShowButtons();
       
    }

    private void HiderAllButtons()
    {
        foreach(var b in buttons)
        {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }
    }



    public  void ShowButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            var b = buttons[i]; // OU "GameObject b = buttons[i];"
            b.SetActive(true);
            b.transform.DOScale(.2f, duration).SetDelay(i*delay).SetEase(ease);

        }
    }

}
