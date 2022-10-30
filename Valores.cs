using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valores : MonoBehaviour
{
    private static Valores _instance;
    public int spriteRaza;
    public static Valores Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance==null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);

        }
    }
}
