using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LineOfSight : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private LayerMask obstacleLayer;

    [SerializeField] private float detectionRadius = 25f;
    [SerializeField] private float fieldOfView = 45f;

    [SerializeField] private PlayableDirector director;

    public bool isDetected = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDetected == false) {
            Debug.Log("Detecting player");
            DetectPlayer();
        }
        
    }

    void DetectPlayer() {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer < detectionRadius ) {
            //Vector3 adjustedForward = Quaternion.Euler(verticalAngle, 0, 0) * transform.forward;
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
            if  (angleToPlayer < fieldOfView / 2) {
                if (!Physics.Linecast(transform.position, player.position, obstacleLayer)) {
                    Debug.Log("Player detected!");
                    //director.Play();
                    //PlayerCaughtCutscene.InvokePlayerCaught();
                    PlayerCaughtCutscene.Instance.TriggerCutsceneAction();
                    isDetected = true;
                } else {
                    Debug.Log("Player is hiding");
                }
            }
        }
    }

    void OnDrawGizmos() {
        if (player != null) {

            // Line of Sight To Player
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, player.position);

            // Detection Radius
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);

            // Vision Cone
            Vector3 leftBoundary = Quaternion.Euler(0, -fieldOfView / 2, 0) * transform.forward * detectionRadius;
            Vector3 rightBoundary = Quaternion.Euler(0, fieldOfView / 2, 0) * transform.forward * detectionRadius;
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
            Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
        }
    }

    public void SetDetectable() {
        isDetected = false;
    }
}
