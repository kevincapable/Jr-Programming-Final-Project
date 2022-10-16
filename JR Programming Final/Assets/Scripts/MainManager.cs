using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;


public class MainManager : MonoBehaviour
{
    public static MainManager instance { get; private set; } //Encapsulation
    public GameObject dropDown;
    public static int characterSelec;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartNew()
    {
        characterSelec = dropDown.GetComponent<TMP_Dropdown>().value;
        Debug.Log(characterSelec);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
