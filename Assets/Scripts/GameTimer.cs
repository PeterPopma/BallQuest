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

    private void Start()
    {
        InitTimer();
    }

    public void InitTimer()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed = Time.time - startTime;
        if (timePassed >= GAME_DURATION)
        {
        }
        textGameTime.text = (GAME_DURATION - timePassed).ToString("0");
    }
}
