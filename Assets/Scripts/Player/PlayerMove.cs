using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    protected Vector3 position;

    [SerializeField] float jumpForce;


    private void Update()
    {
        Moving(InputManager.Instance.Horizontal);
        Jumping();
    }

    private void Moving(float direction)
    {
        AnimMoving(direction);
        position = transform.parent.position;
        position.x += direction * speed * Time.deltaTime;
        transform.parent.position = position;
    }
    private void Jumping()
    {
        if (PlayerController.Instance.countJump >= 2) return;
        if (!InputManager.Instance.Jump) return;
        PlayerController.Instance.isJumping = true;
        PlayerController.Instance.rb.velocity = new Vector2(PlayerController.Instance.rb.velocity.x, jumpForce);
        PlayerController.Instance.countJump++;
    }
    private void AnimMoving(float direction)
    {
        if (direction == 0)
        {
            PlayerController.Instance.animator.SetFloat("RunState", 0f);
            return;
        }
        if (direction < 0) { transform.parent.localScale = new Vector3(1, 1, 1); }
        else if (direction > 0) { transform.parent.localScale = new Vector3(-1, 1, 1); }
        PlayerController.Instance.animator.SetFloat("RunState", 0.5f);
    }
}

