using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public AudioSource abilitySound;
    public float cooldown = 2.0f;
    public float speed = 7.0f;
    public float maxDistance = 24.0f;
    public int damage = 1;

    private Transform _transform;
    private Vector3 _startPoint;
    private Vector3 _direction;

    public void Initiate(Vector3 startPoint, Vector3 direction)
    {
        _startPoint = startPoint;
        _transform.position = _startPoint;
        _transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        _direction = direction;
        SoundManager.Instance.PlayAbilitySound(abilitySound);
    }

    public void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    public void Update()
    {
        _transform.position += _direction * (speed * Time.deltaTime);
        if (Vector3.Distance(_transform.position, _startPoint) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
