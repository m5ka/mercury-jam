using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player CurrentPlayer;
    
    public Vector3 Position => _transform.position;

    public TextMeshPro damageTextbox;
    public int maxHealth = 10;

    private Transform _transform;
    private CharacterController _characterController;
    private int _currentHealth;

    public void Awake()
    {
        _transform = GetComponent<Transform>();
        _characterController = GetComponent<CharacterController>();
        if (!CurrentPlayer)
            CurrentPlayer = this;
    }
    
    public void Start()
    {
        _currentHealth = maxHealth;
        UpdateHealthbar();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        UpdateHealthbar();
    }

    public void Teleport(Vector3 position)
    {
        _characterController.enabled = false;
        _transform.position = position;
        _characterController.enabled = true;
    }

    private void UpdateHealthbar()
    {
        if (damageTextbox is null)
            return;
        damageTextbox.text = _currentHealth + "/" + maxHealth;
    }
}
