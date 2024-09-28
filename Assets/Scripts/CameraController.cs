using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;        // Reference to the player's position
    public float smoothSpeed = 0.125f;  // Speed of the camera movement (smoothness)
    public Vector3 offset;          // Offset between the player and camera

    private Vector3 velocity = Vector3.zero;
    public GameObject Camera;

    void Update()
    {
        // Desired position is the player's position plus the offset
        Vector3 desiredPosition = player.position + offset;

        // Smoothly move the camera towards the desired position using SmoothDamp
        Vector3 smoothedPosition = Vector3.SmoothDamp(Camera.transform.position, desiredPosition, ref velocity, smoothSpeed);

        // Update the camera's position
        Camera.transform.position = smoothedPosition;

        // Optional: If you want the camera to look at the player
        // transform.LookAt(player);
    }
}