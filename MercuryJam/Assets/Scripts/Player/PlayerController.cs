using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    public Transform playerRotation;
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 720f;

    private CharacterController _controller;
    private Transform _transform;

    public void Start()
    {
        _controller = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
    }

    public void Update()
    {
        if (Player.CurrentPlayer is null || Player.CurrentPlayer.Dead)
            return;
        
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction.Normalize();
        _controller.Move(direction * (movementSpeed * Time.deltaTime));
        playerAnimator.SetBool("IsMoving", direction != Vector3.zero);
        if (direction != Vector3.zero)
        {
            var rotation = Quaternion.LookRotation(direction, Vector3.up);
            playerRotation.rotation =
                Quaternion.RotateTowards(playerRotation.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }
}