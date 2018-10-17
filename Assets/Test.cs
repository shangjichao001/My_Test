using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour 
{
    public Canvas canvasTarget;
	void Start () 
    {
        print("你好啊");
	}

	private void Update () 
    {
        //if(this.gameObject.activeSelf)
        //{
        //    Debug.Log("111");

        //}

        //if(Input.GetKeyDown(KeyCode.S))
        //{
        //    print("sssss");
        //    Destroy();           
        //}

        if(!IsClickUI())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hitInfo = Physics2D.Raycast(new Vector2(inputPos.x, inputPos.y), Vector2.zero);
                Debug.DrawLine(new Vector2(inputPos.x, inputPos.y), Vector2.zero);
                if (hitInfo)
                {
                    print("点击了" + hitInfo.collider.gameObject.name);
                }
                else
                {
                    print("未点击到");
                }
            }
        }
	}

    //void Destroy()
    //{
    //    Destroy(this);
    //}



    /// <summary>
    /// 判断是否点击在UI上 using UnityEngine.EventSystems;
    /// </summary>
    /// <returns><c>true</c>, if click user interface was ised, <c>false</c> otherwise.</returns>
    private bool IsClickUI()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
#if IPHONE || ANDROID
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#else
            if (EventSystem.current.IsPointerOverGameObject())
#endif
            {
                Debug.Log("当前触摸在UI上");
                return true;
            }
            else
            {
                Debug.Log("当前没有触摸在UI上");
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
