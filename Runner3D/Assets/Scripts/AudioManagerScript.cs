using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{

    public static AudioManagerScript instance_Sounds;

    private void Awake()
    {
        if (instance_Sounds == null)
        {
            instance_Sounds = this;
        }
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    public AudioSource[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int id)
    {
        sounds[id].Play();
    }

    public void StopSound(int id)
    {
        sounds[id].Stop();
    }

    public void StopAll()
    {
        for(int i=0;i<sounds.Length;i++)
        {
            sounds[i].Stop();
        }
    }
}
