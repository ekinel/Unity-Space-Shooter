using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public GameObject laserPrefab;
    private float fireRate = 0.3f;
    private float nextFire;
    public static int playerLives = 5;

    [SerializeField]
    private GameObject playerExplosionPrefab;

    [SerializeField]
    private int speed = 6;

    [SerializeField]
    private AudioSource laserShot;

    [SerializeField]
    private Text scoreLabel;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        laserShot = GetComponent<AudioSource>();
    }

    void Update()
    {
        SpaceMovement();

        if(Input.GetMouseButton(0))
        {
            if(Time.time > nextFire)
            {
                laserShot.Play();
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
                nextFire = Time.time + fireRate;
            }
        }
    }

    public void LifeSubstraction()
    {
        playerLives--;

        if(playerLives < 1)
        {
            Instantiate(playerExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    private void SpaceMovement()
    {
        float horizonInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * speed * horizonInput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * vertInput);

        if (transform.position.y > 4.07)
        {
            transform.position = new Vector3(transform.position.x, 4.07f, 0);
        }
        else if (transform.position.y < -4.07f)
        {
            transform.position = new Vector3(transform.position.x, -4.07f, 0);
        }

        if (transform.position.x > 8.2f)
        {
            transform.position = new Vector3(8.2f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.2f)
        {
            transform.position = new Vector3(-8.2f, transform.position.y, 0);
        }
    }
}
