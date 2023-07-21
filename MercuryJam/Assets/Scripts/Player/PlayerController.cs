using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _movementSpeed = 5.0f;
    private float _rotationSpeed = 720f;
    private CharacterController _controller;
    private Transform _transform;
    private Animator _animator;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction.Normalize();
        _controller.Move(direction * (_movementSpeed * Time.deltaTime));
        _animator.SetBool("IsWalking", direction != Vector3.zero);
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            _transform.rotation =
                Quaternion.RotateTowards(_transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        }
    }
}