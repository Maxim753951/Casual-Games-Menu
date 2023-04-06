using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public int level = 1;
    public GameObject[] closedLevel;

    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("level", level);
        for (int i = 0; i < level; i++)
        {
            closedLevel[i].SetActive(false);
        }
    }

    public void PlayLvl1()
    {
        //Application.LoadLevel("Lvl1"); //устарело
        SceneManager.LoadScene("Lvl1");
    }
    public void PlayLvl2()
    {
        SceneManager.LoadScene("Lvl2");
    }
    public void PlayLvl3()
    {
        SceneManager.LoadScene("Lvl3");
    }
    public void PlayLvl4()
    {
        SceneManager.LoadScene("Lvl4");
    }
    public void PlayLvl5()
    {
        SceneManager.LoadScene("Lvl5");
    }
    public void PlayLvl6()
    {
        SceneManager.LoadScene("Lvl6");
    }
    public void PlayLvl7()
    {
        SceneManager.LoadScene("Lvl7");
    }
    public void PlayLvl8()
    {
        SceneManager.LoadScene("Lvl8");
    }
    public void PlayLvl9()
    {
        SceneManager.LoadScene("Lvl9");
    }
    public void PlayLvl10()
    {
        SceneManager.LoadScene("Lvl10");
    }
}
