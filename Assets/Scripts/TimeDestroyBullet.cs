using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeDestroy;
    void Start()
    {
        Destroy(this.gameObject, timeDestroy);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
