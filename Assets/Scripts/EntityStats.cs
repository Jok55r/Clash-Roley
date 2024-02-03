using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Cards", order = 1)]
public class EntityStats : ScriptableObject
{
    public Sprite sprite;
    public CardType cardType;
    public Target target;
    public bool splashDamage;
    public bool rangeAttack;

    public int count = 1;
    public int health;
    public int damage;
    public float speed;
    public float damageSpeed;

    public float attackRangeArea;
}