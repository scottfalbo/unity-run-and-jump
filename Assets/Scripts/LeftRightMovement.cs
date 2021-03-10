using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMovement : MonoBehaviour
{
    public Animator animator;

    public float speed = 2f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        speed = (Input.GetKey(KeyCode.LeftShift)) ? 5f : 2f;

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + ((horizontal * Time.deltaTime) * speed);
    }
}
