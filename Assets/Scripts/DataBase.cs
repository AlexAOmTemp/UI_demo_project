using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class DataBase : MonoBehaviour
{
    [SerializeField] private List <MessageDataSO> _messageDataSOs = new List <MessageDataSO>();  
    [SerializeField] private List<Sprite> _icons = new ();
    private Dictionary<SortingInfo, MessageDataSO> _databaseRecords = new ();
    private int _currentID = 1;
    private void Start()
    {
        foreach (var item in _messageDataSOs)
            AddToDataBase(item);
        Sorting();
    }
    private struct SortingInfo
    {
        public int ID;
        public DateTime date;
        public bool Valide;
    }
    public void AddToDataBase(MessageDataSO messageDataSO)
    {
        _databaseRecords.Add(CalculateSortingInfo(messageDataSO), messageDataSO);

    }
    public void AddToDataBase(string characterId, int iconNumber, string title, string message, string date)
    {
        var newData = new MessageDataSO();
        newData.CharacterId = characterId;
        newData.Icon = _icons[iconNumber];
        newData.Title = title;
        newData.Message = message;
        newData.Date = date;
        _databaseRecords.Add(CalculateSortingInfo(newData), newData);
    }
    private SortingInfo CalculateSortingInfo(MessageDataSO messageDataSO)
    {
        var sortingInfo = new SortingInfo();
        sortingInfo.ID = _currentID++;
        sortingInfo.date = DateTime.Parse(messageDataSO.Date);
        DateTime currentDate = DateTime.Now;
        if (sortingInfo.date < currentDate)
            sortingInfo.Valide = true;
        else
            sortingInfo.Valide = false;
        return sortingInfo;
    }
    public void Sorting ()
    {
        _databaseRecords = _databaseRecords
        .OrderByDescending(x => x.Key.Valide)
        .ThenBy(x => x.Key.date)
        .ToDictionary(x => x.Key, x => x.Value);
    }
    public MessageDataSO[] GetValidMessages()
    {
        List<MessageDataSO> validSO = new();
        Sorting();
        foreach (var item in _databaseRecords)
            if (item.Key.Valide == true)
                validSO.Add(item.Value);
            else
                break;
        return validSO.ToArray();
    }
    public int GetMessagesCount()
    {
        int count = 0;
        Sorting();
        foreach (var item in _databaseRecords)
            if (item.Key.Valide == true)
                count++;
            else
                break;
        return count;
    }

}
public enum TrainerNames
{
    Elk = 0,
    Hedgehog = 1,
    Cow = 2,
    Fox = 3,
    Rabbit = 4,
    Pork = 5,
    Noname = 6
}
