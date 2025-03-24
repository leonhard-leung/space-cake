using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform player;  // reference to the player's Transform
    [SerializeField] private float smoothTime;  // response time of the camera

    private Vector3 _offset;    // offset to keep the camera at a fixed distance
    private Vector3 _velocity;  // used by SmoothDamp to track movement speed
    
    private void Start()
    {
        _offset = new Vector3(0f, 0f, -10f);    // set a fixed offset
        _velocity = Vector3.zero;               // initialize velocity to zero
    }

    private void Update()
    {
        // calculate the target position with the offset
        Vector3 targetPos = player.position + _offset;
        
        // smoothly move the camera towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, smoothTime);
    }
}
