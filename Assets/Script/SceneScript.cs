using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    
    private GameObject[] enemyObjects;
    public TextMesh ClearText;


    private void Start()
    {
        ClearText.gameObject.SetActive(false);
        
    }




    // Update is called once per frame
    void Update()
    {
        enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        

        if (enemyObjects.Length == 0)
        {
            ClearText.gameObject.SetActive(true);
            
        }
        
    }
    
}
