using System.Runtime.InteropServices;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    [Min(1)]
    [SerializeField] private int _adsShowDelay;

    private float _progress = 0;

    [DllImport("__Internal")]
    private static extern void ShowReclama();

    private void Reset()
    {
        _adsShowDelay = 3;
    }

    public void ShowAds()
    {
        _progress++;
        if (_progress >= _adsShowDelay)
        {
            _progress = 0;
            ShowReclamaInUnity();
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
}