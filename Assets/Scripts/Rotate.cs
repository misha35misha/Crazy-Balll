using System;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.Rotate(0f, 0f, 45f * Time.deltaTime);
    }
}
