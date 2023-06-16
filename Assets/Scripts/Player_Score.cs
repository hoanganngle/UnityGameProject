using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour
{
    private float timeLeft = 120;
    public int playerScore = 0;
    public GameObject TimeLeftUI;
    public GameObject PlayerScoreUI;
    
    void Start()
    {
        // DataManagement.datamanagement.LoadData(); //khong bug, van chay duoc = 1 cach nao do
    }
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        //TimeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + timeLeft);
        //PlayerScoreUI.gameObject.GetComponent<Text>().text = ("Score:" + playerScore);
        // bug khuc nay can fix
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    void OnTriggerEnter2D (Collider2D trig)
    {
        if(trig.gameObject.name == "End"){
           CountScore();
            // DataManagement.datamanagement.SaveData();
            SceneManager.LoadScene("SampleScene");

        }
        if (trig.gameObject.tag == "bonus")
        {
            playerScore += 10;
            Destroy(trig.gameObject);
        }
    }
    void CountScore()
    {
        //Debug.Log("The currently high score is: " + DataManagement.datamanagement.highScore);
        playerScore = playerScore + (int)(timeLeft * 10);
        //ataManagement.datamanagement.highScore = playerScore + (int)(timeLeft * 10);
        Debug.Log(playerScore);
        //Debug.Log("After update to DManagement, the score is: " + DataManagement.datamanagement.highScore);
        //bug tiep, fix tiep
    }
}
