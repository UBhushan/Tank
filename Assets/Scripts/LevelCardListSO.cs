using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelCardListSO : ScriptableObject
{
    [SerializeField] public LevelCardSo[] levels;
}
