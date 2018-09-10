using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour 
{

    Rigidbody2D rigid2D;
    Animator animator;
    float jumpforce = 700.0f;
    float walkforce = 30.0f;
    float maxspeed = 3.0f;
    float threshold = 0.2f;


	// Use this for initialization
	void Start () 
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        // ジャンプ
        if (Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("jumptrriger");
            this.rigid2D.AddForce(transform.up * this.jumpforce);
        }

        // x方向移動に伴ったキー入力
        int act = 0;
        if (Input.acceleration.x > this.threshold ||
            Input.GetKey(KeyCode.RightArrow))
        {
            act = 1;
        }
        if(Input.acceleration.x < -this.threshold ||
           Input.GetKey(KeyCode.LeftArrow))
        {
            act = -1;
        }

        // プレーヤーの移動量を取得してx方向に移動
        float speedX = Mathf.Abs(this.rigid2D.velocity.x);
        // 移動量の制限
        if (speedX < this.maxspeed)
        {
            this.rigid2D.AddForce(transform.right * act * this.walkforce);
        }

        // 向きの反転
        if(act != 0)
        {
            transform.localScale = new Vector3(act, 1.0f, 1.0f);
        }

        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedX / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ゴール");
        SceneManager.LoadScene("clearScene");
    }

}
