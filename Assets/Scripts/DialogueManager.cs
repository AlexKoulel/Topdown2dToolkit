using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This is a class responsible for the NPC dialogue.
/// </summary>
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject _textBox,_player;
    private PlayerController _playerController;
    private GameObject _doneArrow;
    private TextMeshProUGUI _speech;
    private float _textSpeed = 0.05f;
    private bool textBoxIsOpen = false,_dialogueIsDone = false;

    private void Start()
    {
        _speech = _textBox.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        _doneArrow = _textBox.transform.GetChild(1).gameObject;
        _playerController = _player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit") && _dialogueIsDone == true)
        {
            _doneArrow.SetActive(false);
            _textBox.SetActive(false);
            _playerController.EnablePlayerControls();
            textBoxIsOpen = false;
            _dialogueIsDone = false;
        }
    }

    /// <summary>
    /// This method opens up the TextBoxPanel and calls on they 
    /// TypeText coroutine for the dialogue content while also 
    /// disabling player controls but the player does have the ability to pause.
    /// </summary>
    public void OpenTextBox(GameObject interactedObject) 
    {
        _playerController.DisablePlayerControls();
        textBoxIsOpen = true;
        _speech.text = string.Empty;
        _textBox.SetActive(true);
        StartCoroutine(TypeText(interactedObject.GetComponent<Text>().text));
    }

    /// <summary>
    /// This coroutine simulates typing by displaying text one character at a time, 
    /// creating a more natural flow for the dialogue sequence.
    /// </summary>
    IEnumerator TypeText(string lines)
    {
        foreach(char c in lines.ToCharArray())
        {
            _speech.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
        _doneArrow.SetActive(true);
        _dialogueIsDone = true;
    }

    public bool IsTextBoxOpen()
    {
        return textBoxIsOpen;
    }
}
