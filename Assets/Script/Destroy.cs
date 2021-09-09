using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        // 衝突した相手にPlayerタグが付いているとき
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
