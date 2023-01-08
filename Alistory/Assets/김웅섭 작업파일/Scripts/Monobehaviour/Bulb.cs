using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite[] onOffSprite;
    [SerializeField] private bool isLighting;

    private SpriteRenderer sr;

    public void Interact()
    {
        if(Boss.BossDisplayed) ExplainUI.AddExplain("켜지지 않는다.", 1.5f, 1);
        else isLighting = !isLighting;
    }

    public void ShowUI()
    {
        InteractUI.ControlUI(true, (Vector2)transform.position + Vector2.one, isLighting ? "켜기" : "끄기");
    }

    private void Awake() 
    {
        sr = GetComponent<SpriteRenderer>();    
    }

    private void Update() 
    {
        if(Boss.BossDisplayed) isLighting = false;
        sr.sprite = onOffSprite[isLighting ? 0 : 1];
    }
}
