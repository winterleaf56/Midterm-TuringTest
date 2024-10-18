using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private float minSpeed = 10f;
    [SerializeField] private float maxSpeed = 25f;
    [SerializeField] private float minAngle = -100f;
    [SerializeField] private float maxAngle = 100f; // rotate between 100 and -100

    [SerializeField] private Transform spotLight;

    private float rotationSpeed, rotationAngle, currentAngle;

    private Coroutine searchCoroutine;

    private bool lastStand = false;

    public void StartSearch() {
        if (searchCoroutine == null) {
            searchCoroutine = StartCoroutine(SearchForPlayer());
        }
    }

    public void EndSearch() {
        if (searchCoroutine != null) {
            StopCoroutine(searchCoroutine);
            searchCoroutine = null;
        }

        transform.eulerAngles = Vector3.zero;
    }


    IEnumerator SearchForPlayer() {
        currentAngle = transform.localEulerAngles.y;
        while (true) {
            rotationSpeed = Random.Range(minSpeed, maxSpeed);
            rotationAngle = Random.Range(minAngle, maxAngle);

            float t = 0f;
            float startAngle = currentAngle;

            while (t < 1f) {
                t += Time.deltaTime * rotationSpeed / Mathf.Abs(rotationAngle - startAngle);
                currentAngle = Mathf.Lerp(startAngle, rotationAngle, t);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentAngle, transform.eulerAngles.z);
                yield return null;
            }

            yield return new WaitForSeconds(3f);
        }
    }

    public void LastStand() {
        minSpeed = 50f;
        maxSpeed = 100f;
        minAngle = 180f;
        maxAngle = 250f;

        spotLight.localRotation = Quaternion.Euler(-77f, 0f, 0f);

        lastStand = true;
    }
    
    public void Revert() {
        minSpeed = 10f;
        maxSpeed = 25f;
        minAngle = -100f;
        maxAngle = 100f;

        spotLight.localRotation = Quaternion.Euler(-130f, 0f, 0f);

        lastStand = false;
    }

    public void ToggleMode() {
        if (lastStand) {
            Revert();
        } else {
            LastStand();
        }
    }
}
