using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetString(StaticStrings.SOUND_ON_OFF, "true") == "true")
        {
            AudioManagerScript.instance_Sounds.StopAll();
            AudioManagerScript.instance_Sounds.PlaySound(StaticStrings.ENDGAME_SOUND_ID);
        }


    }

    public void ResetGame()
    {
        if (AudioManagerScript.instance_Sounds.IsPlaying(StaticStrings.ENDGAME_SOUND_ID))
            AudioManagerScript.instance_Sounds.StopSound(StaticStrings.ENDGAME_SOUND_ID);
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
