using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        if(gameObject.transform.position.y <= -5.5f)
        {
            SceneManager.Instance.clearSceneCnt--;
            SceneManager.Instance.LoadScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EndPoint"))
        {
            SceneManager.Instance.LoadScene();
        }
    }
}
