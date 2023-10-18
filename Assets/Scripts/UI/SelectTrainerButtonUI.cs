using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectTrainerButtonUI : MonoBehaviour
{
    public event EventHandler Clicked;
    [SerializeField] private Image _trainerIcon;
    private Sprite _selected;
    private Sprite _unselected;
    private Image _roundBackground;
    private bool _isSelected = false;
    private TrainerNames _name;
    public void SetSprites(TrainerNames name, Sprite icon, Sprite selected, Sprite unselected)
    {
        _name = name;
        _trainerIcon.sprite = icon;
        _selected = selected;
        _unselected = unselected;
        _roundBackground = GetComponent<Image>();
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            Clicked.Invoke(this, EventArgs.Empty);
        });
    }
    public void SetSelected()
    {
        _roundBackground.sprite = _selected;
        _isSelected = true;
    }
    public void SetUnselected()
    {
        _roundBackground.sprite = _unselected;
        _isSelected = false;
    }
    public bool IsSelected()
    {
        return _isSelected;
    }
    public TrainerNames GetTrainerName()
    {
        return _name;
    }
}
