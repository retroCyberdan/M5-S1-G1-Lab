using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipticalOrbit : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _radiusX = 5f;
    [SerializeField] private float _radiusZ = 3f;

    private float _angle;

    void Update()
    {
        _angle += _speed * Time.deltaTime;
        float x = Mathf.Cos(_angle) * _radiusX;
        float z = Mathf.Sin(_angle) * _radiusZ;
        transform.position = _center.position + new Vector3(x, 0, z);
    }
}