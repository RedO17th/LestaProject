//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//[RequireComponent(typeof(Image))]
//public abstract class BaseButton
//    : 
//    MonoBehaviour,
//    IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
//{
//    [SerializeField] private Image image = null;

//    [SerializeField] private Color normalColor = Color.white;


//    public void Start()
//    {
//        image = GetComponent<Image>();
//    }

//    private void OnSetProperty()
//    {
//#if UNITY_EDITOR
//        if (!Application.isPlaying)
//            DoStateTransition(currentSelectionState, true);
//        else
//#endif
//            DoStateTransition(currentSelectionState, false);
//    }


//    public abstract void OnPointerEnter(PointerEventData eventData);

//    public abstract void OnPointerExit(PointerEventData eventData);

//    public abstract void OnPointerClick(PointerEventData eventData);
//}

