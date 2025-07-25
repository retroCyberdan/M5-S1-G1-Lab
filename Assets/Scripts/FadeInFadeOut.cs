using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    [SerializeField] private Image _imageToFade;
    [SerializeField] private float _fadeTime = 1f;
    private Coroutine _currentFadeCoroutine;
    private bool _isFaded;

    /*[SerializeField]*/
    CanvasGroup _canvasGroup; // <- per versione Luca, questo invece di Image

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentFadeCoroutine != null) StopCoroutine(_currentFadeCoroutine); // <- se sta gi� eseguendo una coroutine, la interrompe

            if (_isFaded) _currentFadeCoroutine = StartCoroutine(FadeOut());
            else _currentFadeCoroutine = StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeIn()
    {
        _isFaded = true;
        float time = 0f;
        Color color = _imageToFade.color;
        while (time < _fadeTime)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, time / _fadeTime); // <- utilizzo il metodo Lerp() per effettuare la transizione
            _imageToFade.color = color;
            yield return null;
        }
        //color.a = 1f;
        //_imageToFade.color = color;
        _currentFadeCoroutine = null;
    }

    IEnumerator FadeOut()
    {
        _isFaded = false;
        float time = 0f;
        Color color = _imageToFade.color;
        while (time < _fadeTime)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, time / _fadeTime); // <- utilizzo il metodo Lerp() per effettuare la transizione
            _imageToFade.color = color;
            yield return null;
        }
        //color.a = 0f;
        //_imageToFade.color = color;
        _currentFadeCoroutine = null;
    }

    //IEnumerator FadeInLuca(float fadeDuration) // <- versione di Luca
    //{
    //    float startAlpha = _canvasGroup.alpha;
    //    float time = 0f;
    //    _isFaded = true;
    //    while (time < _fadeTime)
    //    {
    //        time += Time.deltaTime;
    //        _canvasGroup.alpha = Mathf.Lerp(startAlpha, 1f, time / fadeDuration); // <- utilizzo il metodo Lerp() per effettuare la transizione
    //        yield return null;
    //    }
    //    _canvasGroup.alpha = 1f;
    //}

    //IEnumerator FadeOutLuca(float fadeDuration) // <- versione di Luca
    //{
    //    float startAlpha = _canvasGroup.alpha;
    //    float time = 0f;
    //    _isFaded = true;
    //    while (time < _fadeTime)
    //    {
    //        time += Time.deltaTime;
    //        _canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, time / fadeDuration); // <- utilizzo il metodo Lerp() per effettuare la transizione
    //        yield return null;
    //    }
    //    _canvasGroup.alpha = 0f;
    //}
}
