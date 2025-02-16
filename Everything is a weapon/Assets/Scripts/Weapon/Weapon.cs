using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    protected WeaponClassifier weaponClassifier;

    [Header("WEAPON DETAILS")]
    [SerializeField]
    protected GameObject weaponProjectile;

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
