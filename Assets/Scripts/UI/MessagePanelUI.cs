using System.Collections.Generic;
using UnityEngine;

public class MessagePanelUI : MonoBehaviour
{
    [SerializeField] private DataBase _dataBase;
    [SerializeField] private GameObject _messagePrefab;
    private List<GameObject> _messages = new List<GameObject>();
    void Start()
    {
        CreateMessagesFromDB();
    }

    public void CreateMessagesFromDB()
    {
        _messages.Clear();
        var messageDataSOs = _dataBase.GetValidMessages();
        for (int i = 0; i < messageDataSOs.Length; i++)
        {
            var message = Instantiate(_messagePrefab, this.transform);
            message.name = "SortedMessage" + i;
            var script = message.GetComponent<MessageContentUI>();
            script.DisplayDataFromMessage(messageDataSOs[i]);
            _messages.Add(message);
        }
    }
    public void ChangeActiveTrainer(TrainerNames name)
    {
        if (name == TrainerNames.Noname)
        {
            foreach (var message in _messages)
                message.SetActive(true);
        }
        else
        {
            foreach (var message in _messages)
            {
                if (message.GetComponent<MessageContentUI>().GetCharacterId().Contains(name.ToString()))
                    message.SetActive(true);
                else
                    message.SetActive(false);
            }
        }
    }
}
