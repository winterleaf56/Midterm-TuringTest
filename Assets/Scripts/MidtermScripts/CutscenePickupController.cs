using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutscenePickupController : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform pickupPoint;
    [SerializeField] private PlayableDirector director;

    public void PickUpPlayer() {
        if (player != null) {
            player.SetParent(pickupPoint);
            player.localPosition = Vector3.zero;
            player.localRotation = Quaternion.Euler(90, 0, 0);
        }
    }

    public void ReleasePlayer() {
        if (player != null) {
            player.SetParent(null);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
