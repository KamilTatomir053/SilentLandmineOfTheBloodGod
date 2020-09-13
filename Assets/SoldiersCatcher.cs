using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiersCatcher : MonoBehaviour
{
    public Game game;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Soldier") == true)
        {
            collision.GetComponent<Soldier>().KillSoldier();

            Destroy(collision.gameObject);

            game.RemoveHeart();
        }
    }
}
