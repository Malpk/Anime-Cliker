using UnityEngine;

public class DataSaver : MonoBehaviour
{
    [SerializeField] private string _key;
    [Header("Reference")]
    [SerializeField] private GirlSwitcher _girlSwitcher;
    [SerializeField] private GirlCollectionMenu _collectionGirl;

    private void Start()
    {
        Load();
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
        Debug.Log(JsonUtility.ToJson(data));
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
}
