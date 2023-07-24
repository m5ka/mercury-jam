using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStalking : MonoBehaviour
{
    public Animator enemyAnimator;
    public Transform enemyRotation;
    public Enemy enemy;
    public float minSpeed = 1.0f;
    public float maxSpeed = 2.5f;
    public float targetDistance = 3.0f;
    
    private Rigidbody _rb;
    private Transform _transform;
    private float _speed;

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _speed = Random.Range(minSpeed, maxSpeed);
    }
    
    public void FixedUpdate()
    {
        if (Player.CurrentPlayer is null || Player.CurrentPlayer.Dead || enemy.Dead)
            return;
        
        var playerPosition = new Vector3(Player.CurrentPlayer.Position.x, 0, Player.CurrentPlayer.Position.z);
        var position = new Vector3(_transform.position.x, 0, _transform.position.z);

        enemyRotation.rotation = Quaternion.LookRotation(playerPosition - position, Vector3.up);
        if (Vector3.Distance(position, Player.CurrentPlayer.Position) > targetDistance)
        {
            enemyAnimator.SetBool("IsMoving", true);
            _rb.MovePosition(Vector3.MoveTowards(position, playerPosition, _speed * Time.fixedDeltaTime));
            return;
        }
        
        enemyAnimator.SetBool("IsMoving", false);
    }
}
