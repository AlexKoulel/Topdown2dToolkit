using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This is a class for managing interaction between the player and objects.
/// </summary>
public class InteractionManager : MonoBehaviour
{
    private BoxCollider2D _eyes;
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private ItemManager _itemManager;
    [SerializeField] private SceneTransition _levelManager;
    [SerializeField] private GameObject _exMark;
    private bool _onTrigger = false;
    private string _objectTag, _objectName;
    private GameObject _currentObject;

    void Start()
    {
        _objectTag = string.Empty;
        _objectName = string.Empty;
        _eyes = gameObject.GetComponent<BoxCollider2D>();    
    }
    void Update()
    {
        if(_onTrigger && _objectTag == "Interactable")
        {
            _exMark.SetActive(true);
            int type = ObjectNameCheck(_objectName);
            if (Input.GetButtonDown("Submit"))
            {
                switch (type)
                {
                case 0:  /// When the interacting with an NPC it shows up a dialogue text box that displays the text that is written in text component of the interacted object.
                    _dialogueManager.OpenTextBox(_currentObject);
                    break;
                case 1:  /// When interacting with an item it adds the item to the inventory and destroys it from the world.
                    _itemManager.AddItem(Int32.Parse(_currentObject.GetComponent<Text>().text));
                    Destroy(_currentObject);
                    break;
                case 2:  /// When interacting with a warp object it teleports the player to the scene that has the build index number that the text component of the interacted object has. 
                         /// It also disables player control until player gets teleported to the next scene.
                    _levelManager.LoadNextLevel(Int32.Parse(_currentObject.GetComponent<Text>().text));
                    GameObject.Find("Player").GetComponent<PlayerController>().DisablePlayerControls();
                    break;
                default:
                        Debug.Log("Wrong type.");
                    break;
                }
            }
        }

        else if(!_onTrigger)
        {
            _exMark.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _onTrigger = true;
        _objectTag = collision.tag;
        _objectName = collision.name;
        _currentObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _onTrigger = false;
        _objectTag = string.Empty;
        _objectName = string.Empty;
    }

    /// <summary>
    /// Checks name of object to determine the type of interaction.
    /// </summary>
    public int ObjectNameCheck(string objname)
    {
        int type = 0;
        string result = null;
        for(int i=0;i<3;i++)
        {
            char x = objname[i];
            result += x;
        }
        if(result == "NPC")
        {
            type = 0;
        }
        else if (result == "ITM")
        {
            type = 1;
        }
        else if (result == "WRP")
        {
            type = 2;
        }
        return type;
    }
}
