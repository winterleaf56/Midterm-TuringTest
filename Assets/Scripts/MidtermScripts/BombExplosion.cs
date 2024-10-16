using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;

    public void Explode() {
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        explosion.transform.parent = transform;
    }

    public void SecondExplosion() {
        Explode();
    }

    public void ThirdExplosion() {
        Explode();
    }
}
