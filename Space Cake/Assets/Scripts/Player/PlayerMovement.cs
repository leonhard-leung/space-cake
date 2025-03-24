using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Rigidbody")]
        [SerializeField] private Rigidbody2D rb;
        [Header("Movement")] 
        [SerializeField] private float thrustForce;     // forward movement force
        [SerializeField] private float lateralForce;    // sideways movement force
        [SerializeField] private float maxSpeed;        // max speed limit
        [SerializeField] private float dampingFactor;   // custom damping effect
        
        // Input System
        private PlayerInputActions _playerControls;
        private InputAction _move;
        private Vector2 _movement;  // stores the input movement

        private void Awake()
        {
            _playerControls = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _move = _playerControls.Player.Move;
            _move.Enable();
        }

        private void OnDisable()
        {
            _move.Disable();
        }

        private void Update()
        {
            _movement = _move.ReadValue<Vector2>(); // get input movement direction
        }

        private void FixedUpdate()
        {
            // apply movement force based on input
            rb.AddForce(new Vector2(_movement.x * lateralForce, _movement.y * thrustForce), ForceMode2D.Force);
            
            // limit the velocity to prevent infinite speed
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
            
            // apply damping to slow down over time
            rb.linearVelocity *= 1 - dampingFactor * Time.fixedDeltaTime;
        }
    }
}
