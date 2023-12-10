using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    protected Vector3 position;

    [SerializeField] protected float jumpForce;

    [SerializeField] protected Vector2 limitX;
    bool isLimitLeft;
    bool isLimitRight;

    [SerializeField] protected GameObject input;
    private void Update()
    {
        LimitMove();
        if (PlayerController.Instance.health.isDie)
        {
            speed = 0;
            jumpForce = 0;
            input.SetActive(false);

        }
        Moving(InputManager.Instance.Horizontal);
        Jumping();
    }

    private void Moving(float direction)
    {
        AnimMoving(direction);
        if (isLimitLeft && direction<0) return;
        if (isLimitRight && direction > 0) return;
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

    private void LimitMove()
    {
        if(transform.parent.position.x<=limitX.x )
        {
            isLimitLeft = true;
            return;
        }
        if (transform.parent.position.x >= limitX.y)
        {
            isLimitRight = true;
            return;
        }
        isLimitLeft = false;
        isLimitRight = false;

    }
}

