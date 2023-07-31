using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int numOfLevels;
    private Level[] levels;
    private bool isFirstTime = true;

    [SerializeField] private GameObject thankUScrean;

    private void Awake() {
        levels = new Level[numOfLevels + 1];
        SingletonSetup();
        DontDestroyOnLoad(this.gameObject);

        FirstTimeCheck();
    }

    private void FirstTimeCheck()
    {
        if(isFirstTime)
        {
            FirstTimeLevelsSetup();
            isFirstTime = false;
        }
        else
            LoadSavedLevelsStruct();

    }

    private void FirstTimeLevelsSetup()
    {
        for (int i = 0; i <= numOfLevels; i++)
        {
            levels[i].levelNum = i;

            if(i == 1)
                levels[i].isUnlocked = true;
            else
                levels[i].isUnlocked = false;

        }
    }

    public void LevelEnded()
    {
        // toggleUI
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if(currentLevel < numOfLevels)
        {
            levels[currentLevel + 1].isUnlocked = true;
            LoadLevelSelect();
        }
        else
        {   
            thankUScrean.gameObject.SetActive(true);

            Invoke(nameof(LoadLevelSelect), 5f);
        }

    }

    private void LoadLevelSelect()
    {
        int levelSelect = 0;
        SceneManager.LoadScene(levelSelect);

        thankUScrean.gameObject.SetActive(false);
    }

    public Level[] GetLevels()
    {
        return levels;
    }

    public int NumOfLevels()
    {
        return numOfLevels;
    }

    private void LoadSavedLevelsStruct()
    {
        //Load Saved Struct
    }
    

    private void SingletonSetup()
    {
        if(instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }
}

public struct Level
{
    public int levelNum;
    public bool isUnlocked;
}