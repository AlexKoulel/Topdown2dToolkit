using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for transitions between scenes.
/// </summary>
public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Animator _transition;


    public void LoadNextLevel(int index)
    {
        StartCoroutine(LoadScene(index));
    }

    IEnumerator LoadScene(int index)
    {
        _transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(index);
    }
}
