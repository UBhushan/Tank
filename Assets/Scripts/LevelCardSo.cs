using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelCardSo : ScriptableObject
{
    [SerializeField] public int levelnum;
    [SerializeField] public CardType cardType; 

}

public enum CardType
{
    locked,
    unlocked,
    Played
}