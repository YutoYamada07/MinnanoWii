using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public GameObject particleObject;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "Bullet")
        {
            Instantiate(particleObject,this.transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
