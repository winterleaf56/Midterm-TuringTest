using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// No longer PushButton, now Interact

public class PushButton : MonoBehaviour, ISelectable
{
    //[SerializeField] private Material defaultColour, hoverColour;
    //[SerializeField] private MeshRenderer buttonRenderer;

    public UnityEvent onPush;

    public UnityEvent onHoverEnter, onHoverExit;

    public void OnSelect() {
        onPush?.Invoke();
    }

    public void OnHoverEnter() {
        //buttonRenderer.material = hoverColour;

        onHoverEnter?.Invoke();
    }

    public void OnHoverExit() {
        //buttonRenderer.material = defaultColour;

        onHoverExit?.Invoke();
    }
}
