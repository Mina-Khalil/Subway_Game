using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public static float Speed;
    public float MaxSpeed = 12;
    private int desiredLane = 1;               //0:left, 1:middle, 2:right
    public float laneDistance = 2.5f;          //The distance between tow lanes
    public float jumpHeight = 10;
    public float Gravity = -15;
    public Animator animator;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Speed = 8;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.IsGameStart)
        { return; }
        animator.SetBool("isGameStarted", true);
        direction.z = Speed;

        ////increse the speed in player
        if (Speed < MaxSpeed)
        {
            Speed += 0.1f * Time.deltaTime;
        }

        // Jupm up the player  
        direction.y += Gravity * Time.deltaTime;
        if (controller.isGrounded)
        {
            animator.SetBool("isJump", Input.GetKeyDown(KeyCode.UpArrow));
            if (Input.GetKeyDown(KeyCode.UpArrow) || SwipeManager.swipeUp)
            {
                StartCoroutine(JUMP());
            }
        }

        // Slide the Player
        if (Input.GetKeyDown(KeyCode.DownArrow) || SwipeManager.swipeDown)
        {
            StartCoroutine(Slide());
        }

        // left and right player
        if (Input.GetKeyDown(KeyCode.RightArrow) || SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        //Calculate where we should be in the future  
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }
    }

    // update for any action
    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    // soeed up the player
    public static IEnumerator PowerUp()
    {
        Speed += 4;
        yield return new WaitForSeconds(3f);
        Speed -= 4;
    }
    // Jump Player
    private IEnumerator JUMP()
    {
        animator.SetBool("isJump", true);
        direction.y = jumpHeight;
        yield return new WaitForSeconds(5f);
        animator.SetBool("isJump", false);
    }
    // Slide the player
    private IEnumerator Slide()
    {
        animator.SetBool("isSlide", true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;
        yield return new WaitForSeconds(1f);
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        animator.SetBool("isSlide", false);
    }

    // the player hit the obstacle
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            if (AudioManger.ismute == false)
            {
                FindObjectOfType<AudioManger>().PlaySound("Died");
            }
            StartCoroutine("Die");
        }
    }

    // die the player
    private IEnumerator Die()
    {
        animator.SetBool("isDie", true);
        yield return new WaitForSeconds(1f );
        PlayerManager.gameOver = true;
    }
  



}
