using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseCoroutines : MonoBehaviour
{
    public GameObject enemyPrefab;

    public static int column = 0;

    [SerializeField]
    private Text numEnemy;

    [SerializeField]
    private Text playerLives;

    void Start()
    {
        StartCoroutine(CloneEnemyPrefab());
    }

    private void Update()
    {
        numEnemy.text = "Destroy: " + column;
        playerLives.text = "Live: " + PlayerControls.playerLives;
    }

    IEnumerator CloneEnemyPrefab()
    {
        while (true)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-7.7f, 7.7f), 6.7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(2.5f);
        }
    }

}
