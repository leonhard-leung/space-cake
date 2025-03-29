using UnityEngine;

namespace Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Transform player; // reference to the player's Transform
        [SerializeField] private float smoothTime; // response time of the camera

        private static readonly Vector3 Offset = new(0f, 0f, -10f); // offset to keep the camera at a fixed distance
        private Vector3 _velocity = Vector3.zero;                   // used by SmoothDamp to track movement speed

        private float _camHalfWidth, _camHalfHeight; // half dimensions of the camera's viewport
        private const float BgWidth = 9.6f;          // width of the background
        private const float BgHeight = 3.6f;         // height of the background
        private float _minX, _maxX;                  // clamping boundaries for the camera's X-axis
        private float _minY, _maxY;                  // clamping boundaries for the camera's Y-axis
    
        private void Start()
        {
            if (Camera.main != null)
            {
                // calculate the half height and width of the camera using orthographic camera size and aspect ratio
                _camHalfHeight = Camera.main.orthographicSize;
                _camHalfWidth = _camHalfHeight * Camera.main.aspect; 
            }

            // maximum and minimum positions of the boundary
            _minX = (-BgWidth / 2) + _camHalfWidth;
            _maxX = (BgWidth / 2) - _camHalfWidth;
            _minY = (-BgHeight / 2) + _camHalfHeight;
            _maxY = (BgHeight / 2) - _camHalfHeight;
        }

        private void Update()
        {
            // calculate the target position with the offset
            var targetPos = player.position + Offset;
        
            // clamp the target position within the background boundaries
            targetPos.x = Mathf.Clamp(targetPos.x, _minX, _maxX);
            targetPos.y = Mathf.Clamp(targetPos.y, _minY, _maxY);
        
            // smoothly move the camera towards the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, smoothTime);
        }
    }
}
