using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FinishLineScript : MonoBehaviour
{

    public TextMeshProUGUI WINTEXT;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player crossed the finish line! You win!");
            // Add any other logic you need for winning the game
        }

        if(collision.tag == "Player")
        {
            WINTEXT.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
