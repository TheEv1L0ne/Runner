using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator playerAnimator;

    public Transform modelRoot;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator.Play("RUN00_F");
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.Translate(Vector3.forward * 0.2f);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //playerAnimator.Play("JUMP00B");
            MovePlayerLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //playerAnimator.Play("JUMP00B");
            MovePlayerRight();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.Play("JUMP00");
        }

        if(Input.GetMouseButtonDown(0))
        {
            //startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPos = Input.mousePosition;
            startPos.z = -12.99f; // camera

            startPos = Camera.main.ScreenToWorldPoint(startPos);
        }

        if (Input.GetMouseButtonUp(0))
        {


            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -12.99f;

            mousePos = Camera.main.ScreenToWorldPoint(mousePos);


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
