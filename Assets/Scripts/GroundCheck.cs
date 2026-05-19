using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private static bool isGrounded;
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(

            groundCheck.position,
            groundCheckRadius,
            groundLayer
            );
    }

    public static bool GroundChecked() {

        return isGrounded;
    }
}
