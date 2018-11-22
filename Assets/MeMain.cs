using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class MeMain : MonoBehaviour {

    //自機（バー）の最大座標
    public static float MAX_ME_X = 7.5f;

    private GameObject ballPrefab;
    private GameObject ball;

    private GameObject textPrefab;  //デバッグ用 2018-11-08
    private GameObject text;        //デバッグ用 2018-11-08
    private int ballCount = 1;      //デバッグ用 2018-11-08

    // Use this for initialization
    void Start () {

        textPrefab = (GameObject)Resources.Load("Pong/DebugText");  //デバッグ用 2018-11-08

        ballPrefab = (GameObject)Resources.Load("Pong/Ball");
        startGame();

    }
	
	// Update is called once per frame
	void Update () {
        #if UNITY_EDITOR
        //キーボードによる自機の移動（UNITYエディター上限定のデバッグ用）
        if(Input.GetKey(KeyCode.LeftArrow)) { // 左←キーのときは
            if (-MAX_ME_X < transform.position.x){
                transform.Translate(Vector3.left * 0.3f); //左へ移動

                //OnBallFell();  //デバッグ用 2018-11-08
            }
        }

        if (Input.GetKey(KeyCode.RightArrow)) { // 右→キーのときは
            if (transform.position.x < MAX_ME_X) {
                transform.Translate(Vector3.right * 0.3f); //左へ移動
            }
        }

        //マウスボタンよる自機の移動（UNITYエディター上限定のデバッグ用）
        if (Input.GetMouseButton(0) )
        { // 左ボタンのときは
            if (-MAX_ME_X < transform.position.x)
            {
                transform.Translate(Vector3.left * 0.3f); //左へ移動

                //OnBallFell();  //デバッグ用 2018-11-08
            }
        }

        if (Input.GetMouseButton(1) )
        { // 右ボタンのときは
            if (transform.position.x < MAX_ME_X)
            {
                transform.Translate(Vector3.right * 0.3f); //左へ移動
            }
        }


        return;
#endif


        //Cardboard（Google VR）での首振りによる自機の移動
        //Quaternion head = GvrV

        // マウスボタンよる自機の移動（Cardbord用）
        if (Input.GetMouseButton(0))
        { // 左ボタンのときは
            if (-MAX_ME_X < transform.position.x)
            {
                transform.Translate(Vector3.left * 0.3f); //左へ移動

                //OnBallFell();  //デバッグ用 2018-11-08
            }
        }

        if (Input.GetMouseButton(1))
        { // 右ボタンのときは
            if (transform.position.x < MAX_ME_X)
            {
                transform.Translate(Vector3.right * 0.3f); //左へ移動
            }
        }

    }

    //receive Message from "FloorCollision"
    void OnBallFell()
    {
        //ボールが床に落ちたらゲームを再開
    //    text.GetComponent<TextMesh>().text = "debug099";  //デバッグ用 2018-11-08
        startGame();
    }


    void startGame()
    {
        //ボールを生成してゲームを開始
        if(ball != null)
        {
            //Destroy(ball);  //今あるボールは削除かな？・・・そのようです。
            Destroy(text);  //デバッグ用 2018-11-08
        }

        //ボールの初期位置を設定する
        Vector3 pos = new Vector3(
                                    0,//transform.position.x,
                                    0,//transform.position.y,
                                    0 + 1.0f ); //transform.position.z + 1.0f);
        //ボールの生成？
        ball = (GameObject)Instantiate(ballPrefab, pos, transform.rotation);

        text = (GameObject)Instantiate(textPrefab, pos, transform.rotation);  //デバッグ用 2018-11-08
        text.GetComponent<TextMesh>().text = "debug00" + ballCount;           //デバッグ用 2018-11-08
        ballCount++;                                                          //デバッグ用 2018-11-08

        //ボールに初速を与える
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if( rb != null )
        {
            rb.velocity = new Vector3(
                    Random.Range(-10.0f, 3.0f), //x
                    0, // y
                    5.0f); //z

        }

    }
}
