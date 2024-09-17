using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotateCamera());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RotateCamera() {
        while (true) {
            yield return RotateToAngle(90f);
            yield return RotateToAngle(-90f);
        }
    
    }

    IEnumerator RotateToAngle(float targetAngle) {
        float startAngle = transform.eulerAngles.y;
        float endAngle = startAngle + targetAngle;
        float t = 0f;

        while (t < 1f) {
            t += Time.deltaTime * rotationSpeed / Mathf.Abs(targetAngle);
            float angle = Mathf.Lerp(startAngle, endAngle, t);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
            yield return null;
        }
    }
}
