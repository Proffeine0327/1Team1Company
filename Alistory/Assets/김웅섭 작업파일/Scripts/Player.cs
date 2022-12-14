using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player currentPlayer;

    [Header("Move")]
    [SerializeField] private float moveSpeed;
    [Header("Interaction")]
    [SerializeField] private float interactionRange;

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
        if(Input.GetButton("Horizontal"))
        {
            ani.SetBool("isMoving", true);
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, 0);
            
            if(Input.GetAxisRaw("Horizontal") != 0)
                sr.flipX = Input.GetAxisRaw("Horizontal") < 0;
        }
        else
        {
            ani.SetBool("isMoving", false);
        }
    }
}
