using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public bool hasDied;
    public int health;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -7)
        {
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene("SampleScene");
        //yield return null;
        Debug.Log("Player has fallen");
        Debug.Log("Player has died");
    }
}
