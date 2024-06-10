using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerExperience : MonoBehaviour, IDataPersistence
{
   Agent agent;
   Health health;
   GameObject player;
   NPCInteractable nPCInteractable;
   public int maxXP = 0;
   public int damageValue =1;
   public int currentXP = 0;

   bool attackIsUpgraded = false;

   bool healthIsUpgraded = false;

   public GameObject healthPanel;

   public Image []attackPowerUI;
   public GameObject attackPanel;

   public int currentLevel =1;
   bool levelIsUpgraded =false;

   public TextMeshProUGUI levelUI;
    
 

   void Awake()
   {
      agent = GetComponent<Agent>(); 
      nPCInteractable = GetComponent<NPCInteractable>();
      health = GetComponent<Health>();
    
   }

 
   public void Update()
   {
      Damage();
   }
   
   public int Damage()
   {
      if (currentXP >= 100&& attackIsUpgraded == false  && healthIsUpgraded == false && levelIsUpgraded == false)
      {
         damageValue =  damageValue + 1 ;
         health.maxHealth = health.maxHealth + 1;
         currentLevel = currentLevel +1 ;
       
         healthPanel.SetActive(true);
         attackPanel.SetActive(true);
         levelIsUpgraded = true;
         attackIsUpgraded = true;
         healthIsUpgraded = true;
         levelUI.text = "2";
      }
      return damageValue;
   }

   //Connect to GameData and Data Persistence for saved game health 
   public void LoadData(GameData data)
   {
     this.currentXP = data.currentXP; 
     this.damageValue = data.damageValue;
     this.currentLevel = data.currentLevel;
   }

   public void SaveData(ref GameData data)
   {
     data.currentXP = this. currentXP;
     data.damageValue = this.damageValue;
     data.currentLevel = this.currentLevel;
   }

}
