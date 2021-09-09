using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footprint : MonoBehaviour
{
    public GameObject footprintPrefab;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;
        if (this.time > 0.10f)
        {
            this.time = 0;
            Instantiate(footprintPrefab,transform.position,transform.rotation);
        }
        
    }
}
