using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Entity entity;

    public float maxHealth;
    public float currentHealth;

    private float initialWidth;

    void Start()
    {
        maxHealth = entity.stats.health;
        currentHealth = entity.stats.health;
        GetComponent<SpriteRenderer>().color = entity.teamColor;
        initialWidth = transform.localScale.x;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        float healthPercentage = currentHealth / maxHealth;
        float newWidth = initialWidth * healthPercentage;
        transform.localScale = new Vector2(newWidth, transform.localScale.y);
    }
}