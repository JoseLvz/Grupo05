using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlocker : MonoBehaviour {

    int levelDoned;
    public GameObject[] levelUnlocked;


	void Start () {
        levelDoned = PlayerPrefs.GetInt("levelDoned", 1);
	}
	
	void Update () {

        for (int i = 0; i <levelUnlocked.Length; i++)
        {
            if(i > levelDoned)
            {
                levelUnlocked[i].SetActive(false);
            }
        }
	}

}
