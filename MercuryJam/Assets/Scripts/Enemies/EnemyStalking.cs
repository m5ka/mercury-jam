using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStalking : MonoBehaviour
{
    public Animator animator;
    public float speed = 2.0f;
    public float targetDistance = 3.0f;
    
    private Transform _transform;

    public void Start()
    {
        _transform = GetComponent<Transform>();
    }
    
    public void Update()
    {
        if (Player.CurrentPlayer is null)
            return;
        var playerPosition = Player.CurrentPlayer.Position;
        _transform.rotation = Quaternion.LookRotation(playerPosition - _transform.position, Vector3.up);
        if (Vector3.Distance(playerPosition, _transform.position) > targetDistance)
        {
            animator.SetBool("IsMoving", true);
            _transform.position =
                Vector3.MoveTowards(_transform.position, playerPosition, speed * Time.deltaTime);;
            return;
        }
        animator.SetBool("IsMoving", false);
    }
}
