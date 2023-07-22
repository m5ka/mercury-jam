using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public TextMeshPro damageTextbox;
    public int maxHealth;

    private int _currentHealth;

    public void Start()
    {
        _currentHealth = maxHealth;
        UpdateHealthbar();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ability"))
        {
            var ability = other.gameObject.GetComponent<Ability>();
            TakeDamage(ability.damage);
            Destroy(other.gameObject);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
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
        damageTextbox.text = _currentHealth + "/" + maxHealth;
    }
}
