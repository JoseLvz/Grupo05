﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HighScore : IComparable<HighScore>
{
    public int Score { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public int ID { get; set; }

    public HighScore(int id, string name, int score, DateTime date)
    {
        this.Score = score;
        this.Name = name;
        this.ID = id;
        this.Date = date;
    }

    public int CompareTo(HighScore other)
    {
        if(other.Score < this.Score)
        {
            return -1;
        }
        else if (other.Score > this.Score)
        {
            return 1;
        }
        else if (other.Date < this.Date)
        {
            return -1;
        }
        else if (other.Date > this.Date)
        {
            return 1;
        }
        return 0;
    }
}
