using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookTarget : MonoBehaviour
{
    [SerializeField] protected Health enemy;
    [SerializeField] protected GameObject player;

    [SerializeField] protected float detectRange;
    [SerializeField] protected LayerMask playerLayers;

    private void Start()
    {
        enemy = transform.parent.GetComponent<Health>();
    }
    private void Update()
    {
        DetectPlayer();
    }

    protected void Look()
    {
        if (enemy.isDie || enemy.isStun ) return;
        if (player.transform.position.x > transform.parent.position.x)
        {
            transform.parent.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.parent.localScale = new Vector3(1, 1, 1);
        }
    }
    protected void DetectPlayer()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(transform.parent.position, detectRange, playerLayers);
        foreach (Collider2D player in hitPlayer)
        {
            Look();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.parent.position, detectRange);
    }
}
