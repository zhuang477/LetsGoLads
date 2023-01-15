using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AimDirection {south, north, east, west}

public class Player_2D_Movement : MonoBehaviour
{
    public Player_2D_Status player2dstatus;
    public float moveSpeed = 3f;
    private const float moveSpeedRecorder = 3f;
    public Rigidbody2D RBody;
    public Camera cam;
    [HideInInspector] public float angle;
    [HideInInspector] public AimDirection aimdirection;

    private float time = 0f;
    public Transform locationRecorder;

    Vector2 movement;
    Vector2 mousePos;

    void Awake()
    {
        player2dstatus = GameObject.FindObjectOfType<Player_2D_Status>();
    }

    void Update()
    {
        AimComponentWrapper();
        PlayerAction();
        //Debug.Log(locationRecorder.position);
        //Debug.Log(player2dstatus.inAction);
    }

    void FixedUpdate()
    {
        RBody.MovePosition(RBody.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - RBody.position;
        float angle_Fix = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        RBody.rotation = angle_Fix;

    }

    void AimComponentWrapper()
    {
        AngleUpdate();
        AimDirectionUpdate();
    }


    void AngleUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - RBody.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    }

    void AimDirectionUpdate()
    {
        if (angle >= -135 && angle <= -45)
        {
            //Debug.Log("East");
            aimdirection = AimDirection.east;
        }
        if (angle >= -220 && angle < -135)
        {
            //Debug.Log("South");
            aimdirection = AimDirection.south;
        }
        if ((angle > -45 && angle <= 45) || (angle > 0 && angle < 45))
        {
            //Debug.Log("North");
            aimdirection = AimDirection.north;
        }
        if ((angle >= -359.99999f && angle < -220) || (angle >= 45 && angle <= 89.99999f))
        {
            //Debug.Log("West");
            aimdirection = AimDirection.west;
        }
    }

    void PlayerAction()
    {
        Charging();
        Dodge();
    }

    void Charging()
    {
        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= 3;
        }

        if (Input.GetKey(KeyCode.LeftShift) && player2dstatus.basic_stamina >0 && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            
            if (time >= 0.1f)
            {
                player2dstatus.basic_stamina -= 2;
                time = 0f;
            }
            player2dstatus.inAction = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed /= 3;
            StartCoroutine("ActionOffSymbol");
        }

        if(player2dstatus.basic_stamina == 0)
        {
            moveSpeed = moveSpeedRecorder;
            
        }

        if(moveSpeed < 3f)
        {
            moveSpeed = moveSpeedRecorder;
        }
    }

    private bool DodgeAnimation = false;

    void Dodge()
    {

       if (Input.GetKeyDown(KeyCode.Space) &&(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && DodgeAnimation ==false)
       {
            if (player2dstatus.basic_stamina > 15 && Input.GetKey(KeyCode.LeftShift))
            {
                player2dstatus.basic_stamina -= 15;
                DodgeAnimation = true;
                StartCoroutine("DodgeRunningCoroutine");
            }

            if (player2dstatus.basic_stamina > 10)
            {
                player2dstatus.basic_stamina -= 10;
                DodgeAnimation = true;
                StartCoroutine("DodgeCoroutine");
            }
       }

    }

    IEnumerator ActionOffSymbol()
    {
        yield return new WaitForSeconds(2f);
        player2dstatus.inAction = false;
    }

    IEnumerator DodgeCoroutine()
    {
        moveSpeed *=3;
        //Disable ColliderBox
        player2dstatus.inAction =true;
        yield return new WaitForSeconds(0.5f); //Depends on dodge animation frame.
        DodgeAnimation =false;
        moveSpeed /=3;
        StartCoroutine("ActionOffSymbol");
        //Enable ColliderBox
    }

    IEnumerator DodgeRunningCoroutine()
    {
        moveSpeed *= 1.1f;
        //Disable ColliderBox
        player2dstatus.inAction = true;
        yield return new WaitForSeconds(0.5f); //Depends on dodge animation frame.
        DodgeAnimation = false;
        moveSpeed /= 1.1f;
        StartCoroutine("ActionOffSymbol");
        //Enable ColliderBox
    }
}
