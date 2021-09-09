using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private GameObject enemyMove;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject houdai;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 3;

    private RaycastHit[] _raycastHits = new RaycastHit[10];
    

    [SerializeField] private PlayerControll playerControll;
    private NavMeshAgent _agent;
    public static int count1 = 1;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        StartCoroutine("BulletAttack");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 look = player.transform.position - houdai.transform.position; //ポジション判定
        transform.rotation = Quaternion.LookRotation(look); //向きを変更する


        //砲台でレイキャスト


        

        _agent.destination = playerControll.transform.position;
    }


   

    public void attack1()
    {
        Vector3 look = player.transform.position - houdai.transform.position;
        
        
         GameObject runcherBullet = GameObject.Instantiate(bulletPrefab) as GameObject; //runcherbulletにbulletのインスタンスを格納
         runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
         runcherBullet.transform.position = houdai.transform.position;//砲台から弾を発射する

         Bullet bullet1 = new Bullet();

       
 
        
       
          
    }
    private IEnumerator BulletAttack()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 10; i++)
        {
            attack1();
            yield return new WaitForSeconds(3f);

            // i==4になったらコルーチン終了  
            if (i == 4)
            {
                yield break;
            }
        }
    }

}
