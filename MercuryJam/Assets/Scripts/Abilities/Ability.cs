using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public float cooldown = 2.0f;
    public float speed = 7.0f;
    public float maxDistance = 24.0f;
    public int damage = 1;

    private Transform _transform;
    private Vector3 _startPoint;
    private Vector3 _direction;

    public AudioSource AbilitySound;

    public void Initiate(Vector3 startPoint, Vector3 direction)
    {
        _startPoint = startPoint;
        _transform.position = _startPoint;
        _direction = direction;
        SoundManager.Instance.PlayAbilitySound(AbilitySound);
    }

    public void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    public void Update()
    {
        _transform.Translate(_direction * (speed * Time.deltaTime));
        if (Vector3.Distance(_transform.position, _startPoint) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
