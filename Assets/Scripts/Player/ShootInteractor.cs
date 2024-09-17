using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInteractor : Interactor
{
    [SerializeField] private Input inputType;

    [Header("Shooting")]
    //[SerializeField] private Rigidbody bulletPrefab;
    [SerializeField]  private ObjectPool bulletPool;
    [SerializeField] private float shootVelocity;
    [SerializeField] private Transform shootPoint;

    [SerializeField] private PlayerMoveBehaviour moveBehaviour;

    private float finalShootVelocity;

    public enum Input {
        Primary,
        Secondary
    }

    public override void Interact() {
        if (inputType == Input.Primary && input.primaryClick || inputType == Input.Secondary && input.secondaryClick) {
            Shoot();
        }
    }

    void Shoot() {
        finalShootVelocity = moveBehaviour.GetForwardSpeed() + shootVelocity;

        PooledObject pooledObj = bulletPool.GetPooledObject();
        pooledObj.gameObject.SetActive(true);

        //Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bullet = pooledObj.GetComponent<Rigidbody>();
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;
        bullet.velocity = shootPoint.forward * finalShootVelocity;

        //Destroy(bullet.gameObject, 5.0f);
        bulletPool.DestroyPooledObject(pooledObj, 5.0f);
    }
}
