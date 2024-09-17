using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlaceFuse : MonoBehaviour, ISelectable
{

    [SerializeField] private GameObject fuse;
    [SerializeField] private string fuseColourString;
    [SerializeField] private GameObject fuseSlot;

    [SerializeField] private FuseController fuseController;

    private bool fusePlaced = false;

    public UnityEvent onPlaceFuse;

    public UnityEvent hoverEnter, hoverExit;

    public UnityAction placingFuse;


    public void OnSelect() {
        Debug.Log("Fuse Interact");
        if (fuseController.HasFuse(fuseColourString)) {
            onPlaceFuse?.Invoke();
        }
    }

    public void OnHoverEnter() {
        hoverEnter?.Invoke();
    }

    public void OnHoverExit() {
        hoverExit?.Invoke();
    }
}
