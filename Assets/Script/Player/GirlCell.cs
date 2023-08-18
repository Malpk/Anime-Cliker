using UnityEngine;

public class GirlCell : MonoBehaviour
{
    [Range(0, 1f)]
    [SerializeField] private float _smoothTime;
    [SerializeField] private Vector2 _maskOffset;
    [SerializeField] private Vector2 _startMaskPosition;
    [Header("Reference")]
    [SerializeField] private Transform _maskHolder; 
    [SerializeField] private GameObject _girlCell;

    private Vector2 _target;
    private Vector2 _velocity;


    private void Awake()
    {
        _target = _startMaskPosition;
    }

    private void Update()
    {
        _maskHolder.localPosition = Vector2.SmoothDamp(_maskHolder.localPosition,
            _target, ref _velocity, _smoothTime);
    }

    public void ShowCell()
    {
        _girlCell.SetActive(true);
        _target = _startMaskPosition;
        _maskHolder.localPosition = _startMaskPosition;
        enabled = true;
    }

    public void HideCell()
    {
        enabled = false;
        _girlCell.SetActive(false);
    }

    public void LoadProgress(float progress)
    {
        _target = _startMaskPosition + _maskOffset * progress;
        _maskHolder.localPosition = _startMaskPosition + _maskOffset * progress;
    }

    public void UpdateProgress(float progress)
    {
        progress = Mathf.Clamp01(progress);
        _target = _startMaskPosition + _maskOffset * progress;
    }
}
