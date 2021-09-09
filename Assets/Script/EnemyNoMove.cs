using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNoMove : MonoBehaviour
{
    [SerializeField] private GameObject enemyNoMove;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject houdai;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 3;
    public static int count2 = 0;

    private RaycastHit[] _raycastHits = new RaycastHit[10];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 look = player.transform.position - houdai.transform.position;
        if (Physics.Raycast(enemyNoMove.transform.position, look, out RaycastHit hitInfo, 100))
        {
            attack2();
            Debug.Log(hitInfo.transform.position);
        }



    }
   

    public void attack2()
    {
        if (count2 <= 1)
        {
            GameObject runcherBullet = GameObject.Instantiate(bulletPrefab) as GameObject; //runcherbulletにbulletのインスタンスを格納
            runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet.transform.position = houdai.transform.position;//砲台から弾を発射する
            count2++;
            Bullet bullet2 = new Bullet();
            
        }
    }
    

}
