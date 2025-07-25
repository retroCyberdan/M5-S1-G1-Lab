using System.Collections;
using UnityEngine;

public class InclinedCoroutineOrbit : MonoBehaviour
{
    //
    // questa versione dell`InclinedOrbit è ottimizzata per funzionare con le coroutine
    //
    [SerializeField] private Transform _center;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _radiusX = 5f;
    [SerializeField] private float _radiusZ = 3f;
    [SerializeField] private Vector3 _inclination = Vector3.up;

    private Coroutine _orbitCoroutine;
    private float _angle;

    void Start()
    {
        _orbitCoroutine = StartCoroutine(OrbitAround());
    }

    IEnumerator OrbitAround()
    {
        while (true)
        {
            _angle += _speed * Time.deltaTime;
            Vector3 localPos = new Vector3(Mathf.Cos(_angle) * _radiusX, 0, Mathf.Sin(_angle) * _radiusZ);
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, _inclination.normalized);
            transform.position = _center.position + rot * localPos;

            yield return null; // aspetta il prossimo frame
        }
    }

    public void StopOrbit()
    {
        if (_orbitCoroutine != null)
        {
            StopCoroutine(_orbitCoroutine);
        }
    }

    public void ResumeOrbit()
    {
        if (_orbitCoroutine == null)
        {
            _orbitCoroutine = StartCoroutine(OrbitAround());
        }
    }

    void OnDrawGizmos()
    {
        if (!_center) return;

        Gizmos.color = Random.ColorHSV();
        Vector3 start = Vector3.zero;

        for (float i = 0; i <= 2 * Mathf.PI; i += 0.1f)
        {
            Vector3 localPosition = new Vector3(Mathf.Cos(i) * _radiusX, 0, Mathf.Sin(i) * _radiusZ);
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, _inclination.normalized);
            Vector3 point = _center.position + rotation * localPosition;

            if (i > 0) Gizmos.DrawLine(start, point);

            start = point;
        }
    }
}
