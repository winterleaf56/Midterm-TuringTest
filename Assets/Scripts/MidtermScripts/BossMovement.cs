using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private float minSpeed = 10f;
    [SerializeField] private float maxSpeed = 25f;
    [SerializeField] private float minAngle = -110f;
    [SerializeField] private float maxAngle = 110f; // rotate between 110 and -110

    private float rotationSpeed, rotationAngle, currentAngle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SearchForPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SearchForPlayer() {
        while (true) {
            rotationSpeed = Random.Range(minSpeed, maxSpeed);
            rotationAngle = Random.Range(minAngle, maxAngle);

            //transform.Rotate(Vector3.up, rotationAngle);

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
}
