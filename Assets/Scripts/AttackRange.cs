using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public Entity entity;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Entity other = collision.gameObject.GetComponent<Entity>();
        if (other.teamColor != entity.teamColor)
        {
            entity.inRange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        Entity other = collision.gameObject.GetComponent<Entity>();
        if (other.teamColor != entity.teamColor)
        {
            entity.inRange = false;
        }
    }
}