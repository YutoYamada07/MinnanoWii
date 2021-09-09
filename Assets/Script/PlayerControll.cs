using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(CharacterController))]


public class PlayerControll : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bulletPrefab;
    
    [SerializeField] private GameObject houdai;
    [SerializeField] private float bulletSpeed = 3;

    public int life = 3;

    public float speed = 6.0F;       //歩行速度
    public float gravity = 20.0F;    //重力の大きさ
    public float rotateSpeed = 3.0F;    //回転速度
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float h, v;
    private float mX;
    private Vector3 _startBallPosition;

    public TextMesh GameOverText;


    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
       
        _startBallPosition = transform.position;
        GameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");    //左右矢印キーの値(-1.0~1.0)
        v = Input.GetAxis("Vertical");      //上下矢印キーの値(-1.0~1.0)
        mX = Input.GetAxis("Mouse X");       //マウスの左右移動量(-1.0~1.0)

        //キャラクターの移動回転
        if (controller.isGrounded)
        {
            moveDirection = speed * new Vector3(h, 0, v);                               //移動方向を決定
            moveDirection = transform.TransformDirection(moveDirection);         //ベクトルをローカル座標からグローバル座標へ変換
            gameObject.transform.Rotate(new Vector3(0, rotateSpeed * mX, 0));
          
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);



        ///左クリックをすると弾がまっすぐに飛んでいく
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            
            GameObject runcherBullet = GameObject.Instantiate(bulletPrefab) as GameObject; //runcherbulletにbulletのインスタンスを格納
            runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet.transform.position = houdai.transform.position;//砲台から弾を発射する
            
            Bullet bullet = new Bullet();

        }
        
    }

    //弾に当たった時の対応
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag=="Bullet")
        {
            Destroy(hit.gameObject);//自身を破壊
            redo();
            
        }
    }

    void redo()
     {
        life--;
        transform.position = _startBallPosition;
        if (life <= 0)
        {
            GameOverText.gameObject.SetActive(true);
            player.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
    
 }
