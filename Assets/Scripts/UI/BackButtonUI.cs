using UnityEngine;
using UnityEngine.UI;

public class BackButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject _trainingPanel;
    [SerializeField] private GameObject _trainingButton;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            _trainingButton.SetActive(true);
            _trainingPanel.SetActive(false);
        });
    }
}
