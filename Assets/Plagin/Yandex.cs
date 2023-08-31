using System.Runtime.InteropServices;
using System.Collections;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    [Min(1)]
    [SerializeField] private int _adsSteep;
    [Min(1)]
    [SerializeField] private int _adsDelayShow;
    [Header("Reference")]
    [SerializeField] private TextUI _text;

    private float _progress = 0;

    private Coroutine _ads;

    [DllImport("__Internal")]
    private static extern void ShowReclama();

    private void Reset()
    {
        _adsSteep = 3;
        _adsDelayShow = 3;
    }

    public void ShowAds()
    {
        if (_ads == null)
        {
            _progress++;
            if (_progress >= _adsSteep)
            {
                _progress = 0;
                _ads = StartCoroutine(ShowWaitAds(_adsDelayShow));
            }
        }
    }

    public void ShowReclamaInUnity()
    {
#if UNITY_EDITOR
        Debug.Log("showAds_editor");
#elif UNITY_WEBGL
        Debug.Log("webgl");
        ShowReclama();
#endif
    }

    private IEnumerator ShowWaitAds(int delay)
    {
        var progress = 0f;
        _text.gameObject.SetActive(true);
        while (progress < 1f)
        {
            progress += Time.deltaTime / delay;
            var value = delay * (1 - progress);
            _text.SetText((int)value);
            yield return null;
        }
        _text.gameObject.SetActive(false);
        ShowReclamaInUnity();
        _ads = null;
    }

}