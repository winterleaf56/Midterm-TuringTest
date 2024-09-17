using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteractor : Interactor
{
    [Header("Pickup and Drop")]
    [SerializeField] private Camera cam;
    [SerializeField] private Transform attachPoint;
    [SerializeField] private float pickupDistance;
    [SerializeField] private LayerMask pickupLayer;

    private bool isPicked = false;
    private IPickable pickable;
    private RaycastHit hit;

    public override void Interact() {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out hit, pickupDistance, pickupLayer)) {
            if (input.interact && !isPicked) {
                pickable = hit.collider.GetComponent<IPickable>();

                if (pickable == null) {
                    return;
                }

                pickable.OnPicked(attachPoint);
                isPicked = true;
                return;
            }
        }

        if (input.interact && isPicked && pickable != null) {
            pickable.OnDropped();
            isPicked = false;
        }
    }
}
