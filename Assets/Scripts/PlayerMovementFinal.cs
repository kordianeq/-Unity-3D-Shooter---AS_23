using UnityEngine;

public class PlayerMovementFinal : MonoBehaviour
{
    [SerializeField] public float speed = 5.0f;
    [SerializeField] public float jumpForce = 5.0f;
    [SerializeField] public float sprintSpeed = 10.0f;

    public GameObject AnimatorRef; //refka do animatora
    Animator animator;

    float horizontalInput, verticalInput;
    Rigidbody rigidbody;
    bool isGrounded, isRunning;


    void Start()
    {
        ; animator = AnimatorRef.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        isGrounded = true;
        isRunning = false;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Alpha1)) transform.position = new Vector3(10, 2, 10);
        if (Input.GetKeyDown(KeyCode.Alpha2)) transform.position = new Vector3(0, 2, -10);

        if (isRunning)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * sprintSpeed * verticalInput);
            transform.Translate(Vector3.right * Time.deltaTime * sprintSpeed * horizontalInput);
            animator.SetBool("isRunning", true); //ustawanie isRuning w animatorze

        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            animator.SetBool("isRunning", false); //ustawanie isRuning w animatorze
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }


        void OnCollisionStay(Collision collision)
        {
            isGrounded = true;
        }
    }
}



