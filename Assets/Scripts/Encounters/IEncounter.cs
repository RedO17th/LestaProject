using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEncounter : IInteractable
{
    void Activate();
    void Deactivate();
}

