using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : Stats
{
    MonsterStat _stat;
    // Start is called before the first frame update
    void Start()
    {
        _stat = gameObject.GetComponent<MonsterStat>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
