using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUIController : MonoBehaviour
{
    /* ��� ��������� � ������ ����� ���������� ������� ���� ����-���������
     * � ������ ����. ���� ����� ������ - ����������, ����� ���� ControlerHolder
     * � ������� ����� Initialize ����������� */

    protected BaseWindow _�ontrollerHolder = null;

    public virtual void Initialize(BaseWindow window)
    {
        _�ontrollerHolder = window;
    }
}
