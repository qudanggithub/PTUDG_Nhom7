using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class weapon : MonoBehaviour
{
    // Đối tượng viên đạn
    public GameObject bullet;
    public GameObject TiaLua;
    //Vị trí xuất hiện của viên đạn : Đầu súng
    public Transform FirePos;
    //Quản lý tốc độ bắn
    public float TimeShoot = 0.2f;
    private float timeShoot;
    //Quản lý lực của viên đạn
    public float bulletForce;
    //âm thnah súng
    public AudioSource audioSource;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
        timeShoot -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timeShoot < 0)
        {
            FireBullet();
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }


    private void RotateGun()
    {
        //Vị trí của chuột so với màn hình game
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector từ nhân vật so với vị trí chuột
        Vector2 lookDir = MousePos - transform.position;
        //Lấy góc quay Z của súng 
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        //Quay súng
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        transform.rotation = rotation;


        //Xoay súng theo góc quay
        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(1, -1, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
        }


    }

    private void FireBullet()
    {
        timeShoot = TimeShoot;
        var bulletTmp = Instantiate(bullet, FirePos.position, Quaternion.identity);
        Instantiate(TiaLua, FirePos.position, transform.rotation, transform);
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        //Add lực cho viên đạn
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
}
