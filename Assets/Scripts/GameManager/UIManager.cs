using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button mainButtonResume;
    public Button mainButtonControls;
    public Button mainButtonSound;
    public Button mainButtonExit;
    public GameController gameController;
    public VisualElement mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameManager").GetComponent<GameController>();
        mainMenu = GetComponent<UIDocument>().rootVisualElement;
        
        if (mainMenu != null && gameController != null)
        {
            mainButtonResume = mainMenu.Q<Button>("MenuButtonResume");
            mainButtonControls = mainMenu.Q<Button>("MenuButtonControls");
            mainButtonSound = mainMenu.Q<Button>("MenuButtonSound");
            mainButtonExit = mainMenu.Q<Button>("MenuButtonExit");

            mainButtonResume.clicked += ResumeButtonPressed;
        }
}

    // Update is called once per frame
    void Update()
    {
        
    }

    //resume game
    void ResumeButtonPressed()
    {
        Debug.Log("Ui manager: mainMenu: resume pressed");
        gameController.ResumeGame();
        mainMenu.style.display = DisplayStyle.None;
    }

    void ControlsButtonPressed()
    {

    }

    void SoundButtonPressed()
    {

    }
    void ExitButtonPressed()
    {

    }
}
