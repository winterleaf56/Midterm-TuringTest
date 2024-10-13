using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private float minSpeed = 10f;
    [SerializeField] private float maxSpeed = 25f;
    [SerializeField] private float minAngle = -100f;
    [SerializeField] private float maxAngle = 100f; // rotate between 100 and -100

    private float rotationSpeed, rotationAngle, currentAngle;

    public void StartSearch() {
        StartCoroutine(SearchForPlayer());
    }

    public void EndSearch() {
        StopCoroutine(SearchForPlayer());
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

    void LastStand() {
        minSpeed = 50f;
        maxSpeed = 100f;
        minAngle = 135f;
        maxAngle = 235f;
    }
}
