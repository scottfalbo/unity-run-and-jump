using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baddies : MonoBehaviour
{
    private Vector3 posA;
    public Vector3 posB;
    public Vector3 nextPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform baldy;

    [SerializeField]
    private Transform pivot;



    private void Start()
    {

        posA = baldy.localPosition;
        posB = pivot.localPosition;
        nextPos = posB;
        speed = 4;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        baldy.localPosition = Vector3.MoveTowards(
            baldy.localPosition, nextPos, speed * Time.deltaTime);

        if (Vector3.Distance(baldy.localPosition, nextPos) <= 2)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        nextPos = nextPos != posA ? posA : posB;
    }


}
