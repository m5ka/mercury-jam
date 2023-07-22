using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public Animator animator;
    public Enemy enemy;
    public float requiredProximity = 3.0f;
    public float damageDelay = 0.8f;
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
        if (enemy.Dead)
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
        if (CanHitPlayer())
        {
            animator.SetBool("IsHitting", true);
            _isCooldown = true;
            _cooldownElapsed = 0.0f;
            StartCoroutine(TryDamage());
        }
    }

    private bool CanHitPlayer()
    {
        if (enemy.Dead)
            return false;
        return Vector3.Distance(_transform.position, Player.CurrentPlayer.Position) <= requiredProximity;
    }

    private IEnumerator TryDamage()
    {
        yield return new WaitForSeconds(damageDelay);
        if (CanHitPlayer())
            Player.CurrentPlayer.TakeDamage(damage);
    }
}
