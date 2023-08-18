using UnityEngine;
using UnityEngine.UI;

public class Carusel : MonoBehaviour
{
    [SerializeField] private float _speedDelta;
    [SerializeField] private float _offsetSteep;
    [SerializeField] private Vector2 _rangeOffset;
    [Header("Reference")]
    [SerializeField] private RectTransform _pivot;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _backButton;

    private Vector2 _startPosition;
    private Vector2 _target;

    private void Awake()
    {
        _nextButton.onClick.AddListener(Next);
        _backButton.onClick.AddListener(Back);
        _startPosition = _pivot.anchoredPosition;
        Restart();
    }

    private void FixedUpdate()
    {
        _pivot.anchoredPosition = Vector3.MoveTowards(_pivot.anchoredPosition, _target, _speedDelta);
    }

    public void Restart()
    {
        _target = _startPosition;
        _pivot.anchoredPosition = _startPosition;
        UpdateButton(_offsetSteep);
    }

    public void Next()
    {
        UpdateTarget(-_offsetSteep);
    }

    public void Back()
    {
        UpdateTarget(_offsetSteep);
    }

    private bool UpdateTarget(float offset)
    {
        var position = _target.x + offset;
        if (position <= _rangeOffset.x && position >= _rangeOffset.y)
        {
            _target = Vector2.right * position;
            UpdateButton(offset);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateButton(float offset)
    {
        var nextPosition = _target.x + offset;
        _nextButton.interactable = nextPosition >= _rangeOffset.y;
        _backButton.interactable = nextPosition <= _rangeOffset.x;
    }

}
