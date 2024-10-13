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
        
    }

    private void FixedUpdate() {
        lineRenderer.SetPosition(0, laserOrigin.position);

        RaycastHit hit;
        if (Physics.Raycast(laserOrigin.position, laserOrigin.forward, out hit, maxLaserDistance, LaserCollsionMask)) {
            lineRenderer.SetPosition(1, hit.point);
        } else {
            lineRenderer.SetPosition(1, laserOrigin.position + laserOrigin.forward * maxLaserDistance);
        }

        if (Physics.Raycast(laserOrigin.position, laserOrigin.forward, out hit, maxLaserDistance, playerLayer)) {
            Transform hitTransform = hit.transform;
            Health playerHealth = HealthUtility.GetHealthComponent(hitTransform);
            HealthUtility.DamagePlayer(playerHealth, 5);
        }
    }



}
