using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

    //[HideInInspector]
    public int showScore;
    public bool isOver;
    private string connectionString;
    private List<HighScore> highScores = new List<HighScore>();
    public GameObject scorePrefab;
    public Transform scoreParent;
    public int topRanks;
    public int saveScores;
    public Text enterName;
    public GameObject nameDialog;


    void Start () {
        
        connectionString = "URI=file:" + Application.dataPath + "/Resources/Database/HighScoreDB.db";
        DeleteExtraScore();
        //ShowScores();
	}

    void Update () {
        if (!isOver)
        {
            Score.myScore++;
            showScore = Score.myScore;

        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            EmptyScores();
        }
	}
    
    public void EnterName()
    {
        if(enterName.text != string.Empty)
        {
            InsertScore(enterName.text, Score.myScore);
            enterName.text = string.Empty;
            nameDialog.SetActive(false);
            ShowScores();
        }

    }

    public void InsertScore(string name, int newScore)
    {
        GetScore();
        int hsCount = highScores.Count;
        if(highScores.Count > 0 )
        {
            HighScore lowestScore = highScores[highScores.Count - 1];
            if(lowestScore != null && saveScores > 0 && highScores.Count >= saveScores && newScore > lowestScore.Score)
            {
                DeleteScore(lowestScore.ID);
                hsCount--;
            }
        }
        if(hsCount < saveScores)
        {
            using (IDbConnection dbConnection = new SqliteConnection(connectionString))
            {
                dbConnection.Open();

                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    string sqlQuery = String.Format("INSERT INTO HighScores(Name,Score) VALUES ('{0}',{1});", name, newScore);
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    dbConnection.Close();
                }
            }
        }
        
    }

    public void GetScore()
    {
        highScores.Clear();
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM HighScores";
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        highScores.Add(new HighScore(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDateTime(3)));
                    }

                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
        highScores.Sort();
    }
    private void DeleteScore(int id)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("DELETE FROM HighScores WHERE PLayerID = {0};",id);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }
    private void ShowScores()
    {
        GetScore();
        for (int i = 0; i < topRanks; i++)
        {
            if (i <= highScores.Count - 1)
            {
                GameObject tmpObj = Instantiate(scorePrefab);
                HighScore tmpScore = highScores[i];

                tmpObj.GetComponent<HighScoreScript>().SetScore(tmpScore.Name, tmpScore.Score.ToString(), "#" + (i + 1).ToString());
                tmpObj.transform.SetParent(scoreParent);
                tmpObj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }
    }
    private void DeleteExtraScore()
    {
        GetScore();
        if(saveScores<= highScores.Count)
        {
            int deleteCount = highScores.Count - saveScores;
            highScores.Reverse();

            using (IDbConnection dbConnection = new SqliteConnection(connectionString))
            {
                dbConnection.Open();

                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    for (int i = 0; i < deleteCount; i++)
                    {
                        string sqlQuery = String.Format("DELETE FROM HighScores WHERE PLayerID = {0};", highScores[i].ID);
                        dbCmd.CommandText = sqlQuery;
                        dbCmd.ExecuteScalar();
                    }
                    dbConnection.Close();
                }
            }
        }
    }

    public void EmptyScores()
    {
        GetScore();
        
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                dbCmd.CommandText = "DELETE FROM HighScores";
                dbCmd.ExecuteScalar();
            }
            dbConnection.Close();
        }
    }
}
