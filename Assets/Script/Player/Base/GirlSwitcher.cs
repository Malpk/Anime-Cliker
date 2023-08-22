using System.Collections.Generic;
using UnityEngine;

public class GirlSwitcher : MonoBehaviour
{
    [SerializeField] private string[] _girls;
    [Header("Reference")]
    [SerializeField] private Girl _girl;
    [SerializeField] private InterfaceSwitcher _intefaceHolder;

    private List<string> _girlAcces = new List<string>();

    private void OnValidate()
    {
        var contents = Resources.LoadAll<GirlData>("");
        _girls = new string[contents.Length];
        for (int i = 0; i < _girls.Length; i++)
        {
            _girls[i] = contents[i].name;
        }
    }

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
            _girlAcces.AddRange(data.LockGirl);
            LoadGirl(data.GirlActive);
            _girl.Load(data.GirlProgress);
        }
    }

    public string Save()
    {
        var data = new ProgressData();
        data.GirlActive = _girl.Data.name;
        data.GirlProgress = _girl.Save();
        data.LockGirl.AddRange(_girlAcces);
        return JsonUtility.ToJson(data);
    }

    public void NextGirl()
    {
        if (_girlAcces.Count > 0)
        {
            var girl = _girlAcces[Random.Range(0, _girlAcces.Count)];
            _girlAcces.Remove(girl);
            LoadGirl(girl);
        }
        else
        {
            Restart();
        }
    }

    public void Restart()
    {
        _girlAcces.Clear();
        _girlAcces.AddRange(_girls);
        NextGirl();
    }

    private void LoadGirl(string name)
    {
        var girl = Resources.Load<GirlData>("Chan/"+ name);
        _girl.SetGirl(girl);
    }

}
