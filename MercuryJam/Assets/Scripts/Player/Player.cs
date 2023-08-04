using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player CurrentPlayer;
    
    public Vector3 Position => _transform.position;
    public int CurrentHealth => _currentHealth;
    public bool Dead => _dead;

    public Animator animator;
    public TextMeshPro damageTextbox;
    public int maxHealth = 10;
    public int damage = 1;
    public float movementSpeed = 5.0f;

    public int defaultMaxHealth;
    public int defaultDamage;
    public float defaultMovementSpeed;

    private Transform _transform;
    private CharacterController _characterController;
    private int _currentHealth;
    private bool _dead = false;

    public void Awake()
    {
        _transform = GetComponent<Transform>();
        _characterController = GetComponent<CharacterController>();
        if (!CurrentPlayer)
            CurrentPlayer = this;
    }
    
    public void Start()
    {
        defaultDamage = damage;
        defaultMaxHealth = maxHealth;
        defaultMovementSpeed = movementSpeed;

        Spawn();
    }

    public void Update()
    {
        if (!_dead && _currentHealth <= 0)
            Die();
    }

    public void Spawn()
    {
        animator.SetBool("IsDead", false);
        _characterController.enabled = true;
        _currentHealth = maxHealth;
        UpdateHealthbar();
        _dead = false;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        UpdateHealthbar();
        SoundManager.Instance.PlayPlayerDamage();
    }

    public void HealPlayer(int heal)
    {
        _currentHealth += heal;
        if (_currentHealth > maxHealth )
        {
            _currentHealth = maxHealth;
        }
        UpdateHealthbar();
    }

    public void Teleport(Vector3 position)
    {
        _characterController.enabled = false;
        _transform.position = position;
        _characterController.enabled = true;
    }

    private void Die()
    {
        SoundManager.Instance.PlayPlayerDeathSound();

        _dead = true;
        _characterController.enabled = false;
        if (damageTextbox is not null)
            damageTextbox.text = "";
        animator.SetBool("IsDead", true);

        SpawnManager.Instance.ClearEnemies();
        HUDManager.Instance.resetPanel.SetActive(true);
    }

    public void UpdateHealthbar()
    {
        if (damageTextbox is null)
            return;
        damageTextbox.text = _currentHealth + "/" + maxHealth;
    }
}
