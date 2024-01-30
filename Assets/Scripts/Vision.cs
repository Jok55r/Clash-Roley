using UnityEngine;

public class Vision : MonoBehaviour
{
    public Entity entity;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (entity.target != null)
            return;
        Entity other = collision.gameObject.GetComponent<Entity>();
        if (other.teamColor != entity.teamColor)
        {
            entity.target = collision.gameObject;
        }
    }
}