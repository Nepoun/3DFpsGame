using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    #region Variables
    public GameObject bulletPrefab;

    public GameObject weaponFirePoint;
    public GameObject particleObject;

    public float bulletSpeed;

    #endregion

    #region MonoBehavior Callbacks

    void Start()
    {
        weaponFirePoint = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shoot();
    }

    #endregion

    #region Private methods

    void Shoot()
    {

        GameObject actualProjectile = Instantiate(
            bulletPrefab,
            weaponFirePoint.transform.position,
            weaponFirePoint.transform.rotation
            );

        actualProjectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, bulletSpeed, 0));

        particleObject.GetComponent<ParticleSystem>().Play();
        
    }

    #endregion


}
