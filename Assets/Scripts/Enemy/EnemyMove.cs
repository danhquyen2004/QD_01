using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] protected Health enemy;
    [SerializeField] protected ESwordAtk enemyAtk;
    [SerializeField] protected GameObject player;
    [SerializeField] protected float speed;
    [SerializeField] protected float randSpeed;

    [SerializeField] protected float detectRange;
    [SerializeField] protected LayerMask playerLayers;
    [SerializeField] protected Animator animator;

    private void Start()
    {
        enemy = transform.parent.GetComponent<Health>();
        StartCoroutine(RandomSpeed(2.5f));
    }
    private void Update()
    {
        DetectPlayer();
    }

    protected void Move()
    {
        if (enemy.isDie || enemy.isStun || enemyAtk.isAtking) return;
        if (player.transform.position.x > transform.parent.position.x)
        {
            transform.parent.localScale = new Vector3(-1, 1, 1);
            transform.parent.Translate(randSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.parent.localScale = new Vector3(1, 1, 1);
            transform.parent.Translate(randSpeed * Time.deltaTime * -1, 0, 0);
        }
        animator.SetFloat("RunState", 0.5f);
    }
    protected void DetectPlayer()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(transform.parent.position, detectRange, playerLayers);
        if(hitPlayer.Length == 0) 
        {
            animator.SetFloat("RunState", 0f);
        }
        foreach(Collider2D player in  hitPlayer)
        {
            Move();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.parent.position, detectRange);
    }

    IEnumerator RandomSpeed(float time)
    {
        while (true)
        {
            randSpeed = Random.Range(speed - 0.5f, speed + 0.5f);
            yield return new WaitForSeconds(time);
        }
        
    }

}
