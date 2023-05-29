using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public string playerTag = "Player"; // Tag of the player GameObject
    public float edgeThreshold = 3f; // Threshold distance from the screen edge to trigger camera movement
    public float smoothTime = 1f;//smoothens the camera movement
    public Vector3 offset = new Vector3(0, 3, -10);//offset will be used to define a position above and behind the target when camera moves

    private Transform target; // Reference to the player's transform
    private Vector3 initialOffset; // Initial offset between the camera and player
    public Camera mainCamera;//looks for the main camera
    private Vector3 velocity = Vector3.zero;//velocity of the camera movement

    private void Start()
    {
        //main camera
        mainCamera = Camera.main;
        // Find the player GameObject based on its tag
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        // Set the target reference to the player's transform
        if (playerObject != null)
        {
            target = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player GameObject not found with tag: " + playerTag);
        }

        Debug.Log("camera size: " + mainCamera.orthographicSize * mainCamera.aspect);
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            if (Vector2.Distance(target.position, transform.position) > edgeThreshold)
            {
                //cam moves above and behind the target by offset
                Vector3 targetPosition = target.TransformPoint(offset);
                transform.position = Vector3.SmoothDamp(
                    transform.position,
                    targetPosition,
                    ref velocity,
                    smoothTime
                    );
            }
        }
    }
}