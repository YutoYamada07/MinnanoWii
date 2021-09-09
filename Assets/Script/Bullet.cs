using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 latestPos;
    private int detectTime = 1; //衝突回数
    [SerializeField] GameObject player;
    [SerializeField] private PlayerControll playerscript; //新しく加えているところ
    [SerializeField] GameObject enemyMove;
    [SerializeField] GameObject enemyNoMove;
    [SerializeField] private GameObject bullet;
    public int from;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            Destroy(gameObject);
            
          
        }
        else if (collision.gameObject == enemyNoMove || collision.gameObject == enemyMove)
        {
           
            
            Destroy(gameObject);
 
        }
        else if (detectTime >= 2)
        {
            
            
            Destroy(gameObject);
            
        }
        else if (collision.gameObject == bullet)
        {
           
            
            Destroy(gameObject);
            
        }
        else
        {
            detectTime++;

        }

    }

    

    // Start is called before the first frame update
    void Start()
    {
        playerscript = player.GetComponent<PlayerControll>();
       

    }

    
    // Update is called once per frame
    void Update()
    {


        //常に向きがまっすぐになるように設計をする
        Vector3 diff = transform.position - latestPos;   //前回からどこに進んだかをベクトルで取得
        latestPos = transform.position;  //前回のPositionの更新

        //ベクトルの大きさが0.01以上の時に向きを変える処理をする
        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
        }
        if (transform.position.y >= 3)
        {

            Destroy(gameObject);
        }
    }

    
   
}
