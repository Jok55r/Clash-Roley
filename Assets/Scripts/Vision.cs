using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public Troop troop;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        troop.target = collision.gameObject;
    }
}