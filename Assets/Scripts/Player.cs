using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private LeftRightMovement movement;
    private Rigidbody2D rigidBody2d;
    private BoxCollider2D boxCollider2D;

    [SerializeField] private LayerMask platformsLayerMask;

    private void Awake()
    {
        movement = gameObject.GetComponent<LeftRightMovement>();
        rigidBody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = Input.GetKey(KeyCode.LeftShift) &&
                ((Input.GetKey(KeyCode.LeftArrow) ||
                (Input.GetKey(KeyCode.RightArrow)))) ? 18f : 16f;
            rigidBody2d.velocity = Vector2.up * jumpVelocity;
        }
        
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center,
            boxCollider2D.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2D.collider != null;
    }
}
