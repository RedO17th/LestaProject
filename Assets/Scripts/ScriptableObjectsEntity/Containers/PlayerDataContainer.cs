using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/Container/PlayerData", order = 2)]
public class PlayerDataContainer : BaseDataContainer
{
    [Space]
    [Header("Health")]
    [Range(0f, 150f)]
    [SerializeField] private int _maxHealth = 100;

    [Space]
    [Header("WalletOfPoints")] //на сколько € помню, это опыт. ћожет лучше это не "кошелек с очками", а общеприн€тое "Experience",
    [SerializeField] private int _walletOfPoints = 100;
    [SerializeField] private int _level = 1;

    [Space]
    [Header("Movement")]
    [Range(5f, 25f)]
    [SerializeField] private float _walkSpeed = 5f;
    [Range(5f, 25f)]
    [SerializeField] private float _runSpeed = 5f;
    [Range(5f, 50f)]
    [SerializeField] private float _speedRotation = 5f;

    public int MaxHealth => _maxHealth;

    public int WalletOfpoints => _walletOfPoints;
    public int Level => _level;

    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float SpeedRotation => _speedRotation;
}
