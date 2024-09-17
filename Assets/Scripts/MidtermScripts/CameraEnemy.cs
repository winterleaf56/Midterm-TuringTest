using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class CameraEnemy : DamageableObject
{
    private EnemyHealth health;

    [SerializeField] private GameObject body;
    [SerializeField] private new Light light;

    public UnityEvent onPlayerInLight;

    protected override void Awake() {
        base.Awake();
    }

    protected override void Start() {
        onPlayerInLight.AddListener(OnPlayerInLight);
    }

    public void OnPlayerInLight() {
        light.color = Color.red;
    }
}
