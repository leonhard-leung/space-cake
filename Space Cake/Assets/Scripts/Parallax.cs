using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;

    private float _height, _depth, _updatedYPos;
    private Vector3 _startingPos;

    void Start()
    {
        _startingPos = transform.position;

        _height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        _updatedYPos = transform.position.y - parallaxSpeed * Time.deltaTime;
        
        transform.position = new Vector3(transform.position.x, _updatedYPos, transform.position.z);

        if (transform.position.y <= _startingPos.y - _height)
        {
            transform.position = _startingPos;
        }
    }
}
