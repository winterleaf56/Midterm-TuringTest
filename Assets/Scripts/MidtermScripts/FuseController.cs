using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class FuseController : MonoBehaviour
{
    public bool hasBlueFuse { get; private set; }
    public bool hasGreenFuse { get; private set; }
    public bool hasRedFuse { get; private set; }

    private int fusesPlaced = 0;

    [SerializeField] private PlaceFuse[] fusePlaces = new PlaceFuse[3];

    [SerializeField] private MeshRenderer lightMaterial;
    [SerializeField] private Material lightOnMaterial;

    public UnityEvent onFusesPlaced;

    /*[Header("Door")]
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private GameObject door;*/


    // Start is called before the first frame update
    void Start()
    {
        foreach (PlaceFuse place in fusePlaces) {
            place.onPlaceFuse.AddListener(PlacedFuse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickedUpFuse(string fuseColour) {
        switch (fuseColour) {
            case "Blue":
                hasBlueFuse = true;
                Debug.Log("picked up blue fuse");
                break;
            case "Red":
                hasRedFuse = true;
                Debug.Log("picked up red fuse");
                break;
            case "Green":
                hasGreenFuse = true;
                Debug.Log("picked up green fuse");
                break;
        }
    }

    public bool HasFuse(string fuseColour) {
        switch (fuseColour) {
            case "Blue":
                return hasBlueFuse;
            case "Red":
                return hasRedFuse;
            case "Green":
                return hasGreenFuse;
            default:
                return false;
        }
    }

    public void PlacedFuse() {
        fusesPlaced++;
        
        if (fusesPlaced == 3) {
            Debug.Log("All fuses placed");
            lightMaterial.material = lightOnMaterial;
            onFusesPlaced?.Invoke();
        }
    }

    private void OnFusesPlaced() {

    }
}
