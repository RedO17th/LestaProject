using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ItemTypesDictionary
{
    private static Dictionary<Type, string> Types;

    public static void InitDictionary()
    {
        Types = new Dictionary<Type, string>();
        Types.Add(typeof(UsableItem), "���������");
        Types.Add(typeof(Equipment), "����������");
        Types.Add(typeof(Weapon), "������");
        Types.Add(typeof(InventoryItem), "�������");
        Types.Add(typeof(Ammo), "�������");
        Types.Add(typeof(QuestItem), "��������� �������");
    }

    public static Dictionary<Type, string> GetTypesDictionary()
    {
        if(Types == null)
        {
            InitDictionary();
        }

        return Types;
    }

    public static string GetValue(Type type)
    {
        if (Types == null)
            InitDictionary();

        return Types[type];
    }
}
