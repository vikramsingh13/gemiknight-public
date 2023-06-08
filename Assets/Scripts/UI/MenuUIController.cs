using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    public Button mainButtonResume;
    public Button mainButtonControls;
    public Button mainButtonSound;
    public Button mainButtonExit;
    public GameController gameController;
    public VisualElement mainMenu;
    public ControlSettings controlSettings;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameManager").GetComponent<GameController>();
        controlSettings = GameObject.FindWithTag("GameManager").GetComponent<ControlSettings>();
        mainMenu = GetComponent<UIDocument>().rootVisualElement;
        
        if (mainMenu != null && gameController != null)
        {
            mainMenu.style.display = DisplayStyle.None;
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
        if (gameController.IsPaused)
        {
            mainMenu.style.display = DisplayStyle.Flex;
        }

        if(!gameController.IsPaused)
        {
            mainMenu.style.display = DisplayStyle.None;
        }
    }

    //resume game
    void ResumeButtonPressed()
    {
        Debug.Log("Ui manager: mainMenu: resume pressed");
        gameController.IsPaused = false;
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
