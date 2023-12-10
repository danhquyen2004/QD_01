using System.Collections;
using UnityEngine;

public class ESwordAtk : PlayerAttack
{
    [SerializeField] private Animator animator;
    private void Update()
    {
        DetectPlayer();
    }
    protected void DetectPlayer()
    {
        if (isAtking)
        {
            countAtkTime += Time.deltaTime;
            if (countAtkTime > atkRate)
            {
                isAtking = false;
                countAtkTime = 0;
            }
            return;
        }
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        if (hitPlayers.Length > 0) isAtking = true;
        foreach (Collider2D player in hitPlayers)
        {
            animator.SetTrigger("Attack");
            StartCoroutine(WaitAtk());
            animator.SetFloat("RunState", 0f);
        }
        //
    } 

    IEnumerator WaitAtk()
    {
        yield return new WaitForSeconds(0.5f);
        float x = Vector3.Distance(attackPoint.position, PlayerController.Instance.transform.position);
        if (x <= attackRange+1f)
        {
            Debug.Log("hit player");
            PlayerController.Instance.health.TakeDamage(damage);
        }
    }

}
