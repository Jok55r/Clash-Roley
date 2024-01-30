using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Entity
{
    public override void Attack()
    {
        base.Attack();
        RangeAttack();
    }
}