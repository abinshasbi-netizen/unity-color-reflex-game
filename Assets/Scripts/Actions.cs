using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Actions : MonoBehaviour
{

    private Rigidbody2D rb;
    private Camera cam;
    [SerializeField] private float jumpforce;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    private bool isGrounded;
    private Animator animator;

    private bool jump;


    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
    }

    void Start()
    {
        cam=Camera.main;
    }

    
    void Update()
    {
        isGrounded = GroundCheck.GroundChecked();
            
    }

    public void OnJump() {

        jump = true;
        animator.SetTrigger("Jump");
        AudioManagement.Instance.PlayJump();
        

    }
    private void FixedUpdate()
    {
        Jump();
    }
    void Jump() {

        if (isGrounded && jump ==true)
        {

            rb.AddForce(Vector3.up * jumpforce, ForceMode2D.Impulse);

        }
        jump = false;
    }
}
