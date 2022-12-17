using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Player.currentPlayer.canInteract = false;
        Player.currentPlayer.canMove = false;

        StartCoroutine(HidingAnimation());
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
        InteractUI.ControlUI(true, transform.position + Vector3.right * 1.5f, Player.currentPlayer.isHiding ? "나가기" : "숨기");
    }
}
