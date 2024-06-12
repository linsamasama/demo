using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject singleton = new GameObject();
                    _instance = singleton.AddComponent<GameManager>();
                    singleton.name = "GameManager";
                    DontDestroyOnLoad(singleton); // 确保GameObject在加载新场景时不被销毁  
                }
            }

            return _instance;
        }
    }

    public int Stamina { get; private set; }
    public int Gold { get; private set; }


    public void Initialize()
    {
        Stamina = 3000; // 初始体力值  
        Gold = 3000; // 初始金币值  
    }

    // 增加体力的方法  
    public void AddStamina(int amount)
    {
        Stamina = Mathf.Min(Stamina + amount, int.MaxValue); // 确保体力不超过最大值  
    }

    // 减少体力的方法（可选）  
    public void RemoveStamina(int amount)
    {
        Stamina = Mathf.Max(Stamina - amount, 0); // 确保体力不低于0  
    }

    // 增加金币的方法  
    public void AddGold(int amount)
    {
        Gold += amount;
    }

    // 减少金币的方法（可选）  
    public void RemoveGold(int amount)
    {
        Gold = Mathf.Max(Gold - amount, 0); // 确保金币不低于0  
    }
    void Awake()
    {
        // 确保单例的唯一性  
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // 如果已经存在实例，则销毁这个新创建的实例  
        }

        // 初始化数值（如果需要的话）  
        Initialize();
    }

}
