using UnityEngine.UI;
using UnityEngine;
using System;

public class TopPanelButtonUI : MonoBehaviour
{
    public event EventHandler Clicked;
    [SerializeField] private ContentPanelUI _contentPanelUI;
    [SerializeField] private Color _colorChecked;
    [SerializeField] private Color _colorUnchecked;
    [SerializeField] private Image _icon;
    [SerializeField] private GameObject _content;
    public void SetChecked ()
    {
        _icon.GetComponent<Image>().color = _colorChecked;
    }
    public void SetUnchecked()
    {
        _icon.GetComponent<Image>().color = _colorUnchecked;
    }
    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            _contentPanelUI.ChangePanel(_content);
            Clicked.Invoke(this, EventArgs.Empty);
        });
    }
}
