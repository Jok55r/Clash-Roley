using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int health;
    public int damage;
    public float speed;

    public GameObject projectile;

    public void Start()
    {
        InvokeRepeating("Shoot", 0, 0.3f);
    }

    public void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    public void Shoot()
    {
        Projectile p = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Projectile>();
        p.dir = new Vector2(1, 0);
        p.damage = damage;
    }
}