using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private const float GAME_DURATION = 300;        // game duration in seconds
    [SerializeField] private TextMeshProUGUI textGameTime;
    private float startTime;
    private float timePassed;
    private bool isEnabled;

    public bool IsEnabled { get => isEnabled; set => isEnabled = value; }

    public void InitTimer()
    {
        startTime = Time.time;
        isEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            timePassed = Time.time - startTime;
            if (timePassed >= GAME_DURATION)
            {
                Game.Instance.SetGameState(Game.GameState_.GameOver);
            }
            textGameTime.text = (GAME_DURATION - timePassed).ToString("0");
        }
    }

    public string TimeLeft()
    {
        return (Time.time - startTime).ToString("0");
    }
}
