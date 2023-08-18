using UnityEngine;

public class GirlCollectionMenu : UIMenu
{
    [SerializeField] private Transform _panelHolder;
    [SerializeField] private ContentPanel[] _panels;

    private void OnValidate()
    {
        if (_panelHolder)
            _panels = _panelHolder.GetComponentsInChildren<ContentPanel>();
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
    }

    public void Open(GirlData girl)
    {
        var panel = GetPanel(girl.Id);
        panel.transform.SetAsFirstSibling();
        panel.Open();
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
}
