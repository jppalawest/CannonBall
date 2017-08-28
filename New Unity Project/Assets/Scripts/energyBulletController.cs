using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyBulletController : MonoBehaviour 
{
    public float lifetime;

    private float pulseForce;
    private Rigidbody2D rb2d;

	void Start () 
    {
        rb2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
	}

    void Update()
    {
       rb2d.AddForce(gameObject.transform.up * pulseForce);
       pulseForce = pulseForce * 0.9f;
    }

    public void setPulseForce(float pulseForceTemp)
    {
        pulseForce = pulseForceTemp * 10;
        //Debug.Log(pulseForce);
    }
}
