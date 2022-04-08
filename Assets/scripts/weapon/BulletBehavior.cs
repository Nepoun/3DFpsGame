using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    #region variables
    #endregion

    #region MonoBehavior Callbacks
    void OnEnable()
    {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<TrailRenderer>().enabled = true;   
            Invoke("deactivateThis", 3f);     
    }
    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("bullet"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<TrailRenderer>().enabled = false;

            GetComponent<ParticleSystem>().Play();
            Invoke("deactivateThis", 1f);
        }
    }
    #endregion

    #region Private Methods

    void deactivateThis()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<ParticleSystem>().Stop();
        SimplePool.Despawn(this.gameObject);
    }

    #endregion

}
