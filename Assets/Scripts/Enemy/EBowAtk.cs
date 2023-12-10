using UnityEngine;

public class EBowAtk : MonoBehaviour
{
    [SerializeField] protected float atkRate = 2;
    [SerializeField] protected float countAtkTime = 0;

    [SerializeField] protected Animator animator;
    [SerializeField] protected GameObject arrow;

    [SerializeField] protected GameObject target;
    protected Health enemy;

    [SerializeField] protected float detectRange;
    [SerializeField] protected LayerMask playerLayers;
    private void Start()
    {
        enemy = transform.parent.GetComponent<Health>();
    }
    private void Update()
    {
        if (enemy.isStun || enemy.isDie) return;
        DetectPlayer();


    }
    private void Attacking()
    {
        countAtkTime += Time.deltaTime;
        if (countAtkTime < atkRate) return;
        animator.SetFloat("RunState", 0f);
        animator.SetTrigger("Attack");
        animator.SetFloat("NormalState", 0.5f);

        GameObject arrow = Instantiate(this.arrow, transform.position, Quaternion.identity);

        Vector3 direction = (target.transform.position - transform.position).normalized;
        Bullet arrowMovement = arrow.GetComponent<Bullet>();
        if (arrowMovement != null)
        {
            arrowMovement.SetTarget(direction);
        }
        arrow.SetActive(true);
        countAtkTime = 0;
    }

    protected void DetectPlayer()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(transform.parent.position, detectRange, playerLayers);
        if (hitPlayer.Length == 0)
        {
            animator.SetFloat("RunState", 0f);
        }
        foreach (Collider2D player in hitPlayer)
        {
            Invoke("Attacking", 0.4f);
        }
    }
    protected void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.parent.position, detectRange);
    }

}
