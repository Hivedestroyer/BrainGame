using UnityEngine;
using PlatformerRails;

[RequireComponent(typeof(MoverOnRails))]
public class PlayerMove : MonoBehaviour
{
    public bool checkTrap;
    public Rigidbody playerRigidbody;
    [SerializeField]
    float Accelaration = 20f;
    [SerializeField]
    float Drag = 5f;
    [SerializeField]
    float JumpSpeed = 5f;
    [SerializeField]
    float Gravity = 15f;

    [SerializeField, Space]
    float GroundDistance = 0.5f;
    [SerializeField]
    float GroundCheckLength = 0.05f;

    public bool hasJumped;

    MoverOnRails Controller;
    void Start()
    {
        Controller = GetComponent<MoverOnRails>();

        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            var distance = CheckGroundDistance();
            if(distance < GroundDistance + 0.1f)
            {
                hasJumped = true;
            }
            else
            {
                
            }
        }
            
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 9)
        {
            Debug.Log("TEST1");
            checkTrap = true;

        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            checkTrap = false;
        }
    }

    void FixedUpdate()
    {

        //To make X value 0 means locate the character just above the rail
        Controller.Velocity.x = -Controller.Position.x * 5f;
        //Changing Z value in local position means moving toward rail direction
        Controller.Velocity.z += Input.GetAxisRaw("Horizontal") * Accelaration * Time.fixedDeltaTime;
        Controller.Velocity.z -= Controller.Velocity.z * Drag * Time.fixedDeltaTime;
        //Y+ axis = Upwoard (depends on rail rotation)
        var distance = CheckGroundDistance();
        if (distance != null)
        {
            Controller.Velocity.y = (GroundDistance - distance.Value) / Time.fixedDeltaTime; //ths results for smooth move on slopes
            if (hasJumped == true)

            {
                hasJumped = false;
                Controller.Velocity.y = JumpSpeed;
            }
            if (checkTrap)
            {
                Controller.Velocity.y += JumpSpeed;
                if (Controller.Velocity.x > 0)
                {
                    Controller.Velocity.z += -12f;
                }
                else
                {
                    Controller.Velocity.z += 12f;
                }
            }
        }
        else
            Controller.Velocity.y -= Gravity * Time.fixedDeltaTime;
    }

    float? CheckGroundDistance()
    {
        RaycastHit info;
        var hit = Physics.Raycast(transform.position, -transform.up, out info, GroundDistance + GroundCheckLength);
        if (hit)
            return info.distance;
        else
            return null;
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, Vector3.down * (GroundDistance + GroundCheckLength));
        Gizmos.DrawWireCube(Vector3.down * GroundDistance, Vector3.right / 2 + Vector3.forward / 2);
        Gizmos.matrix = Matrix4x4.identity;
    }
#endif
}
