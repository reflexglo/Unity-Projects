//Chris Riordan
//2-1-2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Controls all player movement, stats, and behaviours
public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 6f;
    public float gravity = -10f;
    public Transform planet;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public float jumpHeight = 20f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    public Camera cam;
    float xRotation = 0f;
    float yRotation = 0f;
    public float mouseSensitivity = 800f;
    bool hasKey = false;
    bool inRange = false;
    public GameObject text;
    bool hasEscaped = false;
    public GameObject escapeScreen;
    public MouseLook mouse;
    public int startTime = 500;
    int time;
    float  secCounter = 0;
    public Text timer;
    int minutes = 0;
    int seconds = 0;
    public GameObject deathScreen;
    public GameObject noTimeScreen;
    public float maxHealth = 100;
    float health;
    public int regenDelay = 100;
    int regenTimer;
    public HealthControl healthBar;
    //Sets all fields to their initial values
    void Start()
    {
        escapeScreen.gameObject.SetActive(false);
        deathScreen.gameObject.SetActive(false);
        noTimeScreen.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        time = startTime;
        regenTimer = regenDelay;
        health = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }
    //Updates player movement and attributes
    void Update()
    {
        if (!hasEscaped) {
            //Maintains upright rotation with respect to the planet
            Vector3 gravityDir = (transform.position - planet.position).normalized;
            Vector3 playerUp = transform.up;
            Quaternion playerRotation = Quaternion.FromToRotation(playerUp, gravityDir) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, 50 * Time.deltaTime);

            //Controls player movement inputs
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
            transform.GetComponent<Rigidbody>().AddForce(gravityDir * gravity);
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                transform.GetComponent<Rigidbody>().AddForce(gravityDir * 100 * jumpHeight);
            }

            //Controls health stats and no-health scenario
            healthBar.setHealth(health);
            if (regenTimer <= 0)
            {
                if (health<maxHealth)
                {
                    health += maxHealth / 100;
                }
                else
                {
                    regenTimer = regenDelay;
                }
            }
            else
            {
                if (health<maxHealth)
                {
                    regenTimer--;
                }
                else
                {
                    regenTimer = regenDelay;
                }
            }
            if (health <= 0)
            {
                hasEscaped = true;
                mouse.setEnd(true);
                text.gameObject.SetActive(false);
                deathScreen.gameObject.SetActive(true);
            }

            //Controls ship interactions and planet-escaped scenario
            if (hasKey && inRange)
            {
                text.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    escapeScreen.gameObject.SetActive(true);
                    text.gameObject.SetActive(false);
                    hasEscaped = true;
                    mouse.setEnd(true);
                }
            }
            else
            {
                text.gameObject.SetActive(false);
            }

            //Updates timer UI and no-time scenario
            if (secCounter < 1)
            {
                secCounter += Time.deltaTime;
            }
            else
            {
                secCounter = 0;
                time--;
            }
            minutes = time / 60;
            seconds = time - minutes * 60;
            if (seconds>=10) { 
                timer.text = "Time Left: " + minutes + ":" + seconds;
            }
            else
            {
                timer.text = "Time Left: " + minutes + ":0" + seconds;
            }
            if (time<=0)
            {
                hasEscaped = true;
                mouse.setEnd(true);
                text.gameObject.SetActive(false);
                noTimeScreen.gameObject.SetActive(true);
            }
        }
    }
    //Detects if player is in range of spaceship
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Spaceship")
        {
            inRange = true;
        }
    }
    //Detects if player has become out of range of spaceship
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Spaceship")
        {
            inRange = false;
        }
    }
    //Set method for hasKey
    public void setKey(bool key)
    {
        hasKey = key;
    }
    //Determines if timer is less than the initial time
    public bool halfTime()
    {
        if (time<startTime/2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Applies damage to health and resets regenTimer
    public void setHealth(float damage)
    {
        health -= damage;
        regenTimer = regenDelay;
    }
}
