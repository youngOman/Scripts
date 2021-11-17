using UnityEngine;
using System.Collections;
using System.IO;
public class ScaleAndRotate : MonoBehaviour
{
	private Touch oldTouch1;  //上次觸控點1(手指1)
	private Touch oldTouch2;  //上次觸控點2(手指2)
	void Start()
	{
	}
	void Update () {
		//沒有觸控
		if ( Input.touchCount <= 0 ){
			return;
		}
		//單點觸控， 水平上下旋轉
		if(Input.touchCount > 0){ //1 == Input.touchCount
			Touch touch = Input.GetTouch (0);
			Vector2 deltaPos = touch.deltaPosition;			
			transform.Rotate(Vector3.down  * deltaPos.x , Space.World); 
			transform.Rotate(Vector3.right * deltaPos.y , Space.World);
		}
		//多點觸控, 放大縮小
		Touch newTouch1 = Input.GetTouch (0);
		Touch newTouch2 = Input.GetTouch (1);
		//第2點剛開始接觸螢幕, 只記錄，不做處理
		if( newTouch2.phase == TouchPhase.Began ){
			oldTouch2 = newTouch2;
			oldTouch1 = newTouch1;
			return;
		}
		
		//計算老的兩點距離和新的兩點間距離，變大要放大模型，變小要縮放模型
		float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
		float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);
		//兩個距離之差，為正表示放大手勢， 為負表示縮小手勢
		float offset = newDistance - oldDistance;
		//放大因子， 一個畫素按 0.01倍來算(100可調整)
		float scaleFactor = offset / 100f;
		Vector3 localScale = transform.localScale;
		Vector3 scale = new Vector3(localScale.x + scaleFactor,
		                            localScale.y + scaleFactor, 
		                            localScale.z + scaleFactor);

		//最小縮放到 0.3 倍
		if (scale.x > 0.3f && scale.y > 0.3f && scale.z > 0.3f) {
			transform.localScale = scale;
		}
		//記住最新的觸控點，下次使用
		oldTouch1 = newTouch1;
		oldTouch2 = newTouch2;
	}

}