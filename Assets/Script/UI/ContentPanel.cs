using UnityEngine;
using UnityEngine.UI;

public class ContentPanel : MonoBehaviour
{
    [SerializeField] private bool _isOpen;
    [SerializeField] private Color _openColor;
    [SerializeField] private Color _closeColor;
    [SerializeField] private Sprite _sprite;
    [Header("Reference")]
    [SerializeField] private Image _icon;
    [SerializeField] private TextUI _nameText;

    public bool IsOpen => _isOpen;
    public Sprite Sprite => _sprite;

    private void OnValidate()
    {
        if(_icon)
            _sprite = _icon.sprite;
        _icon.color = _isOpen ? _openColor : _closeColor;
    }

    public void Open()
    {
        _isOpen = true;
        _icon.color = _openColor;
    }

    public void Close()
    {
        _isOpen = false;
        _icon.color = _closeColor;
    }

}
