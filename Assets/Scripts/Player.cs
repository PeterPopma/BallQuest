using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject ballInHand;
    [SerializeField] GameObject pfBall;
    [SerializeField] Rig rig;
    [SerializeField] GameObject ballReleasePosition;
    [SerializeField] Slider sliderPowerBar;
    [SerializeField] GameObject powerBar; Animator animator;
    bool hasBall;
    bool throwingBall;
    bool throwButtonPressed;
    const float ANIMATION_THROW_DURATION = 0.3f;
    const float DELAY_PICKUP_BALL = 0.2f;
    float timeLeftDelayPickupBall = 0;
    float timeAnimationStarted;
    protected float shootingPower;

    // Start is called before the first frame update
    void Start()
    {
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
        Vector3 forceDirection = new Vector3(transform.forward.x * 20, 3f, transform.forward.z * 20);
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
        GameObject newBall = Instantiate(pfBall, /*ballInHand.transform.position*/ballReleasePosition.transform.position, Quaternion.identity);
        Vector3 forceDirection = new Vector3(transform.forward.x * 240, 40f, transform.forward.z * 240) * shootingPower;
        Debug.DrawLine(transform.position, transform.position + forceDirection, Color.green, 4, false);
        newBall.GetComponent<Rigidbody>().AddForce(forceDirection, ForceMode.Impulse);
        timeLeftDelayPickupBall = DELAY_PICKUP_BALL;
    }

    private void OnThrow(InputValue value)
    {
        throwButtonPressed = value.isPressed;
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
            hasBall = true;
            Destroy(other.gameObject);
            ballInHand.SetActive(true);
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(2, 1);
            rig.weight = 1;
        }
    }
}
