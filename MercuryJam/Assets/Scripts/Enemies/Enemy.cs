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
    
    private bool _dead;
    private int _currentHealth;

    public void Start()
    {
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
        animator.SetBool("IsDead", true);
        damageTextbox.text = "";
        SpawningSystem.Instance.DecreaseCount();
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
