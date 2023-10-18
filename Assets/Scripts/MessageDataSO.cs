using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/MessageDataSO")]
public class MessageDataSO : ScriptableObject
{
    public string CharacterId;
    public Sprite Icon;
    public string Title;
    public string Message;
    public string Date;
    public Color TitleColor;
}