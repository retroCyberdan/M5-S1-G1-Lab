using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    [SerializeField] private MeshRenderer _redMesh;
    [SerializeField] private MeshRenderer _yellowMesh;
    [SerializeField] private MeshRenderer _greenMesh;

    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _durationTime;

    private Color _standardColor;

    // Start is called before the first frame update
    void Start()
    {
        _standardColor = _redMesh.material.color; // <- assegno un colore di default che metto da parte

        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            _redMesh.material.color = Color.red;
            //yield return new WaitForSeconds(8f);
            yield return StartCoroutine(TimerText());
            _redMesh.material.color = _standardColor;

            _greenMesh.material.color = Color.green;
            //yield return new WaitForSeconds(4f);
            yield return StartCoroutine(TimerText());
            _greenMesh.material.color = _standardColor;

            _yellowMesh.material.color = Color.yellow;
            //yield return new WaitForSeconds(3f);
            yield return StartCoroutine(TimerText());
            _yellowMesh.material.color = _standardColor;
        }
    }

    private IEnumerator TimerText()
    {
        float timer = _durationTime;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            int min = Mathf.FloorToInt(timer / 60f);
            int sec = Mathf.FloorToInt(timer - min * 60);
            _timerText.text = string.Format($"Il semaforo si aggiorna tra {min}:{sec} secondi", min, sec);
            yield return null;
        }
    }

    private IEnumerator CountdownInternal(float duration) // <- versione di Luca
    {
        float timer = duration;
        while (timer > 0)
        {
            _timerText.SetText($"Il semaforo si aggiorna tra {timer:F1} secondi"); // <- {timer:F1} mi arrotonda alla prima cifra
            yield return null;
            timer -= Time.deltaTime;
        }
    }
}
