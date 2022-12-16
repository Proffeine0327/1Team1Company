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
        yield return new WaitForSeconds(0.5f);
        Player.currentPlayer.canMove = !Player.currentPlayer.isHiding;
        Player.currentPlayer.canInteract = true;
        transform.localScale = scale;
    }

    public void ShowUI()
    {
        
    }
}
