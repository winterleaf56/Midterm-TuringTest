using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision col) {
        Debug.Log($"Collided with {col.gameObject.name}");

        // This checks if the object we collided with has the IDestroyable interface
        IDestroyable destroyable = col.gameObject.GetComponent<IDestroyable>();

        // If it does, we call the OnCollided method
        if (destroyable != null) {
            //destroyable.OnCollided();
        }

        Destroy(gameObject);
    }
}
