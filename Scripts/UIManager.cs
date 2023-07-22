using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bluePoints;
    [SerializeField] private TextMeshProUGUI redPoints;
    [SerializeField] private GameObject finish, _pause;
    [SerializeField] private TextMeshProUGUI winner;
    private int blue;
    private int red;

    void Start()
    {
        bluePoints.text = "0";
        redPoints.text = "0";
        finish.SetActive(false);
    }

    void Update()
    {
        bluePoints.text = blue.ToString();
        redPoints.text = red.ToString();

        if (red is 5)
        {
            RedWin();
        }

        if (blue is 5)
        {
            BlueWin();
        }

        if (red is 5 || blue is 5)
        {
            Invoke("Reload", 2f);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void RedPoint()
    {
        red++;
    }

    public void BluePoint()
    {
        blue++;
    }

    void BlueWin()
    {
        finish.SetActive(true);
        winner.text = "Blue player is the winner!";
    }
    void RedWin()
    {
        finish.SetActive(true);
        winner.text = "Red player is the winner!";
    }

    void Reload()
    {
        SceneManager.LoadScene("Game");
    }
    void Pause()
    {
        Time.timeScale = 0f;
        _pause.SetActive(true);
    }

    public void Resume()
    {
        _pause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

}
