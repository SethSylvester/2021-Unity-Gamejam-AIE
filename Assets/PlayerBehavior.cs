using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    //The character controller
    private CharacterController _controller;

    //Movement Vectors
    private Vector3 _movement = Vector3.zero;
    public float speed = 5.0F;

    public int health = 5;

    public float iframesDefault = 1.0f;
    private float iframes;

    [SerializeField]
    Transform characterPosition;

    [SerializeField]
    Camera cameraOne;
    [SerializeField]
    Camera cameraTwo;

    [SerializeField]
    CharacterController playerOne;
    [SerializeField]
    CharacterController playerTwo;

    [SerializeField]
    GameObject playerOneObj;
    [SerializeField]
    GameObject playerTwoObj;

    bool isPlayerOne = true;

    [SerializeField]
    Animator animator;
    [SerializeField]
    Animator animator2;

    [SerializeField]
    Text healthUI;

    // Start is called before the first frame update
    void Start()
    {
        //Grab the character controller
        _controller = GetComponent<CharacterController>();

        //Turn on p1 camera
        cameraTwo.enabled = false;
        cameraOne.enabled = true;

        //enable p1
        playerOne.enabled = true;
        playerTwo.enabled = false;

        playerTwoObj.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //###PLAYER MOVEMENT###
        // is the controller on the ground?
        //if (IsGrounded())
        if (iframes >= 0)
        {
            iframes -= Time.deltaTime;
        }

        healthUI.text = health.ToString();

        if (Input.GetKeyDown(KeyCode.F))
        {
            isPlayerOne = !isPlayerOne;

            if (isPlayerOne)
            {
                //Turn on p1 camera
                cameraTwo.enabled = false;
                cameraOne.enabled = true;

                //enable p1
                playerOne.enabled = true;
                playerTwo.enabled = false;

                playerTwoObj.SetActive(false);
            }
            else
            {
                playerTwoObj.SetActive(true);
                playerTwoObj.transform.position = (playerOneObj.transform.position + new Vector3(0,0,-1));

                //enable cam 2
                cameraOne.enabled = false;
                cameraTwo.enabled = true;

                //enable p2
                playerTwo.enabled = true;
                playerOne.enabled = false;
            }
        }

         //Feed moveDirection with input.
         _movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (isPlayerOne)
        {
            _movement = transform.TransformDirection(_movement);
        }
        else
        {
            _movement = playerTwoObj.transform.TransformDirection(_movement);
        }
        //Multiply it by speed.
        _movement *= speed;


         //Finally, move the player
         _controller.Move(_movement * Time.deltaTime);

        playerOne.Move(_movement * Time.deltaTime);
        playerTwo.Move(_movement * Time.deltaTime);

    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 1.0f);
    }

    public void TakeDamage(int damage) {
        if (iframes <= 0)
        {
            health -= damage;
            iframes = iframesDefault;

            if (health <= 0)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                SceneManager.LoadScene(1);
            }
        }
    }
}
