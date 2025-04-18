using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peashooter : Plant
{
    // Start is called before the first frame update
    public float shootDuration = 2;
    private float shootTimer = 0;
    public Transform shootPointTransform;

    public PeaBullet peaBulletPrefab;

    public float bulletSpeed = 5;
    public int atkValue=20;
    protected override void EnableUpdate()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer > shootDuration)
        {
            Shoot();
            shootTimer = 0;
        }
    }
    void Shoot()
    {
        PeaBullet pb =GameObject.Instantiate(peaBulletPrefab, shootPointTransform.position,Quaternion.identity);
        pb.SetSpeed(bulletSpeed);
        pb.SetATKValue(atkValue);
    }   
}
