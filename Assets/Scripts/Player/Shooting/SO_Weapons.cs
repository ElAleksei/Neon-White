using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon_", menuName = "ScriptableObjects/Weapon", order = 1)]

public class SO_Weapons : ScriptableObject
{
    public int damage;
    public float range;
    public int fireRate;
    public int nextTimetoFire;
    public int MaxAmmo;
    public int CurrentAmmo;
    public bool Discard;
}
