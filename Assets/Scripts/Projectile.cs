using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Projectile : MonoBehaviour
{
    public Color teamColor;
    public int damage;
    public float speed;
    public Vector2 dir;
    public float lifetime;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = teamColor;
    }

    void Update()
    {
        transform.position += (Vector3)dir * Time.deltaTime * speed;
        lifetime -= Time.deltaTime;

        if (lifetime < 0)
            Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            Entity other = collision.gameObject.GetComponent<Entity>();
            if (other.teamColor != teamColor)
            {
                collision.gameObject.GetComponent<Entity>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        finally{}
    }
}