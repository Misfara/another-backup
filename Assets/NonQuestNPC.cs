using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using System;

public class NonQuestNPC : MonoBehaviour
{
    
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    
    [SerializeField] Transform Player;
    [SerializeField] Transform thisNPC;
    PlayerInteraction playerInteraction;
    AgentMover agentMover;
    public string[] dialogue;
    private int index = 0;

    public float wordSpeed;
    public bool playerIsClose;

    Color defaultColor;
   SpriteRenderer spriteRenderer;

   Animator animator;
   public float delay = 0.25f;


    public bool canPress = false; 
   public bool isTyping = false;

   PlayerExperience playerExperience;


    void Start()
    {
        dialogueText.text = "";
        agentMover= GetComponent<AgentMover>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
        animator = GetComponent<Animator>();
         playerExperience = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerExperience>();
          playerInteraction = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>();
    }

      

    

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (!dialoguePanel.activeInHierarchy )
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
           
                

                
            }
            else if (dialogueText.text == dialogue[index])
            {
                NextLine();
             
            }

           
        }
        if (!isTyping){
        if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy )
        {
            StartCoroutine(JustWait());
         
        }

         
        }

       

        

        
    }

    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        isTyping = true; 
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
            canPress = true;
        
        }
         isTyping = false;
    }

    public IEnumerator JustWait()
    {
          if(canPress == true) 
           yield return new WaitForSeconds(delay);
            RemoveText();
    }

 
    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
            canPress = true;
            
        }
        else
        {
            RemoveText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            spriteRenderer.color = new Color(1f, 1f,1f);
            animator.speed = 0.5f;
        }

          
 
    }

    private void OnTriggerStay2D(Collider2D other){
        if (other.CompareTag("Player")){
                if(Player.position.x  > thisNPC.position.x ){
                spriteRenderer.flipX = false;
             }
                if(Player.position.x  < thisNPC.position.x ){
                spriteRenderer.flipX = enabled;
             }
        }

      

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            
            spriteRenderer.color = defaultColor;
            animator.speed = 1f;
        }
    }

     
    }



   
    
