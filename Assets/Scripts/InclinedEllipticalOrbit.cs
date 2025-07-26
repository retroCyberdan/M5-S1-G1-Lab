using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclinedEllipticalOrbit : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _radius = 3f;
    //float radiusX; // serializable
    //float radiusZ; // serializable
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

    //private void Orbit() // <- versione di Luca, da richiamare in Update rimuovendo il mio
    //{
    //    _angle += _speed * Time.deltaTime;
    //    Vector3 localOrbit = new Vector3(Mathf.Cos(_angle) * radiusX, 0, Mathf.Sin(_angle)) * radiusZ;

    //    Quaternion rotation = Quaternion.Euler(_inclination);

    //    Vector3 rotatedOrbit = _center.position + rotation * localOrbit
    //    transform.position = rotatedOrbit;
    //}

    //void OnDrawGizmos() // <- versione di Luca
    //{
    //    if (_center == null) return;

    //    int segments = 100; // <- numero basso = da ellisse diventa squadrato

    //    Vector3[] points = new Vector3[segments + 1];

    //    Quaternion rotation = Quaternion.Euler(_inclination);

    //    for (int i = 0; i <= segments; i++)
    //    {
    //        float t = (float)i / segments;
    //        float angle = t * Mathf.PI * 2f;

    //        Vector3 localPoint = new Vector3( Mathf.Cos(angle) * radiusX, 0f, Mathf.Sin(angle) * radiusZ);

    //        points[i] = _center.position + rotation * localPoint;
    //    }

    //    Gizmos.color = Color.cyan;
    //    for (int i = 0; i < segments;i++)
    //    {
    //        Gizmos.DrawLine(points[i], points[i + 1]);
    //    }
    //}
}