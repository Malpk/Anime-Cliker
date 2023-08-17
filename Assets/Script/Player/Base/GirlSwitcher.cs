using System.Collections.Generic;
using UnityEngine;

public class GirlSwitcher : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Girl _girl;
    [SerializeField] private GirlData[] _girs;
    [SerializeField] private InterfaceSwitcher _intefaceHolder;

    private List<GirlData> _girlAcces = new List<GirlData>();

    private void Start()
    {
        Restart();
    }

    public void NextGirl()
    {
        if (_girlAcces.Count > 0)
        {
            var girl = _girlAcces[Random.Range(0, _girlAcces.Count)];
            _girlAcces.Remove(girl);
            _girl.SetGirl(girl);
        }
        else
        {
            _intefaceHolder.ShowMenu(MenuType.EndMenu);
        }
    }

    public void Restart()
    {
        _girlAcces.AddRange(_girs);
        NextGirl();
        _intefaceHolder.ShowMenu(MenuType.HUD);
    }

}
