using UnityEngine;
using UnityEngine.UI;

public class SelectablePanelsUI : MonoBehaviour
{
   
    [SerializeField] private TopPanelButtonUI[] _TopButtons = new TopPanelButtonUI[4];  

    private void Start()
    {
        SetActiveButton(_TopButtons[0]);
        foreach (var button in _TopButtons)
        {
            button.Clicked += On_Button_Clicked;
        }

    }

    private void On_Button_Clicked(object sender, System.EventArgs e)
    {
        SetActiveButton(sender as TopPanelButtonUI);
    }

    public void SetActiveButton(TopPanelButtonUI activeButton)
    {
        foreach (var button in _TopButtons)
            if (button == activeButton)
                button.SetChecked();
            else
                button.SetUnchecked();
    }
}
