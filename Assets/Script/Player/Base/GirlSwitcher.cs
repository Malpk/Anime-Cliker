using System.Collections.Generic;
using UnityEngine;

public class GirlSwitcher : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Girl _girl;
    [SerializeField] private GirlData[] _girs;
    [SerializeField] private InterfaceSwitcher _intefaceHolder;

    private List<GirlData> _girlAcces = new List<GirlData>();

    private void Awake()
    {
        Restart();
    }

    public void Load(string json)
    {
        if (json != "")
        {
            var data = JsonUtility.FromJson<ProgressData>(json);
            _girlAcces.Clear();
            foreach (var girl in _girs)
            {
                if (data.LockGirl.Contains(girl.Id))
                {
                    _girlAcces.Add(girl);
                }
                else if (girl.Id == data.GirlActive)
                {
                    _girl.SetGirl(girl);
                    _girl.Load(data.GirlProgress);
                }
            }
        }
    }

    public string Save()
    {
        var data = new ProgressData();
        data.GirlActive = _girl.Data.Id;
        data.GirlProgress = _girl.Save();
        foreach (var girl in _girlAcces)
        {
            data.LockGirl.Add(girl.Id);
        }
        return JsonUtility.ToJson(data);
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
            Restart();
        }
    }

    public void Restart()
    {
        _girlAcces.AddRange(_girs);
        NextGirl();
    }

}
