//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MouseEffect : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject sole;

//    float spawnsTime;
//    private float defaultTime = 0.05f;

//    void Update()
//    {
//        if (Input.GetMouseButton(0)&&spawnsTime>=defaultTime)
//        {
//            SoleCreate();
//            spawnsTime = 0;
//        }
//        spawnsTime += Time.deltaTime;
//    }

//    void SoleCreate()
//    {
//        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        mPosition.z = 0;
//        Instantiate(sole, mPosition, Quaternion.identity); 
//    }
//}
