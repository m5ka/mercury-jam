using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool Dead => _dead;

    public Animator animator;
    public TextMeshPro damageTextbox;
    public int maxHealth;
    public int difficulty = 1;

    private Collider _collider;
    private bool _dead;
    private int _currentHealth;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _currentHealth = maxHealth;
        UpdateHealthbar();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (_dead)
            return;
        if (other.gameObject.CompareTag("Ability"))
        {
            var ability = other.gameObject.GetComponent<Ability>();
            TakeDamage(ability.damage);
            Destroy(other.gameObject);
        }
    }

    private void Die()
    {
        _dead = true;
        _collider.enabled = false;
        animator.SetBool("IsDead", true);
        damageTextbox.text = "";
        SpawnManager.Instance.RemoveEnemy(gameObject);
        Destroy(gameObject, 3.0f);
        PowerUpManager.Instance.AttemptSpawnPowerUp(gameObject.transform.position);
        if (gameObject.tag == "Skeleton")
        {
            SoundManager.Instance.PlaySkeletonDeath();
        }
        if (gameObject.tag == "Bat")
        {
            SoundManager.Instance.PlayBatDeath();
        }
    }

    private void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        UpdateHealthbar();
        if (_currentHealth <= 0)
            Die();
        else
        {
            if (gameObject.tag == "Skeleton")
            {
                SoundManager.Instance.PlaySkeletonDamage();
            }
            if (gameObject.tag == "Bat")
            {
                SoundManager.Instance.PlayBatDamage();
            }
        }
    }

    private void UpdateHealthbar()
    {
        if (damageTextbox != null)
        {
            damageTextbox.text = _currentHealth + "/" + maxHealth;
        }
    }
}
