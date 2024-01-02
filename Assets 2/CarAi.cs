using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarAi : MonoBehaviour
{

    public TextMeshProUGUI WINTEXT;

    public float speed = 5f;
    public Transform player;

    void Update()
    {
        MoveCar();
    }

    void MoveCar()
    {
        // Move the car from top to bottom
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Check if the car reached the bottom of the screen
        if (transform.position.y < -40f)
        {
            RespawnCar();
        }

        // Check if the car hits the player
        if (Vector3.Distance(transform.position, player.position) < 1.0f)
        {
            // Handle collision with the player (you can implement your own logic here)
            Debug.Log("Car hit the player!");
        }
    }

    void RespawnCar()
    {
        // Reset the car to the top of the screen when it reaches the bottom
        float randomX = Random.Range(-80f, 80f);
        transform.position = new Vector3(randomX, 44f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            WINTEXT.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
