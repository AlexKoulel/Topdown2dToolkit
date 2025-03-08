using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Methods from this class are called for turning on/off player control when needed.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _player, _eyes;
    [SerializeField] private DialogueManager _dialogueManager;

    private void Awake()
    {
        Cursor.visible = false;
        ItemManager itemManager = _player.GetComponent<ItemManager>();
    }
    public void DisablePlayerControls()
    {
        _player.GetComponent<PlayerMovement>().enabled = false;
        _player.transform.GetChild(0).GetComponent<Animator>().speed = 0;
        _eyes.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void EnablePlayerControls()
    {
        _player.GetComponent<PlayerMovement>().enabled = true;
        _player.transform.GetChild(0).GetComponent<Animator>().speed = 1;
        _eyes.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void DisableDialogueInteractions()
    {
        _dialogueManager.enabled = false;
    }
    public void EnableDialogueInteractions() 
    {
        _dialogueManager.enabled = true;
    }
}
