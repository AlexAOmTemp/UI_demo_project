using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageContentUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _message;
    [SerializeField] private TextMeshProUGUI _date;
    [SerializeField] private Image _icon;
    private string _characterID;
    public void DisplayDataFromMessage(MessageDataSO messageDataSO)
    {
        
        var newColor = messageDataSO.TitleColor;
        _title.color = new Color(newColor.r, newColor.g, newColor.b, 1f);
        _title.SetText( messageDataSO.Title );
        _message.SetText( messageDataSO.Message );
        _date.SetText( messageDataSO.Date.Substring(0,5) );
        Debug.Log(_date.text);
        _icon.sprite = messageDataSO.Icon;
        _characterID = messageDataSO.CharacterId;
    }
    public string GetCharacterId()
    {
        return _characterID;
    }
    public string GetDate()
    {
        return _date.text;
    }
}
