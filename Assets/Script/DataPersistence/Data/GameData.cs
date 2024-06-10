using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameData
{
    public int currentHealth;
    public int currentXP;
    public int damageValue;
    public int currentLevel;
    public bool itemQuestTaken; 

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
        this.itemQuestTaken = false;
        playerPosition = Vector3.zero;
        // itemButton = new SerializableDictionary<string, bool>();
        this.textBox = "";
    }
}
