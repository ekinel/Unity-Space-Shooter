using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlls : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyExplosionPrefab;

    [SerializeField]
    private AudioClip explossionSound;

    private int speed = 3;

    private int numerator = 0;
    private int column = 0;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < -6.7)
        {
            transform.position = new Vector3(Random.Range(-7.7f, 7.7f), 6.7f, 0);
        }

        if (UseCoroutines.column % 10 == 0 && UseCoroutines.column/10 != column )
        {
            speed = speed + 1;
            column++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explossionSound, Camera.main.transform.position, 1.0f);
            UseCoroutines.column++;
            Destroy(this.gameObject);
        }
        else if(collision.tag == "Player")
        {
            PlayerControls playerControls = collision.GetComponent<PlayerControls>();

            if(playerControls != null)
            {
                playerControls.LifeSubstraction();
            }

            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explossionSound, Camera.main.transform.position, 1.0f);
            Destroy(this.gameObject);
        }
    }
}
