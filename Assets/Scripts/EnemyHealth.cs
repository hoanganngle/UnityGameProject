using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
