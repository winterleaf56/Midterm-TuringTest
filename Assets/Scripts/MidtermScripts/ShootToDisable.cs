using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToDisable : DamageableObject
{
    private EnemyHealth health;

    protected override void Awake() {
        base.Awake();
    }
}
