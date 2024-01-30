using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Cards", order = 1)]
public class EntityStats : ScriptableObject
{
    public CardType cardType;
    public Sprite sprite;

    public int count = 1;
    public int health;
    public int damage;
    public float speed;
    public float damageSpeed;

    public float attackRangeArea;
}