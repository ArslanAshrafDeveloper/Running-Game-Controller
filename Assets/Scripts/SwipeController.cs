using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public float speed = 10f; // Speed at which the player moves

    public GameObject Player;

    private Vector2 lastTouchPosition; // Last position of the touch on the screen
    private bool isTouching = false;   // Flag to check if the touch is active

    [SerializeField]private float leftsideLimit = -2.5f;
    [SerializeField]private float rightsideLimit = 2.5f;

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle the different touch phases
            if (touch.phase == TouchPhase.Began)
            {
                // Start tracking the touch
                lastTouchPosition = touch.position;
                isTouching = true;
            }
            else if (touch.phase == TouchPhase.Moved && isTouching)
            {
                // Calculate the difference between the last touch position and the current touch position
                Vector2 deltaSwipe = touch.position - lastTouchPosition;

                // Update the player's position based on the swipe's horizontal delta
                var position = Player.transform.position;
                float newXPosition = position.x + deltaSwipe.x * speed * Time.deltaTime;

                //clamp the newXPosition to 2.5f and -2.5f
                newXPosition = Mathf.Clamp(newXPosition, leftsideLimit, rightsideLimit);

                float angle = Mathf.Atan2(deltaSwipe.x , deltaSwipe.y) * Mathf.Rad2Deg;

                angle = Mathf.Clamp(angle, -45, 45);

                // Move the player to the new position
                position = new Vector3(newXPosition, position.y, position.z);
                Player.transform.position = position;
                //Player.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
                Player.transform.rotation = Quaternion.SlerpUnclamped(Player.transform.rotation, Quaternion.Euler(new Vector3(0, angle, 0)), 0.1f);

                // Update the last touch position
                lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                // End the touch
                isTouching = false;

                Player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }

            else if (touch.phase == TouchPhase.Stationary)
            {
                Player.transform.rotation = Quaternion.SlerpUnclamped(Player.transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0)), 0.1f);
            }
        }
    }
}