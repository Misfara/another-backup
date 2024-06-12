using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SaveSlotMenu : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private StartScreen startScreen;
    [SerializeField] private GameObject LoadingScreen;
    private SaveSlot[] saveSlots;

    private bool isLoadingGame = false;

    [Header("Menu Buttons")]
    [SerializeField] private Button backButton;

    [Header("Confirmation PopUp")]
    [SerializeField] private ConfimationPopUpMenu confirmationPopUpMenu;


    private void Awake()
    {
        saveSlots = this.GetComponentsInChildren<SaveSlot>();
    }

    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        //disable all buttons
        DisableMenuButtons();

        //case - Loading game
        if (isLoadingGame)
        {
            LoadingScreen.SetActive(true);
            DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
            SaveGameAndLoadScene();
        }
        //case - new game, but the save slot has data
        else if (saveSlot.hasData)
        {
            confirmationPopUpMenu.ActivateMenu(
                "Starting a New Game with this slot will override the currently saved data. Are you sure?", 
                //function to execute if we selected 'yes'
                () => 
                {
                    LoadingScreen.SetActive(true);
                    DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
                    DataPersistenceManager.instance.NewGame();
                    SaveGameAndLoadScene();
                },
                //function to execute if we select 'cancel'
                () =>
                {
                    this.ActivateMenu(isLoadingGame);
                }
            );
        }
        //case - new game, and the save slot has no data
        else
        {
            LoadingScreen.SetActive(true);
            DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
            DataPersistenceManager.instance.NewGame();
            SaveGameAndLoadScene();
        }
    }

    public void SaveGameAndLoadScene()
    {
        //save the game anytime before loading a new scene
        DataPersistenceManager.instance.SaveGame();
        //Load the scene
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void OnClearClicked(SaveSlot saveSlot)
    {
        DisableMenuButtons();

        confirmationPopUpMenu.ActivateMenu(
            "Are you sure you want to delete this saved data?",
            //function to execute if we select 'yes'
            () =>
            {
                DataPersistenceManager.instance.DeleteProfileData(saveSlot.GetProfileId());
                ActivateMenu(isLoadingGame);
            },
            //function to execute if we select 'cancel'
            () =>
            {
                ActivateMenu(isLoadingGame);
            }
        );
    }

    public void onBackClicked()
    {
        startScreen.ActivateMenu();
        this.DeactivateMenu();
    }

    public void ActivateMenu(bool isLoadingGame)
    {
        //set this menu to be active
        this.gameObject.SetActive(true);

        //Load all of the profiles that exist
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData();

        //ensure the back button is enable when we activate the menu
        backButton.interactable = true;

        //Set Mode
        this.isLoadingGame = isLoadingGame;

        //Loop through each save slot in the UI and set the sontent appropriately
        foreach (SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
            saveSlot.SetData(profileData);
            if (profileData == null && isLoadingGame)
            {
                saveSlot.SetInteractable(false);
            }
            else
            {
                saveSlot.SetInteractable(true);
            }
        }
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

    private void DisableMenuButtons()
    {
        foreach (SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }
        backButton.interactable = false;
    }
}