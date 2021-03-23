using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    void Start()
    {
        bar = transform.Find("Bar");
    }

    public void AdjustHealth(float health)
    {
        Transform bar = transform.Find("Bar");
        bar.localScale = new Vector3(health, 1f);
    }

}
