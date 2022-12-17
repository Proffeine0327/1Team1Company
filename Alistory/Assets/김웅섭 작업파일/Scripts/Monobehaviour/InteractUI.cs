using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractUI : MonoBehaviour
{
    private static InteractUI ui;

    [SerializeField] private TextMeshProUGUI actionText;

    RectTransform rectTransform;

    private void Awake() 
    {
        ui = this;
        rectTransform = GetComponent<RectTransform>();
    }

    public static void ControlUI(bool isShowUI) => ui.gameObject.SetActive(isShowUI);

    public static void ControlUI(bool isShowUI,Vector2 pos, string display)
    {
        ui.gameObject.SetActive(isShowUI);
        if(!isShowUI) return;

        ui.rectTransform.anchoredPosition = Camera.main.WorldToScreenPoint(pos);
        ui.actionText.text = display;
    }
}
