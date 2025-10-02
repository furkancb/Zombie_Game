using UnityEngine;

public class EM2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float _dh = 1.0f;
    Transform _player;
    CharacterController _controller;

    [SerializeField] float _gravity = 1.0f;
    float _yVelocity = 0.0f;
    void Start()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        _player = playerGameObject.transform;
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = _player.position - transform.position;
        direction.Normalize();
        Vector3 velocity = direction * _dh;

        if (!_controller.isGrounded)
        {
            _yVelocity -= _gravity * Time.deltaTime; ;
        }


        velocity.y = _yVelocity;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
        _controller.Move(velocity * Time.deltaTime);
    }

}
