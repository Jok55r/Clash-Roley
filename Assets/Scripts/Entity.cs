using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;


public class Entity : MonoBehaviour
{
    public EntityStats stats;

    public Color teamColor;
    public HealthBar healthBar;

    public GameObject vision;
    public float visionArea;
    public GameObject attackRange;

    public GameObject projectile;

    public GameObject target;
    public bool inRange;
    public float tempAttackTime;

    public int health;

    void Start()
    {
        health = stats.health;
        GetComponent<SpriteRenderer>().sprite = stats.sprite;
        SpawnTriggers();
    }


    void Update()
    {
        Move();
        TryAttack();

        if (health <= 0)
            Destroy(gameObject);
    }

    public void Move()
    {
        Vector3 direction = Vector3.zero;

        if (target == null)
        {
            direction = new Vector3(teamColor == Color.blue ? -1 : 1, 0);
        }
        else if (!inRange)
        {
            direction = target.transform.position - transform.position;
        }

        direction.Normalize();
        transform.Translate(direction * stats.speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.TakeDamage(damage);
    }

    public void TryAttack()
    {
        if (tempAttackTime > 0)
            tempAttackTime -= Time.deltaTime;
        else if (inRange)
            Attack();
    }
    public virtual void Attack()
    {
        tempAttackTime = stats.damageSpeed;
        
        if (stats.rangeAttack) RangeAttack();
        else CloseAttack();
    }
    public void RangeAttack()
    {
        Projectile p = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Projectile>();
        p.dir = GetDirection(target.transform.position);
        p.speed = 8;
        p.damage = stats.damage;
        p.teamColor = teamColor;
    }
    public void CloseAttack()
    {
        target.GetComponent<Entity>().TakeDamage(stats.damage);
    }

    public void GetInVision(GameObject obj)
    {
        if (stats.target == Target.building && obj.GetComponent<Entity>().stats.cardType != CardType.building)
            return;
        target = obj;
    }

    public Vector3 GetDirection(Vector3 other)
    {
        Vector3 direction = other - transform.position;
        direction.Normalize();
        return direction;
    }

    public void SpawnTriggers()
    {
        GameObject vis = Instantiate(vision, transform.position, Quaternion.identity, transform);
        vis.transform.localScale = new Vector3(visionArea, visionArea, visionArea);
        vis.GetComponent<Vision>().entity = this;

        GameObject atk = Instantiate(attackRange, transform.position, Quaternion.identity, transform);
        atk.transform.localScale = new Vector3(stats.attackRangeArea, stats.attackRangeArea, stats.attackRangeArea);
        atk.GetComponent<AttackRange>().entity = this;
    }
}

public enum CardType
{
    spell,
    building,
    troop,
    airTroop,
}

public enum Target
{
    ground,
    air,
    building,
}