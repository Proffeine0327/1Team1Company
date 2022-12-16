using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player currentPlayer;

    [Header("Move")]
    [SerializeField] private float moveSpeed;
    [SerializeField] public bool canMove;
    [Header("Interaction")]
    [SerializeField] private float interactionRange;
    [SerializeField] public bool canInteract;
    [Header("Hiding")]
    [SerializeField] public bool isHiding;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator ani;

    void Awake()
    {
        currentPlayer = this;

        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();

        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        if (canMove)
        {
            if (Input.GetButton("Horizontal"))
            {
                ani.SetBool("isMoving", true);
                rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, 0);

                if (Input.GetAxisRaw("Horizontal") != 0)
                    sr.flipX = Input.GetAxisRaw("Horizontal") < 0;
            }
            else
            {
                ani.SetBool("isMoving", false);
            }
        }

        if(canInteract)
        {
            var interactObjects = Physics2D.CircleCastAll(transform.position, interactionRange, Vector2.zero, 0, LayerMask.GetMask("Interactable"));
            
            if(interactObjects.Length > 0)
            {
                var sortInteractableObjs = 
                    from obj in interactObjects
                    orderby Vector2.Distance((Vector2)transform.position, (Vector2)obj.transform.position)
                    select obj;
                
                interactObjects = sortInteractableObjs.ToArray();
                interactObjects[0].collider.GetComponent<IInteractable>().ShowUI();
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    interactObjects[0].collider.GetComponent<IInteractable>().Interact();
                }
            }
            else
            {

            }
        }
        else
        {

        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRange);    
    }
}
