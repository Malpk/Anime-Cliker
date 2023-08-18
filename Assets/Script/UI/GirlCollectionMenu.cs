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

    public void Open(GirlData girl)
    {
        var panel = GetPanel(girl.Sprite);
        panel.transform.SetAsFirstSibling();
        panel.Open();
    }

    private ContentPanel GetPanel(Sprite sprite)
    {
        foreach (var panel in _panels)
        {
            if (panel.Sprite == sprite)
                return panel;
        }
        return null;
    }
}
