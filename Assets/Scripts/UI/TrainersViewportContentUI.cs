using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainersViewportContentUI : MonoBehaviour
{
    [SerializeField] private MessagePanelUI _messagePanel;
    [SerializeField] private Button _trainerButtonPrefab;
    [SerializeField] private List<Sprite> _trainerIcons = new List<Sprite>();
    [SerializeField] private Sprite _selected;
    [SerializeField] private Sprite _unselected;
    private List<SelectTrainerButtonUI> _trainerButtons = new List<SelectTrainerButtonUI>();
    void Start()
    {
        int i = 0;
        foreach (var icon in _trainerIcons)
        {
            var newButton = Instantiate(_trainerButtonPrefab, this.transform);
            var script = newButton.GetComponent<SelectTrainerButtonUI>();
            script.SetSprites((TrainerNames)i, icon, _selected, _unselected);
            i++;
            script.SetUnselected();
            script.Clicked += SelectTrainerButton_Clicked;
            _trainerButtons.Add(script);
        }
    }

    private void SelectTrainerButton_Clicked(object sender, EventArgs e)
    {
        foreach (var button in _trainerButtons)
        {
            if (button == sender as SelectTrainerButtonUI)
            {
                if (button.IsSelected() == false)
                {
                    button.SetSelected();
                    _messagePanel.ChangeActiveTrainer(button.GetTrainerName());
                }
                else
                {
                    button.SetUnselected();
                    _messagePanel.ChangeActiveTrainer(TrainerNames.Noname);
                }
            }
            else
                button.SetUnselected();
        }
    }
}
