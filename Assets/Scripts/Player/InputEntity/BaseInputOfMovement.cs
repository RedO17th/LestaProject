using UnityEngine;

public abstract class BaseInputOfMovement : MonoBehaviour
{
    public abstract bool IsInput();

    public abstract Vector3 Read();
}
