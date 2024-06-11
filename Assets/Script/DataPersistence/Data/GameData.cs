using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public int currentHealth;
    public int currentXP;
    public int damageValue;
    public int currentLevel;
    public int i;
    public SerializableDictionary<string, bool> questFinished; 
    // public SerializableDictionary<string, bool> isFull;

    public Vector3 playerPosition;
    // public SerializableDictionary<string, bool> itemButton;
    public string textBox;

    //the values defined in this constructor will be the default values
    //the game starts with when there's no data to load
    
    public GameData()
    {
        this.currentHealth = 2;
        this.currentXP = 0;
        this.damageValue = 1;
        this.currentLevel = 1;
        this.i = 0;
        questFinished = new SerializableDictionary<string, bool>();
        // isFull = new SerializableDictionary<string, bool>();
        playerPosition = Vector3.zero;
        // itemButton = new SerializableDictionary<string, bool>();
        this.textBox = "";
    }
}
