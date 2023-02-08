using UnityEngine;

[CreateAssetMenu(fileName = "DiaryNote", menuName = "DB/Journal/Create New DiaryNote")]
public class DiaryNote : ScriptableObject, INote
{
    [SerializeField] private string _id;
    [SerializeField] private string _header;
    [SerializeField] private string _content;
    public string Id => _id;

    public string Header => _header;

    public string Content => _content;


    public void SetData(string id, string header, string content)
    {
        _id = id;
        _header = header;
        _content = content;
    }
}
