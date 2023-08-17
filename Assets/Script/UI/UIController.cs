using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private InterfaceSwitcher _intefaceHolder;

    private UIMenu _openMenu;

    private void Reset()
    {
        enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMenu();
        }
    }

    public void OpenMenu(UIMenu menu)
    {
        enabled = true;
        if ( _openMenu)
        {
            _openMenu.ShowSubMenu(menu);
        }
        else
        {
            _openMenu = menu;
            _openMenu.Show();
        }
    }

    public void CloseMenu()
    {
        if (_openMenu.Hide())
        {
            enabled = false;
            _openMenu = null;
        }
    }
}
