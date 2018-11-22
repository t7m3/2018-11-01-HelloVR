using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollision : MonoBehaviour {

    private GameObject textPrefab;  //デバッグ用 2018-11-08
    private GameObject text;        //デバッグ用 2018-11-08

    //通知対象のオブジェクト
    public GameObject MeObject;

    void OnCollisionEnter(Collision col)
    {
        text.GetComponent<TextMesh>().text = "debug102";  //デバッグ用 2018-11-08

        MeObject.SendMessage("OnBallFell");

    }

    // Use this for initialization
    void Start()
    {
        //デバッグ用 2018-11-08
        textPrefab = (GameObject)Resources.Load("Pong/FloorText");  //デバッグ用 2018-11-08
        Vector3 Fpos = new Vector3(
                                   0,//transform.position.x,
                                   2,//transform.position.y,
                                   5 + 1.0f); //transform.position.z + 1.0f);
        text = (GameObject)Instantiate(textPrefab, Fpos, transform.rotation);
        text.GetComponent<TextMesh>().text = "debug101";
        //デバッグ用 2018-11-08
     


    }

    // Update is called once per frame
    void Update()
    {

    }

}
