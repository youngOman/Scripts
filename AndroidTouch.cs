using UnityEngine;
using System.Collections;

public class AndroidTouch : MonoBehaviour {

    private int isforward;//標記攝像機的移動方向
    //記錄兩個手指的舊位置
    private Vector2 oposition1=new Vector2();
    private Vector2 oposition2=new Vector2();

    Vector2 m_screenPos = new Vector2(); //記錄手指觸碰的位置

    //用於判斷是否放大
    bool isEnlarge(Vector2 oP1, Vector2 oP2, Vector2 nP1, Vector2 nP2)
    {
        //函式傳入上一次觸控兩點的位置與本次觸控兩點的位置計算出使用者的手勢
        float leng1 = Mathf.Sqrt((oP1.x - oP2.x) * (oP1.x - oP2.x) + (oP1.y - oP2.y) * (oP1.y - oP2.y));
        float leng2 = Mathf.Sqrt((nP1.x - nP2.x) * (nP1.x - nP2.x) + (nP1.y - nP2.y) * (nP1.y - nP2.y));
        if (leng1 < leng2)
        {
            //放大手勢
            return true;
        }
        else
        {
            //縮小手勢
            return false;
        }
    }

    void Start()
    {
        Input.multiTouchEnabled = true;//開啟多點觸碰
    }

    void Update()
    {
        if (Input.touchCount <= 0)  
            return;
        if (Input.touchCount == 1) //單點觸碰移動攝像機
        {
            if (Input.touches[0].phase == TouchPhase.Began)
                m_screenPos = Input.touches[0].position;   //記錄手指剛觸碰的位置
            if (Input.touches[0].phase == TouchPhase.Moved) //手指在螢幕上移動，移動攝像機
            {
                transform.Translate(new Vector3( Input.touches[0].deltaPosition.x * Time.deltaTime, Input.touches[0].deltaPosition.y * Time.deltaTime, 0));
            }
        }

        else if (Input.touchCount > 1)//多點觸碰
        {
            //記錄兩個手指的位置
            Vector2 nposition1 = new Vector2();
            Vector2 nposition2 = new Vector2();

            //記錄手指的每幀移動距離
            Vector2 deltaDis1 = new Vector2();
            Vector2 deltaDis2 = new Vector2();

            for (int i = 0; i < 2; i++)
            {
                Touch touch = Input.touches[i];
                if (touch.phase == TouchPhase.Ended)
                    break;
                if (touch.phase == TouchPhase.Moved) //手指在移動
                {

                    if (i == 0)
                    {
                        nposition1 = touch.position;
                        deltaDis1 = touch.deltaPosition;
                    }
                    else
                    {
                        nposition2 = touch.position;
                        deltaDis2 = touch.deltaPosition;

                        if (isEnlarge(oposition1, oposition2, nposition1, nposition2)) //判斷手勢伸縮從而進行攝像機前後移動引數縮放效果
                            isforward = 1;
                        else
                            isforward = -1;
                    }
                    //記錄舊的觸控位置
                    oposition1 = nposition1;
                    oposition2 = nposition2;
                }
                //移動攝像機
                Camera.main.transform.Translate(isforward*Vector3.forward * Time.deltaTime*(Mathf.Abs(deltaDis2.x+deltaDis1.x)+Mathf.Abs(deltaDis1.y+deltaDis2.y)));
            }  
        }
    }
}