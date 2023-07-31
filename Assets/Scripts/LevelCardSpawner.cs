using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCardSpawner : MonoBehaviour
{
    [SerializeField] private LockedCard lockedCard;
    [SerializeField] private UnlockedCard unlockedCard;

    [SerializeField] private float size = 10f;

    private Level[] levels;

    private void Start() {
        SpawnCards();
    }

    private void SpawnCards()
    {
        levels = GameManager.instance.GetLevels();

        foreach(Level l in levels)
        {
            if(l.levelNum != 0)
            {
                if(!l.isUnlocked)
                {
                    LockedCard iCard = Instantiate(lockedCard);
                    iCard.transform.SetParent(this.transform);

                    iCard.transform.localPosition = Vector3.zero;
                    iCard.transform.localRotation = Quaternion.identity;
                    iCard.transform.localScale = Vector3.one * size;
                    
                }

                if(l.isUnlocked)
                {
                    UnlockedCard iCard = Instantiate(unlockedCard);
                    iCard.transform.SetParent(this.transform);
                    iCard.SetLevelNum(l.levelNum);

                    iCard.transform.localPosition = Vector3.zero;
                    iCard.transform.localRotation = Quaternion.identity;
                    iCard.transform.localScale = Vector3.one * size;
                }
            }
            

        }
    }

}
