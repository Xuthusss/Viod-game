using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance = null;


    public int targetKills = 10; // The target number of Zombies to kill to win the game
    private int zombiesKilled = 0; // The current number of Zombies killed

    public int playerHealth = 3;

    GameObject player;

    [SerializeField]
    private GameObject LoseScreen;
    [SerializeField]
    private GameObject WinScreen;
    [SerializeField]
    private GameObject InvincibleScreen;
    // power up variables
    public bool isInvincible = false;

    public AudioClip otherClip;


    // ...
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (isInvincible)
            InvincibleScreen.SetActive(true);
        else
            InvincibleScreen.SetActive(false);
    }
    // Call this method whenever a Zombie is killed
    public void ZombieKilled()
    {
        zombiesKilled++;

        Debug.Log("You killed a zombie!");
        // Check if the player has reached the target number of kills
        if (zombiesKilled >= targetKills)
        {
            // Add your win game logic here, such as showing a win game screen, stopping the game, etc.
        
            // You can use SceneManager.LoadScene() to restart the level (make sure to add "using UnityEngine.SceneManagement;" at the top of the script).

            WinScreen.SetActive(true);
            player.GetComponent<ThirdPersonController>().enabled = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //
            Debug.Log("YOU WIN!!!");

        }
    }
    public void PlayerHurt()
    {

        if(!isInvincible)
        {
            Debug.Log("PLAYER HIT!");
            playerHealth--;
        }

        if(playerHealth == 0)
        {
            Debug.Log("You died");
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = otherClip;
            audio.Play();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            LoseScreen.SetActive(true);
            GameObject head = GameObject.Find("head_28_cap_A");
            Destroy(head);
            player.GetComponent<ThirdPersonController>().enabled = false;
        }
    }

}