using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject ballInHand;
    [SerializeField] GameObject pfBall;
    [SerializeField] Rig rig;
    [SerializeField] GameObject ballReleasePosition;
    [SerializeField] Slider sliderPowerBar;
    [SerializeField] GameObject powerBar; 
    Animator animator;
    bool hasBall;
    bool throwingBall;
    bool throwButtonPressed;
    const float ANIMATION_THROW_DURATION = 0.3f;
    const float DELAY_PICKUP_BALL = 0.2f;
    float timeLeftDelayPickupBall = 0;
    float timeAnimationStarted;
    protected float shootingPower; 
    AudioSource soundThrowBall;
    AudioSource soundPickupBall;

    // Start is called before the first frame update
    void Start()
    {
        soundThrowBall = GameObject.Find("/Sound/ThrowBall").GetComponent<AudioSource>();
        soundPickupBall = GameObject.Find("/Sound/PickupBall").GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        animator.SetLayerWeight(1, 1);
        ballInHand.SetActive(false);
        RemovePowerBar();
        animator.SetLayerWeight(1, 1);
        animator.SetLayerWeight(3, 0);
        rig.weight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (throwingBall && (Time.time - timeAnimationStarted) > ANIMATION_THROW_DURATION)
        {
            throwingBall = false;
            animator.SetLayerWeight(1, 1);
            animator.SetLayerWeight(3, 0);
            ballInHand.SetActive(false);
            rig.weight = 0;
            ReleaseBall();
            shootingPower = 0;
        }

        if (timeLeftDelayPickupBall>0)
        {
            timeLeftDelayPickupBall -= Time.deltaTime;
        }

        if (hasBall)
        {
            if (throwButtonPressed)
            {
                {
                    shootingPower += 1.8f * Time.deltaTime;
                    SetPowerBar(shootingPower);
                    if (shootingPower > 1)
                    {
                        shootingPower = 1;
                    }
                }
            }
            else if (shootingPower > 0)
            {
                StartThrowingBall();
            }
        }
    }

    private void ReleaseBall()
    {
        soundThrowBall.Play();
        GameObject newBall = Instantiate(pfBall, /*ballInHand.transform.position*/ballReleasePosition.transform.position, Quaternion.identity);
        float angle = Camera.main.transform.localEulerAngles.x;     // 90 = looking down  270 = looking up
        if (angle < 180)
        {
            angle += 360;
        }
        angle = Mathf.Abs(430 - angle);        // approx. beteen 0 and 100
        
        Vector3 forceDirection = new Vector3(transform.forward.x, angle * 0.005f, transform.forward.z) * 200 * shootingPower;
        Debug.DrawLine(transform.position, transform.position + forceDirection, Color.green, 4, false);
        newBall.GetComponent<Rigidbody>().AddForce(forceDirection, ForceMode.Impulse);
        timeLeftDelayPickupBall = DELAY_PICKUP_BALL;
    }

    private void OnThrow(InputValue value)
    {
        throwButtonPressed = value.isPressed;
    }

    private void OnContinue()
    {
        if (Game.Instance.GameState.Equals(Game.GameState_.NewGame))
        {
            Game.Instance.SetGameState(Game.GameState_.Playing);
            return;
        }
        if (Game.Instance.GameState.Equals(Game.GameState_.GameOver) ||
            Game.Instance.GameState.Equals(Game.GameState_.GameWon))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Game.Instance.SetGameState(Game.GameState_.NewGame);
            return;
        }
    }

    private void SetPowerBar(float value)
    {
        powerBar.SetActive(true);
        sliderPowerBar.value = value;
    }

    private void RemovePowerBar()
    {
        powerBar.SetActive(false);
    }

    private void StartThrowingBall()
    {
        hasBall = false;
        RemovePowerBar();
        throwingBall = true;
        timeAnimationStarted = Time.time;
        animator.Play("Throw", 3, 0);
        animator.SetLayerWeight(2, 0);
        animator.SetLayerWeight(3, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBall && timeLeftDelayPickupBall<=0 && other.gameObject.GetComponent<Ball>() != null)
        {
            soundPickupBall.Play();
            hasBall = true;
            Destroy(other.gameObject);
            ballInHand.SetActive(true);
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(2, 1);
            rig.weight = 1;
        }
    }
}
