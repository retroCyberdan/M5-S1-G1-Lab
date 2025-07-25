using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclinedEllipticalOrbit : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _radius = 3f;
    [SerializeField] private Vector3 _inclination = new Vector3(1, 1, 0); // <- vettore inclinazione editabile da Inspector

    private float _angle;

    void Update()
    {
        _angle += _speed * Time.deltaTime;
        Vector3 orbit = new Vector3(Mathf.Cos(_angle), 0, Mathf.Sin(_angle)) * _radius;
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, _inclination.normalized);
        transform.position = _center.position + rotation * orbit;
    }

    void OnDrawGizmos()
    {
        if (!_center) return;

        Gizmos.color = Random.ColorHSV();
        Vector3 start = Vector3.zero;

        for (float i = 0; i <= 2 * Mathf.PI; i += 0.1f)
        {
            Vector3 orbit = new Vector3(Mathf.Cos(i), 0, Mathf.Sin(i)) * _radius;
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, _inclination.normalized);
            Vector3 point = _center.position + rotation * orbit;

            if (i > 0) Gizmos.DrawLine(start, point);

            start = point;
        }
    }
}