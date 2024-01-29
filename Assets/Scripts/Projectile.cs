using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float speed;
    public Vector2 dir;
    public float lifetime;

    void Update()
    {
        transform.position += (Vector3)dir * Time.deltaTime * speed;
        lifetime -= Time.deltaTime;

        if (lifetime < 0)
            Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Troop>().health -= damage;
    }
}