using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monosingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool shuttingDown = false;
    private static object locker = new object();

    private static T instance = null;
    public static T Instance
    {
        get
        {
            if(shuttingDown)
            {
                Debug.LogWarning("[Instance] Instance " + typeof(T) + " is already destroyed. Returning null.");
                return null;
            }

            lock (locker)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                        DontDestroyOnLoad(instance); // 아마 신 변경하는거 만들거면 수정해줘야할것..? 아직은 잘 모르겠다. 
                    }
                }
                return instance;
            }
        }
    }
}
