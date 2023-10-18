using System.Collections.Generic;
using UnityEngine;

public class ContentPanelUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _contentPanels = new();

    public void ChangePanel(GameObject newPanel)
    {
        foreach (var panel in _contentPanels)
        {
            if (panel == newPanel)
                panel.SetActive(true);
            else
                panel.SetActive(false);
        }
    }
}
