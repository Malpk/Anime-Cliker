using UnityEngine;
using UnityEngine.UI;

public class ContentPanel : MonoBehaviour
{
    [SerializeField] private bool _isOpen;
    [SerializeField] private Color _openColor;
    [SerializeField] private Color _closeColor;
    [SerializeField] private GirlData _girl;
    [Header("Reference")]
    [SerializeField] private Image _icon;
    [SerializeField] private TextUI _nameText;

    public int PanelId => _girl.Id;
    public bool IsOpen => _isOpen;

    private void OnValidate()
    {
        name = "ContentPanel";
        _nameText?.SetText(_girl.GirlName);
        if (_girl)
            name = $"[{_girl.name}]" + name;
        if (_icon)
            _icon.sprite = _girl.Sprite;
        _icon.color = _isOpen ? _openColor : _closeColor;
    }

    public void Open()
    {
        _isOpen = true;
        _icon.color = _openColor;
        _nameText.gameObject.SetActive(true);
    }

    public void Close()
    {
        _isOpen = false;
        _icon.color = _closeColor;
        _nameText.gameObject.SetActive(false);
    }

}
