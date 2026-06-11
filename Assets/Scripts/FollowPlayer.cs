using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; 
    public enum FollowMode
    {
        Smooth,
        Instant,
        Ahead
    }
    public FollowMode followMode = FollowMode.Smooth; 
    public float followSpeed = 3.5f; 
    
    [Header("Look Ahead Settings")]
    private float aheadDistance = .7f; // Sensitivity multiplier
    public float maxAheadDistanceX = 10f; 
    public float maxAheadDistanceY = 7f; 

    [Header("Turn Smoothness")]
    [Tooltip("How long it takes (in seconds) for the camera to slide to its new look-ahead position. Higher = smoother turning.")]
    public float turnSmoothTime = 0.55f; 

    private Vector3 currentAheadOffset;
    private Vector3 offsetVelocity; // Used internally by SmoothDamp

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = player.position;
            Vector3 newPosition = currentPosition;

            switch (followMode)
            {
                case FollowMode.Smooth:
                    newPosition = Vector3.Lerp(currentPosition, targetPosition, followSpeed * Time.fixedDeltaTime);
                    currentAheadOffset = Vector3.zero; 
                    break;

                case FollowMode.Instant:
                    newPosition = targetPosition;
                    currentAheadOffset = Vector3.zero;
                    break;

                case FollowMode.Ahead:
                    // Fetch raw input to determine direction
                    float inputX = Input.GetAxisRaw("Horizontal");
                    float inputY = Input.GetAxisRaw("Vertical");

                    // Calculate the raw maximum target offsets
                    float targetOffsetX = inputX * maxAheadDistanceX * aheadDistance;
                    float targetOffsetY = inputY * maxAheadDistanceY * aheadDistance;

                    // Keep target values within inspector-defined limits
                    targetOffsetX = Mathf.Clamp(targetOffsetX, -maxAheadDistanceX, maxAheadDistanceX);
                    targetOffsetY = Mathf.Clamp(targetOffsetY, -maxAheadDistanceY, maxAheadDistanceY);

                    Vector3 targetAheadOffset = new Vector3(targetOffsetX, targetOffsetY, 0f);

                    // Smoothly drift the offset vector over time to prevent whiplash
                    currentAheadOffset = Vector3.SmoothDamp(
                        currentAheadOffset, 
                        targetAheadOffset, 
                        ref offsetVelocity, 
                        turnSmoothTime, 
                        Mathf.Infinity, 
                        Time.fixedDeltaTime
                    );

                    // Combine the smoothed offset with the player's position
                    Vector3 desiredAheadPosition = targetPosition + currentAheadOffset;

                    // Lerp to follow the player's physical movements safely
                    newPosition = Vector3.Lerp(currentPosition, desiredAheadPosition, followSpeed * Time.fixedDeltaTime);
                    break;
            }            

            transform.position = new Vector3(newPosition.x, newPosition.y, currentPosition.z);
        }
    }
}