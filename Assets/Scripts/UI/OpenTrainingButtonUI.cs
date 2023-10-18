using UnityEngine;
using UnityEngine.UI;

public class OpenTrainingButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject _trainingPanel;
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            _trainingPanel.SetActive(true);
            this.gameObject.SetActive(false);
        });
    }
}
