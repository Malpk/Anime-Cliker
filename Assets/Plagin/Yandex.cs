using System.Runtime.InteropServices;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowReclama();
    public void ShowReclamaInUnity()
    {
#if UNITY_EDITOR
        Debug.Log("unity");
#else
#if UNITY_WEBGL
        Debug.Log("webgl");
        ShowReclama();
#endif
#endif
    }
}