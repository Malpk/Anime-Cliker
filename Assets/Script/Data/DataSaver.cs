using UnityEngine;
using System.Collections;

public class DataSaver : MonoBehaviour
{
    [Min(1)]
    [SerializeField] private float _saveDelay;
    [SerializeField] private string _key;
    [Header("Reference")]
    [SerializeField] private GirlSwitcher _girlSwitcher;
    [SerializeField] private GirlCollectionMenu _collectionGirl;

    private void Reset()
    {
        _saveDelay = 3;
    }

    private void Start()
    {
        Load();
        StartCoroutine(SaveUpdate());
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        var data = new PlayerData();
        data.ProgressData = _girlSwitcher.Save();
        data.OpenGirlMenu = _collectionGirl.Save();
        PlayerPrefs.SetString(_key ,JsonUtility.ToJson(data));
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey(_key))
        {
            var data = JsonUtility.FromJson<PlayerData>(
                PlayerPrefs.GetString(_key));
            _girlSwitcher.Load(data.ProgressData);
            _collectionGirl.Load(data.OpenGirlMenu);
        }
    }

    private IEnumerator SaveUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(_saveDelay);
            Save();
            yield return null;
        }
    }

}
