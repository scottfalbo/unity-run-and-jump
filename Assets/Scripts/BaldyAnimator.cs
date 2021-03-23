using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaldyAnimator : MonoBehaviour
{
    public Animator animator;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask playerMask;

    void Start()
    {
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal")); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("player"))
        {
            Collision2DSideType collisionSide = collision.GetContactSide();

            if (collisionSide != Collision2DSideType.Top)
            {
                Destroy(transform.parent.gameObject);
                //Vector3 bounce = new Vector3(0.5f, 5.0f, 0.0f);
                //Debug.Log(collision.collider.transform.position.ToString());
                //collision.collider.transform.position = collision.collider.transform.position + bounce;
                //Debug.Log(collision.collider.transform.position.ToString());
            }
        }
        
    }
}

/// <summary>
/// code from
/// https://www.malgol.com/how-to-detect-collision-side-in-unity-2d/
/// </summary>
public enum Collision2DSideType
{
    None,
    Left,
    Right,
    Top,
    Bottom,
}
public static class Collision2DExtensions
{
    public static Collision2DSideType GetContactSide(Vector2 max, Vector2 center, Vector2 contact)
    {
        Collision2DSideType side = Collision2DSideType.None;
        float diagonalAngle = Mathf.Atan2(max.y - center.y, max.x - center.x) * 180 / Mathf.PI;
        float contactAngle = Mathf.Atan2(contact.y - center.y, contact.x - center.x) * 180 / Mathf.PI;

        if (contactAngle < 0)
        {
            contactAngle = 360 + contactAngle;
        }

        if (diagonalAngle < 0)
        {
            diagonalAngle = 360 + diagonalAngle;
        }

        if (
            ((contactAngle >= 360 - diagonalAngle) && (contactAngle <= 360)) ||
            ((contactAngle <= diagonalAngle) && (contactAngle >= 0))
        )
        {
            side = Collision2DSideType.Right;
        }
        else if (
            ((contactAngle >= 180 - diagonalAngle) && (contactAngle <= 180)) ||
            ((contactAngle >= 180) && (contactAngle <= 180 + diagonalAngle))
        )
        {
            side = Collision2DSideType.Left;
        }
        else if (
            ((contactAngle >= diagonalAngle) && (contactAngle <= 90)) ||
            ((contactAngle >= 90) && (contactAngle <= 180 - diagonalAngle))
        )
        {
            side = Collision2DSideType.Top;
        }
        else if (
            ((contactAngle >= 180 + diagonalAngle) && (contactAngle <= 270)) ||
            ((contactAngle >= 270) && (contactAngle <= 360 - diagonalAngle))
        )
        {
            side = Collision2DSideType.Bottom;
        }

        return side.Opposite();
    }

    public static Collision2DSideType GetContactSide(this Collision2D collision)
    {
        Vector2 max = collision.collider.bounds.max;
        Vector2 center = collision.collider.bounds.center;
        Vector2 contact = collision.GetContact(0).point;

        return GetContactSide(max, center, contact);
    }
}
public static class Collision2DSideTypeExtensions
{
    public static Collision2DSideType Opposite(this Collision2DSideType sideType)
    {
        Collision2DSideType opposite;

        if (sideType == Collision2DSideType.Left)
        {
            opposite = Collision2DSideType.Right;
        }
        else if (sideType == Collision2DSideType.Right)
        {
            opposite = Collision2DSideType.Left;
        }
        else if (sideType == Collision2DSideType.Top)
        {
            opposite = Collision2DSideType.Bottom;
        }
        else if (sideType == Collision2DSideType.Bottom)
        {
            opposite = Collision2DSideType.Top;
        }
        else
        {
            opposite = Collision2DSideType.None;
        }

        return opposite;
    }
}
