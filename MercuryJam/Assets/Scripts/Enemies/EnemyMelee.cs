using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public Animator animator;
    public float requiredProximity = 3.0f;
    public float cooldown = 2.0f;
    public int damage = 1;
    
    private Transform _transform;
    private bool _isCooldown;
    private float _cooldownElapsed;

    public void Start()
    {
        _transform = GetComponent<Transform>();
    }
    
    public void Update()
    {
        if (Player.CurrentPlayer is null)
            return;
        if (_isCooldown)
        {
            _cooldownElapsed += Time.deltaTime;
            if (_cooldownElapsed >= cooldown)
            {
                animator.SetBool("IsHitting", false);
                _isCooldown = false;
            }
            return;
        }
        if (Vector3.Distance(_transform.position, Player.CurrentPlayer.Position) <= requiredProximity)
        {
            animator.SetBool("IsHitting", true);
            _isCooldown = true;
            _cooldownElapsed = 0.0f;
            Player.CurrentPlayer.TakeDamage(damage);
        }
    }
}
