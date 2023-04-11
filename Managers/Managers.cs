 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_Instance; // 유일성 보장
    static Managers Instance { get { init(); return s_Instance; } } // 유일한 매니저를 갖고온다.

    InputManager _input = new InputManager();
    public static InputManager Input { get { return Instance._input; } }
    ResourceManager _resource = new ResourceManager();
    public static ResourceManager Resource { get { return Instance._resource; } }
    
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        _input.OnUpdate();   
    }

    static void init()
    {
        if(s_Instance == null)
        {
            GameObject go = GameObject.Find("@Managers"); // 매니저 탐색
            if (go == null)
            {
                go = new GameObject { name = "@Managers" }; //매니저 생성
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go); // 보존 선언
            s_Instance = go.GetComponent<Managers>();

        }
        

    }
}
