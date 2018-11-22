using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ボールを自機（バー）で跳ね返す際の処理
public class BallCollision : MonoBehaviour {

    private void OnCollisionEnter(Collision col)
    {
        Rigidbody rb = null;

        if(col.gameObject.name == "Me"){

            rb = GetComponent<Rigidbody>();

        }

        if(rb != null){

            //自機で跳ね返す際に、少し速く、少し方向がランダムになるようにする
            if(Random.Range(0,4) == 0)
            {
                rb.velocity = new Vector3(
                                    Random.Range(-5.0f, 5.0f),
                                    0,
                                    rb.velocity.z * 1.05f);
            }
            else
            {
                rb.velocity = new Vector3(
                                    rb.velocity.x + Random.Range(-0.05f, 0.05f),
                                    0,
                                    rb.velocity.z * 1.05f);
            }
            

        }
        
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
