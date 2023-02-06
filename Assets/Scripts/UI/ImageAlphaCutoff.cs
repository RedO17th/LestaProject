using UnityEngine;
using UnityEngine.UI;

public class ImageAlphaCutoff : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] public float AlphaLevel = 1f;
    private Image _buttonImage;
    void Start()
    {
        _buttonImage = gameObject.GetComponent<Image>();
        _buttonImage.alphaHitTestMinimumThreshold = AlphaLevel;
    }
}
