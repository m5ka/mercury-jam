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

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Player.CurrentPlayer is null || Player.CurrentPlayer.Dead)
            return;
        
        if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, movementLayerMask))
            return;

        var direction = hit.point - _transform.position;
        direction.y = 0;
        direction.Normalize();

        playerRotation.rotation = Quaternion.LookRotation(direction, Vector3.up);

        if (Input.GetButton("Move"))
        {
            playerAnimator.SetBool("IsMoving", true);
            _controller.Move(direction * (movementSpeed * Time.deltaTime));
            return;
        }
        playerAnimator.SetBool("IsMoving", false);
    }
}