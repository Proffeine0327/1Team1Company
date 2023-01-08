using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour, IInteractable
{
    [SerializeField] private List<GameObject> containItems = new List<GameObject>();

    public void Interact()
    {
        if(containItems.Count <= 0)
        {
            ExplainUI.AddExplain("비어있다.", 1.5f, 1);
            return;
        }

        var itemNames =
            from item in containItems
            select item.name;
        
        ExplainUI.AddExplain($"{string.Join(',', itemNames)} 을(를) 얻었다.", 1.5f, 1);
        foreach(var item in containItems)
        {
            item.transform.SetParent(Player.currentPlayer.transform.Find("Items").transform);
            Player.currentPlayer.GetItem(item);
        }
        containItems.Clear();
    }

    public void ShowUI()
    {
        InteractUI.ControlUI(true, transform.position, "조사하기");
    }
}
