using UnityEngine;
using TMPro;

public class GirlCollectionMenu : UIMenu
{
    [SerializeField] private Transform _panelHolder;
    [SerializeField] private ContentPanel[] _panels;
    [SerializeField] private TextMeshProUGUI _countOpenText;

    private void OnValidate()
    {
        if (_panelHolder)
        {
            _panels = _panelHolder.GetComponentsInChildren<ContentPanel>();
            UpdateConter();
        }
    }

    public string Save()
    {
        var data = new CollectionData();
        foreach (var panel in _panels)
        {
            if (panel.IsOpen)
                data.OpenGirl.Add(panel.PanelId);
        }
        return JsonUtility.ToJson(data);
    }

    public void Load(string json)
    {
        if (json != "")
        {
            var data = JsonUtility.FromJson<CollectionData>(json);
            for (int i = data.OpenGirl.Count; i > 0; i--)
            {
                var panel = GetPanel(data.OpenGirl[i - 1]);
                panel.Open();
                panel.transform.SetAsFirstSibling();
            }
        }
        UpdateConter();
    }

    public void Open(GirlData girl)
    {
        var panel = GetPanel(girl.Id);
        panel.transform.SetAsFirstSibling();
        panel.Open();
        UpdateConter();
    }

    private ContentPanel GetPanel(int id)
    {
        foreach (var panel in _panels)
        {
            if (panel.PanelId == id)
                return panel;
        }
        return null;
    }

    private void UpdateConter()
    {
        _countOpenText?.SetText($"{GetCountOpenGirl()}/{_panels.Length}");
    }

    private int GetCountOpenGirl()
    {
        int count = 0;
        foreach (var panel in _panels)
        {
            if (panel.IsOpen)
                count++;
        }
        return count;
    }
}
