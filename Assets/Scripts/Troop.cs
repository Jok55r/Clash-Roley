using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop : MonoBehaviour
{
    public int health;
    public int damage;
    public float speed;

    public GameObject vision;
    public float visionArea;

    public GameObject target;

    public void Start()
    {
        GameObject v = Instantiate(vision, transform.position, Quaternion.identity, transform);
        v.transform.localScale = new Vector3 (visionArea, visionArea, visionArea);
        v.GetComponent<Vision>().troop = this;
    }

    public void Update()
    {
        if (target == null)
            transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
        else
        {
            Vector3 direction = target.transform.position - transform.position;
            direction.Normalize();

            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    public void Attack()
    {

    }
}