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

    public void Start()
    {
        _collider = GetComponent<Collider>();
        _currentHealth = maxHealth;
        UpdateHealthbar();
    }

    public void OnCollisionEnter(Collision other)
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

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }

    private void Die()
    {
        _dead = true;
        _collider.enabled = false;
        animator.SetBool("IsDead", true);
        damageTextbox.text = "";
        SpawnManager spawn = SpawnManager.Instance;
        spawn.currentEnemies.Remove(gameObject);
        spawn.DecreaseCount();
        StartCoroutine(WaitAndDestroy());
    }

    private void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        UpdateHealthbar();
        if (_currentHealth <= 0)
            Die();
    }

    private void UpdateHealthbar()
    {
        if (damageTextbox != null)
        {
            damageTextbox.text = _currentHealth + "/" + maxHealth;
        }
    }
}
