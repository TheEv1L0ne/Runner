using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayScript : MonoBehaviour
{

    public PlayerController playerController;
    public GameObject pauseMenu;

    public GameObject one;
    public GameObject two;
    public GameObject three;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    IEnumerator StarGameCoroutine()
    {
        yield return new WaitForSeconds(0.7f);
        three.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        three.SetActive(false);
        two.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        two.SetActive(false);
        one.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        one.SetActive(false);

        if (PlayerPrefs.GetString(StaticStrings.SOUND_ON_OFF, "true") == "true")
        {
            AudioManagerScript.instance_Sounds.StopSound(StaticStrings.MAIN_MENU_SOUND_ID);
            if (!AudioManagerScript.instance_Sounds.IsPlaying(StaticStrings.GAMEPLAY_SOUND_ID))
                AudioManagerScript.instance_Sounds.PlaySound(StaticStrings.GAMEPLAY_SOUND_ID);
        }
        playerController.StartGame();

    }

    public void ResetGame()
    {
        playerController.ResetGame();
        StartCoroutine("StarGameCoroutine");
        pauseMenu.SetActive(false);
    }


    void StartGame()
    {
        StartCoroutine("StarGameCoroutine");
    }

    public void OpenPauseMenu()
    {

        if (AudioManagerScript.instance_Sounds.IsPlaying(StaticStrings.RUN_SOUND_ID))
            AudioManagerScript.instance_Sounds.StopSound(StaticStrings.RUN_SOUND_ID);

        pauseMenu.SetActive(true);

        three.SetActive(false);
        two.SetActive(false);
        one.SetActive(false);

        StopCoroutine("StarGameCoroutine");
        playerController.PauseGame();
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        StartCoroutine("StarGameCoroutine");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
