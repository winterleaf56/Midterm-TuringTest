using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInteractor : Interactor
{
    [Header("Interact")]
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private float interactDistance;

    private RaycastHit hit;
    private ISelectable selectable;

    public override void Interact() {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer)) {
            selectable = hit.collider.GetComponent<ISelectable>();

            if (selectable != null) {
                selectable.OnHoverEnter();

                if (input.interact) {
                    selectable.OnSelect();
                }
            }
        }

        if (hit.transform == null && selectable != null) {
            selectable.OnHoverExit();
            selectable = null;
        }
    }
}
