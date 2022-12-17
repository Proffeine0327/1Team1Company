using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExplainUI : MonoBehaviour
{
    private static ExplainUI ui;

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float currentShowTime;

    public static void ShowExplain(string text, float t)
    {
        ui.currentShowTime = t;
        ui.text.text = text;
    }
    
    private void Awake() 
    {    
        ui = this;
    }

    private void Update()
    {
        if(currentShowTime > 0)
        {
            text.gameObject.SetActive(true);
            currentShowTime -= Time.deltaTime;
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }
}
