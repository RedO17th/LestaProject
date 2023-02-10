using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GamePlayer : BasePlayer
{
    //#region Public Properties
    //public Quaternion Rotation => transform.rotation;
    //#endregion

    //public override void Initialize(PlayerSubSystem system)
    //{
    //    base.Initialize(system);

    //    //InitializeControllers();
    //    //PreparingControllers();
    //}

    //#region Systems part
    ////Возможно все это дело необходимо вынести в PlayerSubSystem... А здесь только делегирование
    //private void InitializeControllers()
    //{
    //    foreach (var controller in _controllers)
    //        controller.Initialize(this);
    //}

    //private void PreparingControllers()
    //{
    //    foreach (var controller in _controllers)
    //        controller.Prepare();
    //}

    //private void EnableControllers()
    //{
    //    foreach (var controller in _controllers)
    //        controller.Enable();
    //}
    //private void DisableControllers()
    //{
    //    foreach (var controller in _controllers)
    //        controller.Disable();
    //}
    //#endregion

    //public void Activate()
    //{
    //    EnableControllers();
    //}

    //#region MovementPart
    //public void Rotate(Quaternion rotation)
    //{
    //    transform.rotation = rotation;
    //}
    //#endregion

    //public void Deactivate()
    //{
    //    DisableControllers();
    //}

  //  #region Wallet part

  //  //Переопределить при необходимости...

  //  #endregion

  //  //Interact part (test)
  //  //[ForMe] А вообще есть смысл передавать encounter'a... Подумать... Мб Event?

  //  private IInteractable _interactable = null;
  //  public void SetInteractable(IInteractable encounter)
  //  {
  //      _interactable = encounter;
  //  }
  //  public void RemoveInteractable(IInteractable encounter)
  //  {
  //      _interactable = null;
  //  }

  //  private void Update()
  //  {
  //      if (_interactable != null && Input.GetKeyDown(KeyCode.E))
  //      {
  //          _interactable.Interact();
  //      }
		
		//if (Input.GetKeyDown(KeyCode.Space)) Health.CurrentValue -= 10;
  //  }
}
