using UnityEngine;

public class OpenGirlMenu : UIMenu
{
    [SerializeField] private GirlPanel[] _panels;

    public void Open(Girl girl)
    {
        var panel = GetPanel(girl.Data.Sprite);
        panel.Open();
    }

    private GirlPanel GetPanel(Sprite sprite)
    {
        foreach (var panel in _panels)
        {
            if (panel.Sprite == sprite)
                return panel;
        }
        return null;
    }
}
