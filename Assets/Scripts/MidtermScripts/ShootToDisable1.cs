using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToDisable1 : DamageableObject
{
    EnemyHealth health;

    // Start is called before the first frame update
    void Start()
    {
        health = new EnemyHealth(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void TakeDamage(float damage) {
        base.TakeDamage(damage);
    }
}
