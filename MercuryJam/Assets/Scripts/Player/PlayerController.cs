using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    public Transform playerRotation;
    public LayerMask movementLayerMask;
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 720f;
    
    private CharacterController _controller;
    private Transform _transform;
    private Vector3 _direction;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Player.CurrentPlayer is null || Player.CurrentPlayer.Dead)
            return;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, movementLayerMask))
        {
            _direction = hit.point - _transform.position;
            _direction.y = 0;
            _direction.Normalize();
            playerRotation.rotation = Quaternion.LookRotation(_direction, Vector3.up);
        }

        if (Input.GetButton("Move"))
        {
            playerAnimator.SetBool("IsMoving", true);
            _controller.Move(_direction * (movementSpeed * Time.deltaTime));
            return;
        }
        playerAnimator.SetBool("IsMoving", false);
    }
}