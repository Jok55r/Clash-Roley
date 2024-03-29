using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public Entity entity;

    public void OnTriggerEnter2D(Collider2D collision)
        => InRange(collision);
    public void OnTriggerStay2D(Collider2D collision)
        => InRange(collision);

    public void OnTriggerExit2D(Collider2D collision)
    {
        Entity other = collision.gameObject.GetComponent<Entity>();
        if (other.teamColor != entity.teamColor)
        {
            entity.inRange = false;
        }
    }

    private void InRange(Collider2D collision)
    {
        Entity other = collision.gameObject.GetComponent<Entity>();
        if (other.teamColor != entity.teamColor)
        {
            entity.inRange = true;
        }
    }
}