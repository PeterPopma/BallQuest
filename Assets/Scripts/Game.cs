using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instance;

    AudioSource soundEndLevel;
    AudioSource soundOpenGate;
    [SerializeField] private GameObject player;
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private GameObject messagePanel;
    [SerializeField] TextMeshProUGUI textMessage;
    [SerializeField] GameObject[] gates;
    GameState_ gameState;
    Vector3 playerStartPosition = new Vector3(0, 0.209000006f, -2.98099995f);

    public GameState_ GameState { get => gameState; set => gameState = value; }

    public enum GameState_
    {
        NewGame,
        Playing,
        GameWon,
        GameOver
    }

    public void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        soundEndLevel = GameObject.Find("/Sound/EndLevel").GetComponent<AudioSource>();
        soundOpenGate = GameObject.Find("/Sound/OpenGate").GetComponent<AudioSource>();
        SetGameState(gameState = GameState_.NewGame);
    }

    public void SetGameState(GameState_ gameState)
    {
        switch (gameState)
        {
            case GameState_.NewGame:
                player.GetComponent<ThirdPersonController>().MovementDisabled = true;
                textMessage.text = "Press <enter> to start";
                messagePanel.SetActive(true);
                player.transform.position = playerStartPosition;
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
                foreach (GameObject gate in gates)
                {
                    gate.SetActive(true);
                }                
                break;
            case GameState_.GameWon:
                player.GetComponent<ThirdPersonController>().MovementDisabled = true;
                gameTimer.IsEnabled = false;
                textMessage.text = "Well done! You reached the castle. You had " + gameTimer.TimeLeft() + " seconds left. Press <enter> to continue.";
                messagePanel.SetActive(true);
                soundEndLevel.Play();
                break;
            case GameState_.GameOver:
                player.GetComponent<ThirdPersonController>().MovementDisabled = true;
                gameTimer.IsEnabled = false;
                textMessage.text = "Oh no! You ran out of time. Press <enter> to continue.";
                messagePanel.SetActive(true);
                soundEndLevel.Play();
                break;
            case GameState_.Playing:
                player.GetComponent<ThirdPersonController>().MovementDisabled = false;
                gameState = GameState_.Playing;
                gameTimer.InitTimer();
                messagePanel.SetActive(false);
                break;
        }
        this.gameState = gameState;
    }

    public void PlayOpenGateSound()
    {
        soundOpenGate.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
