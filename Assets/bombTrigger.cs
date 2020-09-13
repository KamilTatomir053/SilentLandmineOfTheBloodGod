using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombTrigger : MonoBehaviour
{
    public Game game;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);

        if (collision.CompareTag("Soldier") == true)
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Death");

            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            collision.gameObject.GetComponent<Soldier>().KillSoldier();

            game.AddPoint();
        }
    }
}
