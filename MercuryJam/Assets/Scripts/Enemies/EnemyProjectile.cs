using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[HideMonoScript]
[InfoBox("This game object will move through the game, causing damage to players it hits.")]
public class EnemyProjectile : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _origin;
    private Vector3 _direction;
    private float _maxDistance;
    private int _damage;
    private float _speed;
    private AudioSource _spawnSound;

    public void Initialize(Vector3 origin, Vector3 direction, float maxDistance, int damage, float speed)
    {
        _origin = origin;
        _direction = direction;
        _maxDistance = maxDistance;
        _damage = damage;
        _speed = speed;
        
        _transform.position = _origin;
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        _spawnSound = GetComponent<AudioSource>();
        _spawnSound.volume = SoundManager.Instance.soundVolume;
    }

    private void Update()
    {
        _transform.Translate(_direction * (_speed * Time.deltaTime));
        if (Vector3.Distance(_origin, _transform.position) >= _maxDistance)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.CurrentPlayer.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
