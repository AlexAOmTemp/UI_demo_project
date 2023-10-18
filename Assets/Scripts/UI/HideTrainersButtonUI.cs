using UnityEngine;
using UnityEngine.UI;

public class HideTrainersButtonUI : MonoBehaviour
{
    [SerializeField] private RectTransform _trainerPanel;
    [SerializeField] private GameObject _hidingPanel;
    private bool _isPanelHided = false;
    private float hiddenPartSize;
    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            TogglePanel();
        });
        hiddenPartSize = _hidingPanel.GetComponent<RectTransform>().sizeDelta.y;
    }

    private void TogglePanel()
    {
        if (_isPanelHided)
        {
            _hidingPanel.SetActive(true);
            _trainerPanel.sizeDelta = new Vector2(_trainerPanel.sizeDelta.x, _trainerPanel.sizeDelta.y + hiddenPartSize);
            _isPanelHided = false;
        }
        else
        {
            _hidingPanel.SetActive(false);
            _trainerPanel.sizeDelta = new Vector2(_trainerPanel.sizeDelta.x, _trainerPanel.sizeDelta.y - hiddenPartSize);
            _isPanelHided = true;
        }
    }
}
