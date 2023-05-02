using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    static public SceneManager Instance { get; private set; }

    public int clearSceneCnt;

    private void Awake()
    {
        Instance = this; 

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayerPrefs.GetInt("Save", clearSceneCnt);
    }

    public void LoadScene()
    {
        clearSceneCnt++;
        UnityEngine.SceneManagement.SceneManager.LoadScene(clearSceneCnt);
        PlayerPrefs.SetInt("Save", clearSceneCnt);
    }
}
