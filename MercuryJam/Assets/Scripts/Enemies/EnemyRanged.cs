using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[HideMonoScript]
public class EnemyRanged : MonoBehaviour
{
    [BoxGroup("Enemy"), LabelText("Object")] public Enemy enemy;
    [BoxGroup("Enemy"), LabelText("Animator")] public Animator animator;
    [BoxGroup("Projectile"), LabelText("Prefab")] public EnemyProjectile enemyProjectilePrefab;
    [BoxGroup("Projectile"), LabelText("Spawn Location")] public Transform enemyProjectileSpawnLocation;
    [BoxGroup("Projectile"), LabelText("Maximum Distance")] public float projectileMaxDistance = 24.0f;
    [BoxGroup("Projectile"), LabelText("Speed")] public float projectileSpeed = 5.0f;
    [BoxGroup("Projectile"), LabelText("Damage")] public int projectileDamage = 2;
    [BoxGroup("Ability"), LabelText("Delay")] public float spawnProjectileDelay = 0.8f;
    [BoxGroup("Ability"), LabelText("Cooldown")] public float cooldown = 2.0f;

    private Transform _transform;
    private bool _isCooldown;
    private float _cooldownElapsed;

    public void FixedUpdate()
    {
        if (Player.CurrentPlayer is null || Player.CurrentPlayer.Dead || enemy.Dead)
            return;

        if (_isCooldown)
        {
            _cooldownElapsed += Time.fixedDeltaTime;
            if (_cooldownElapsed >= cooldown)
            {
                animator.SetBool("IsHitting", false);
                _isCooldown = false;
            }

            return;
        }
        
        animator.SetBool("IsHitting", true);
        _isCooldown = true;
        _cooldownElapsed = 0.0f;
        StartCoroutine(ShootProjectile());
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private IEnumerator ShootProjectile()
    {
        yield return new WaitForSeconds(spawnProjectileDelay);
        Instantiate(enemyProjectilePrefab)
            .Initialize(
                enemyProjectileSpawnLocation.position, _transform.forward, projectileMaxDistance,
                projectileDamage, projectileSpeed);
    }
}
