using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStalking : MonoBehaviour
{
    public Animator animator;
    public Enemy enemy;
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
        if (enemy.Dead)
            return;
        var playerPosition = new Vector3(Player.CurrentPlayer.Position.x, 0, Player.CurrentPlayer.Position.z);
        _transform.rotation = Quaternion.LookRotation(playerPosition - _transform.position, Vector3.up);
        if (Vector3.Distance(playerPosition, _transform.position) > targetDistance)
        {
            animator.SetBool("IsMoving", true);
            var position = Vector3.MoveTowards(_transform.position, playerPosition, speed * Time.deltaTime);
            _transform.position = new Vector3(position.x, 0, position.z);
            return;
        }
        animator.SetBool("IsMoving", false);
    }
}
