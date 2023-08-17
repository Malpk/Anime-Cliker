using UnityEngine;

public class DialogWindow : MonoBehaviour
{
    [SerializeField] private TextUI _text;

    public void ShowDialog(string text)
    {
        _text.SetText(text);
        gameObject.SetActive(true);
    }

    public void HideDialog()
    {
        gameObject.SetActive(false);
    }

}
