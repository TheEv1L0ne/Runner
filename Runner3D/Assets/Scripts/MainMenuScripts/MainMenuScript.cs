using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuScript : MonoBehaviour
{

    public GameObject optionDialog;

    public Toggle soundOnOff;

    // Start is called before the first frame update
    void Start()
    {
        //Starts sound when game is loaded if sound option is enabled
        if (PlayerPrefs.GetString(StaticStrings.SOUND_ON_OFF, "true") == "true")
        {
            AudioManagerScript.instance_Sounds.PlaySound(StaticStrings.MAIN_MENU_SOUND_ID);
        }

        soundOnOff.onValueChanged.AddListener(delegate
        {
            ToggleValueChanged(soundOnOff);
        });
    }

    void ToggleValueChanged(Toggle change)
    {
        if(soundOnOff.isOn)
        {
            PlayerPrefs.SetString(StaticStrings.SOUND_ON_OFF, "true");
            AudioManagerScript.instance_Sounds.PlaySound(StaticStrings.MAIN_MENU_SOUND_ID);
        }
        else
        {
            PlayerPrefs.SetString(StaticStrings.SOUND_ON_OFF, "false");
            AudioManagerScript.instance_Sounds.StopAll();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {

    }

    public void OpenOptions()
    {
        optionDialog.SetActive(true);

        if (PlayerPrefs.GetString(StaticStrings.SOUND_ON_OFF, "true") == "true")
        {
            soundOnOff.isOn = true;
        }
        else
        {
            soundOnOff.isOn = false;
        }
    }

    public void CloseOption()
    {
        optionDialog.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
