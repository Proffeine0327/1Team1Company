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
        isLighting = !isLighting;
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
        sr.sprite = onOffSprite[isLighting ? 0 : 1];
    }
}
