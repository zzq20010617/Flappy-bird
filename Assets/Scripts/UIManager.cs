using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject restartScreenObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    #region win/lose
    public void LoseGame()
    {
        Debug.Log("lose");
        restartScreenObject.SetActive(true);
        Time.timeScale = 0;
    }


    private void OnEnable()
    {
        Bird.OnBirdCollid += LoseGame;
    }
    private void OnDisable()
    {
        Bird.OnBirdCollid -= LoseGame;
    }

    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    #endregion

}
