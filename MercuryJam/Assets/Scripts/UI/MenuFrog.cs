using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFrog : MonoBehaviour
{
    public Animator frogAnimator;
    public float rotationSpeed = 20f;
    public float dragRotationSpeed = 50f;
    public int waveChance = 1000;

    private Transform _transform;
    private bool _isWaving;
    private bool _isFast;
    private float _fastDegreesElapsed;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        var rotation = rotationSpeed * Time.deltaTime;
        if (_isFast)
        {
            rotation *= 10f;
            _fastDegreesElapsed += rotation;
            if (_fastDegreesElapsed > 360f)
                _isFast = false;
        }
        _transform.Rotate(Vector3.up * rotation);
    }

    private void FixedUpdate()
    {
        if (_isWaving)
        {
            _isWaving = false;
            frogAnimator.SetBool("IsWaving", false);
        } else if (Random.Range(0, 1000) <= 1)
        {
            _isWaving = true;
            frogAnimator.SetBool("IsWaving", true);
        }
    }

    private void OnMouseDown()
    {
        if (_isFast)
            return;
        _isFast = true;
        _fastDegreesElapsed = 0.0f;
    }
}
