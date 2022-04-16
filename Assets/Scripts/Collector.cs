using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public Text txt;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Enemy")){
            txt.text = (int.Parse(txt.GetComponent<Text>().text)+1).ToString();
            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("Player")){
            Destroy(collision.gameObject);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
