using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for managing the pause menu.
/// </summary>
public class UIScript : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private GameObject _pauseMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(!_pauseMenu.activeInHierarchy) 
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) || (Input.GetKeyDown(KeyCode.Escape)))
        {
            Application.Quit();
        }
    }

    public void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        _playerController.DisablePlayerControls();
        _playerController.DisableDialogueInteractions();
        _pauseMenu.SetActive(true);
    }
    public void Resume()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
        //Checks if dialogue box is open so it can determine wether to enable player controls or not.
        if (!_dialogueManager.IsTextBoxOpen())
        {
            _playerController.EnablePlayerControls();
        }
        _playerController.EnableDialogueInteractions();
        _pauseMenu.SetActive(false);
    }

}
