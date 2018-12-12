using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlocker : MonoBehaviour {

    int levelDoned;
    public GameObject[] levelUnlocked;


	void Start () {

        levelDoned = PlayerPrefs.GetInt("levelDoned");

        for (int i = 0; i < levelUnlocked.Length; i++)
        {
            if (i+1 < levelDoned)
            {
                levelUnlocked[i].SetActive(false);
            }
        }

        Debug.Log(levelDoned);
    }
}


