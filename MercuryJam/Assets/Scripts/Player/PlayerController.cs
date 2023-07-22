using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator Animator;
    public float MovementSpeed = 5.0f;
    public float RotationSpeed = 720f;
    public float AbilityCooldown = 2.0f;

    private CharacterController _controller;
    private Transform _transform;
    private bool _isOnCooldown;
    private float _cooldownElapsed;

    public void Start()
    {
        _controller = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
    }

    public void Update()
    {
        UpdateAbility();
        UpdateMovement();
    }

    private void UpdateAbility()
    {
        if (_isOnCooldown)
        {
            Animator.SetBool("IsHitting", false);
            _cooldownElapsed += Time.deltaTime;
            if (_cooldownElapsed > AbilityCooldown)
            {
                _isOnCooldown = false;
            }
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Animator.SetBool("IsHitting", true);
            _isOnCooldown = true;
            _cooldownElapsed = 0f;
        }
    }

    private void UpdateMovement()
    {
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction.Normalize();
        _controller.Move(direction * (MovementSpeed * Time.deltaTime));
        Animator.SetBool("IsMoving", direction != Vector3.zero);
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            _transform.rotation =
                Quaternion.RotateTowards(_transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        }
    }
}