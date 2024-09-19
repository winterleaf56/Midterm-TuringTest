using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour {

    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private LayerMask LaserCollsionMask;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform laserOrigin;
    private float maxLaserDistance = 25f;

    [SerializeField] private Transform player;

    Health playerHealth;

    void Update() {
        lineRenderer.SetPosition(0, laserOrigin.position);

        RaycastHit hit;
        if (Physics.Raycast(laserOrigin.position, laserOrigin.forward, out hit, maxLaserDistance, LaserCollsionMask)) {
            lineRenderer.SetPosition(1, hit.point);
        } else {
            lineRenderer.SetPosition(1, laserOrigin.position + laserOrigin.forward * maxLaserDistance);
        }

        if (Physics.Raycast(laserOrigin.position, laserOrigin.forward, out hit, maxLaserDistance, playerLayer)) {
            Transform hitTransform = hit.transform;
            Health playerHealth = GetHealthComponent(hitTransform);
            DamagePlayer(playerHealth);
        }
    }

    Health GetHealthComponent(Transform hitTransform) {
        while (hitTransform != null) {
            Health health = hitTransform.GetComponent<Health>();
            if (health != null) {
                return health;
            }

            hitTransform = hitTransform.parent;
        }
        return null;
    }

    void DamagePlayer(Health playerHealth) {
        //player.playerHealth.DeductHealth(5);
        playerHealth.DeductHealth(5);
        Debug.Log("Damaging for 5 health");
    }
}
