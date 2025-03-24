using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;   // speed of the parallax scrolling

    private float _height;          // height of the sprite
    private float _updatedYPos;     // stores the updated Y position
    private Vector2 _startingPos;   // initial position of the background sprite

    private void Start()
    {
        _startingPos = transform.position;
        
        // get the height of the sprite to determine when to reset its position
        _height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void Update()
    {
        // move the background downwards at a constant speed
        _updatedYPos = transform.position.y - parallaxSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x, _updatedYPos);
        
        // reset the position when it moves completely out of view
        if (transform.position.y <= _startingPos.y - _height)
        {
            transform.position = _startingPos;
        }
    }
}
