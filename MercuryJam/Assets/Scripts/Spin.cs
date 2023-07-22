using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    protected GameObject self;

    private void Awake()
    {
        self = GetComponent<GameObject>();
    }

    private void Update()
    {
        transform.Rotate(0,24 * Time.deltaTime,0);
    }
}
