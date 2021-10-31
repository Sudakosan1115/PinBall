using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //左矢印キー,Aを押した時左フリッパーを動かす
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetKeyDown(KeyCode.A))) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //右矢印キー,Dを押した時右フリッパーを動かす
        if ((Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetKeyDown(KeyCode.D))) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //下矢印キー,Sを押した時両方のフリッパーを動かす
        if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            SetAngle(this.flickAngle);
        }

        //左矢印キー,A離された時フリッパーを元に戻す
        if ((Input.GetKeyUp(KeyCode.LeftArrow) || (Input.GetKeyUp(KeyCode.A))) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //右矢印キー,D離された時フリッパーを元に戻す
        if ((Input.GetKeyUp(KeyCode.RightArrow) || (Input.GetKeyUp(KeyCode.D))) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //下矢印キー,S離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.S) || (Input.GetKeyUp(KeyCode.DownArrow)))
        {
            SetAngle(this.defaultAngle);
        }



        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // 座標xがスクリーンの2分の1以上の場合
            if (Input.mousePosition.x >= Screen.width / 2)
            {
                // 右側をタップしたら右のフリッパーが動く
                if (touch.phase == TouchPhase.Began && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
            }
            else
            {
                // 左側をタップしたら左のフリッパーが動く
                if (touch.phase == TouchPhase.Began && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
            }

            {
                // 右側をタップしたら右のフリッパーを元に戻す
                if (touch.phase == TouchPhase.Ended && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }

                else
                {
                    // 左側をタップしたら左のフリッパーを元に戻す
                    if (touch.phase == TouchPhase.Ended && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
            }
        }

        if (Input.touchCount > 1)
        {
            Touch touch = Input.GetTouch(1);

            //両側をタップすると両方のフリッパーが動く
            if (touch.phase == TouchPhase.Began && Input.touchCount != 1)
            {
                SetAngle(this.flickAngle);
            }

            //両側を離すと両方のフリッパーを元に戻す
            if (touch.phase == TouchPhase.Ended)
            {
                SetAngle(this.defaultAngle);
            }
        }
        
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}