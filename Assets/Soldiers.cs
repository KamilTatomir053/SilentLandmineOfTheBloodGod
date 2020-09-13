using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soldiers : MonoBehaviour
{
    public Game game;

    public GameObject[] soldierPrefabs;

    public Wave[] weves;

    public Text waveText;

    private int currentWave = 0;

    private int soldiersInWave = -1;

    public GameObject winText;

    public void StartSoldierMovement()
    {
        NextWave();
    }

    private void NextWave()
    {
        if (currentWave >= weves.Length)
        {
            Win();
        }
        else
        {
            StartCoroutine(SpawnSoldiers());

            waveText.text = "Wave: " + (currentWave + 1);

            waveText.fontSize = 30;

            waveText.color = Color.yellow;

            Invoke("defaultWaveText", 2);
        }
    }

    public void defaultWaveText()
    {
        waveText.fontSize = 22;

        waveText.color = Color.white;
    }

    IEnumerator SpawnSoldiers()
    {
        soldiersInWave = weves[currentWave].soldiersCount;

        for (int i = 0; i < weves[currentWave].soldiersCount; i++)
        {
            GameObject soldier = Instantiate(soldierPrefabs[Random.Range(0, soldierPrefabs.Length)], transform.position, Quaternion.identity);

            soldier.GetComponent<Rigidbody2D>().velocity = Vector2.left * weves[currentWave].soldiersSpeed;

            soldier.GetComponent<Soldier>().SetReference(this);

            yield return new WaitForSeconds(weves[currentWave].timeBetweenSoldiers);
        }

        currentWave++;
    }


    public void KilledSoldier()
    {
        soldiersInWave--;

        if (soldiersInWave == 0)
        {
            Invoke("KilledAll", 2);
        }
    }

    private void KilledAll()
    {
        NextWave();

        game.RespawnBomb();
    }

    public void Win()
    {
        winText.SetActive(true);

        Invoke("AfterWin", 3);
    }

    private void AfterWin()
    {
        game.ShowMainMenu();
    }

    [System.Serializable]
    public class Wave
    {
        public float soldiersSpeed;

        public int soldiersCount;

        public float timeBetweenSoldiers;
    }
}
