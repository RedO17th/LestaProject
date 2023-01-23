using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDialogResult : ScriptableObject
{ 
    
}

[CreateAssetMenu]
public abstract class BaseDialog : ScriptableObject 
{
    [SerializeField] private int _dialogID = 0;
    [SerializeField] protected BaseDialogResult _dialogResult;

    [SerializeField] protected BaseDialogNode _startDialogNode;

    public event Action OnStarted;
    public event Action OnCompleted;

    public virtual void Start()
    { 
        
    }

    public virtual void Complete()
    {

    }
}

public abstract class BaseDialogNode : ScriptableObject
{
    //Имя используется для Нарративщика
    [SerializeField] protected string _nodeName = string.Empty;

    [TextArea]
    [SerializeField] protected string _charactersReplica = string.Empty;

    


}

[CreateAssetMenu(fileName = "SimpleDialogNode", menuName = "ScriptableObjects/DialogNode/SimpleDialogNode")]
public class SimpleDialogNode : BaseDialogNode
{
    [SerializeField] protected BaseDialogNode _nextNode = null;





}

[CreateAssetMenu(fileName = "ChoiseDialogNode", menuName = "ScriptableObjects/DialogNode/ChoiseDialogNode")]
public class ChoiseDialogNode : BaseDialogNode
{
    [SerializeField] protected List<BaseDialogNode> _nextNodes = null;





}

[CreateAssetMenu(fileName = "CloseDialogNode", menuName = "ScriptableObjects/DialogNode/CloseDialogNode")]
public class CloseDialogNode : BaseDialogNode
{

}
