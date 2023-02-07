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
        Types.Add(typeof(UsableItem), "Расходник");
        Types.Add(typeof(Equipment), "Экипировка");
        Types.Add(typeof(Weapon), "Оружие");
        Types.Add(typeof(InventoryItem), "Предмет");
        Types.Add(typeof(Ammo), "Патроны");
        Types.Add(typeof(QuestItem), "Квестовый предмет");
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
