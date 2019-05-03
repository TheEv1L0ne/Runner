using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator playerAnimator;

    public Transform modelRoot;

    bool isPaused = true;


    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0) && !isPaused)
        {
            //startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPos = Input.mousePosition;
            startPos.z = -12.99f; // camera

            startPos = Camera.main.ScreenToWorldPoint(startPos);
        }

        if (Input.GetMouseButtonUp(0) && !isPaused)
        {


            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -12.99f;

            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Debug.Log("Start: " + startPos);
            Debug.Log("END: " + mousePos);

            if (startPos.x - mousePos.x < -2f)
            {
                Debug.Log("LEFT");
                MovePlayerLeft();
            }

            if (startPos.x - mousePos.x > 2f)
            {
                Debug.Log("RIGHT");
                MovePlayerRight();
            }

            if (startPos.y - mousePos.y > 2f)
            {
                Debug.Log("JUMP");
                playerAnimator.Play("JUMP00");
            }

        }

    }

    public void ResetGame()
    {
        //resets character position
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 3f);
        isPaused = true;
    }

    public void StartGame()
    {
        playerAnimator.Play("RUN00_F");
        isPaused = false;

        if (PlayerPrefs.GetString(StaticStrings.SOUND_ON_OFF, "true") == "true")
        {
            if (!AudioManagerScript.instance_Sounds.IsPlaying(StaticStrings.RUN_SOUND_ID))
                AudioManagerScript.instance_Sounds.PlaySound(StaticStrings.RUN_SOUND_ID);
        }

        MovePlayerForward();
    }

    public void PauseGame()
    {
        playerAnimator.Play("WAIT01");
        isPaused = true;
        StopAllCoroutines();
    }


    public void MovePlayerForward()
    {
        StartCoroutine(MovePlayerForwardCoroutine());
    }

    IEnumerator MovePlayerForwardCoroutine()
    {
        if (this.transform.position.z <= 441)
            this.transform.Translate(Vector3.forward * 0.2f);
        else
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 3f);

        yield return null;
        MovePlayerForward();
    }

    Vector3 startPos;

    void MovePlayerLeft()
    {
        if(modelRoot.transform.position.x == 0f)
            MoveLeft(-3f);
        if (modelRoot.transform.position.x == 3f)
            MoveLeft(0f);
    }

    void MoveLeft(float destination)
    {
        if(modelRoot.position.x > destination)
            StartCoroutine(MoveLeftCoroutine(destination));
        else
            modelRoot.position = new Vector3(destination, modelRoot.position.y, modelRoot.position.z);
    }

    IEnumerator MoveLeftCoroutine(float destination)
    {
        yield return null;
        modelRoot.position = new Vector3(modelRoot.position.x - (Time.deltaTime * 20f), modelRoot.position.y, modelRoot.position.z);
        MoveLeft(destination);
    }


    ///////////////////////////////////////////////////////////////////////////////////////


    void MovePlayerRight()
    {
        if (modelRoot.transform.position.x == 0f)
            MoveRight(3f);
        if (modelRoot.transform.position.x == -3f)
            MoveRight(0f);
    }

    void MoveRight(float destination)
    {
        if (modelRoot.position.x < destination)
            StartCoroutine(MoveRightCoroutine(destination));
        else
            modelRoot.position = new Vector3(destination, modelRoot.position.y, modelRoot.position.z);
    }

    IEnumerator MoveRightCoroutine(float destination)
    {
        yield return null;
        modelRoot.position = new Vector3(modelRoot.position.x + (Time.deltaTime * 20f), modelRoot.position.y, modelRoot.position.z);
        MoveRight(destination);
    }
}
