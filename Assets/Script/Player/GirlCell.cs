using UnityEngine;

public class GirlCell : MonoBehaviour
{
    [Range(0, 1f)]
    [SerializeField] private float _smoothTime;
    [SerializeField] private Vector2 _maskOffset;
    [Header("Reference")]
    [SerializeField] private Transform _maskHolder; 
    [SerializeField] private GameObject _girlCell;

    private Vector2 _target;
    private Vector2 _velocity;
    private Vector2 _startPosition;

    private void Awake()
    {
        _startPosition = _maskHolder.localPosition;
        _target = _startPosition;
    }

    private void Update()
    {
        _maskHolder.localPosition = Vector2.SmoothDamp(_maskHolder.localPosition,
            _target, ref _velocity, _smoothTime);
    }

    public void ShowCell()
    {
        _girlCell.SetActive(true);
        _maskHolder.localPosition = _startPosition;
    }

    public void HideCell()
    {
        _girlCell.SetActive(false);
    }

    public void UpdateProgress(float progress)
    {
        progress = Mathf.Clamp01(progress);
        _target = _startPosition + _maskOffset * progress;
    }
}
