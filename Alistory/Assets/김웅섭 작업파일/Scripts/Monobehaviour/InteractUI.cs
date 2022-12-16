using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractUI : MonoBehaviour
{
    private static InteractUI ui;

    private void Awake() 
    {
        ui = this;    
    }

    public static void ControlUI(Vector2 pos, string display)
    {
        
    }
}
