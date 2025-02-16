using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    protected WeaponClassifier weaponClassifier;

    [Header("WEAPON DETAILS")]

    [SerializeField]
    protected int power;
    [SerializeField]
    protected int strength;
    [SerializeField]
    protected int weaponWearAmount;
}



[Serializable]
public class WeaponClassifier
{
    public Weapontype weaponType;
    public Sprite weaponSprite;

}
public enum Weapontype
{
    Bat,
    Torch,
    Grenade
}
