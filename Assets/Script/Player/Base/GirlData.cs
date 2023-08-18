using System.Collections.Generic;
using UnityEngine;

public class GirlData : MonoBehaviour
{
    [SerializeField] private int _id;
    [Min(10)]
    [SerializeField] private int _loveHealth;
    [Min(10)]
    [SerializeField] private int _cellHealth;
    [SerializeField] private string _girlName;
    [SerializeField] private string[] _dialogs;
    [SerializeField] private Sprite _sprite;
    [Header("Reference")]
    [SerializeField] private SpriteRenderer _body;
    [SerializeField] private SpriteRenderer _shadow;

    private List<string> _dialogAcces = new List<string>();

    public int Id => _id;
    public int CellHealth => _cellHealth;
    public int LoveHealth => _loveHealth;
    public string GirlName => _girlName;
    public Sprite Sprite => _sprite;

    private void OnValidate()
    {
        if(_body)
            _body.sprite = _sprite;
        if (_shadow)
            _shadow.sprite = _sprite;
    }

    private void Reset()
    {
        _loveHealth = 20;
        _cellHealth = 20;
    }

    public string GetDialog()
    {
        if (_dialogAcces.Count == 0)
        {
            _dialogAcces.AddRange(_dialogs);
        }
        var dialog = _dialogAcces[Random.Range(0, _dialogAcces.Count)];
        _dialogAcces.Remove(dialog);
        return dialog;
    }
}
