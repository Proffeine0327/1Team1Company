using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool isBossWasShowed = false;

    private void Update() 
    {
        if(Boss.BossDisplayed) isBossWasShowed = true;    
    }

    public void Interact()
    {
        if (!isBossWasShowed) ExplainUI.AddExplain("열리지 않는다.", 1.5f, 1);
        else
        {
            Player.currentPlayer.canInteract = false;
            Player.currentPlayer.canMove = false;

            StartCoroutine(HidingAnimation());
        }
    }

    IEnumerator HidingAnimation()
    {
        var scale = transform.localScale;
        transform.localScale = new Vector3(0.1f, scale.y, scale.z);
        yield return new WaitForSeconds(0.5f);
        Player.currentPlayer.isHiding = !Player.currentPlayer.isHiding;
        Player.currentPlayer.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = !Player.currentPlayer.isHiding;

        var pos = Player.currentPlayer.transform.position;
        pos.x = transform.position.x + 1.5f;
        Player.currentPlayer.transform.position = pos;

        yield return new WaitForSeconds(0.5f);
        Player.currentPlayer.canMove = !Player.currentPlayer.isHiding;
        Player.currentPlayer.canInteract = true;
        transform.localScale = scale;
    }

    public void ShowUI()
    {
        if(isBossWasShowed) 
            InteractUI.ControlUI(true, transform.position + Vector3.right * 1.5f, Player.currentPlayer.isHiding ? "나가기" : "숨기");
        else 
            InteractUI.ControlUI(true, transform.position + Vector3.right * 1.5f, "열기");
    }
}
