using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] protected Health player;
    [SerializeField] protected Health boss;
    [SerializeField] protected GameObject gameOver;
    [SerializeField] protected GameObject victory;


    private void FixedUpdate()
    {
        if (player.isDie)
        {
            gameOver.SetActive(true);
        }
        if (boss.isDie)
        {
            victory.SetActive(true);
        }
    }
}
