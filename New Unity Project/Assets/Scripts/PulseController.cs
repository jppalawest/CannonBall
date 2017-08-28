using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseController : MonoBehaviour 
{
    public float maxPulse;
    public Vector3 maxScale;
    public float scaleAmount;
    public float pulseAmountRate;
    
    public Transform energyBulletSpawn;
    public Transform rotator;
    public energyBulletController energyBullet;
    public GameObject pulseLimit;
    

    private bool startPulse;
    private bool pulsing;
    private float pulseAmount;
    private float minPulse;
    private Vector3 minScale;
    private Vector3 currentScale;
    
    void Start()
    {
        startPulse = false;
        pulsing = false;
        minPulse = 1;
        pulseAmount = minPulse;
        minScale = transform.localScale;
        currentScale = minScale;
        pulseLimit.transform.localScale = minScale;
    }

    void FixedUpdate()
    {
        if (startPulse)
        {
            if (!pulsing)
            {
                pulseLimit.transform.localScale = maxScale;
                pulsing = true;
            }

            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rotator.transform.right = new Vector3(mousePosition.x, mousePosition.y, 0) - rotator.transform.position;

            float distanceX = mousePosition.x - transform.position.x;
            float distanceY = mousePosition.y - transform.position.y;

            float distanceTotal = Mathf.Sqrt((distanceX * distanceX) + (distanceY * distanceY));

            pulseAmount = distanceTotal;
            pulseAmount = (Mathf.Round(pulseAmount * 10) / 10);

            if (pulseAmount <= minPulse)
                pulseAmount = minPulse;
            if (pulseAmount >= maxPulse)
                pulseAmount = maxPulse;

            //Esta formula es para la proporcion del pulso junto con la escala del sprite del pulso. El max es 2 y el min es 0.5 por eso se usa 1.5
            float currentScaleTemp = (pulseAmount * (1.5f)) / 10;
            currentScale = new Vector3(currentScaleTemp + 0.5f, currentScaleTemp + 0.5f, 0);
            transform.localScale = currentScale;
        }
        else if (!startPulse && pulsing)
        {
            pulsing = false;

            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rotator.transform.right = new Vector3(mousePosition.x, mousePosition.y, 0) - rotator.transform.position; 

            energyBulletController energyBulletClon = (energyBulletController)Instantiate(energyBullet, energyBulletSpawn.position, energyBulletSpawn.rotation);
            energyBulletClon.setPulseForce(pulseAmount);

            transform.localScale = minScale;
            pulseLimit.transform.localScale = minScale;
            pulseAmount = minPulse;
        }

    }

    public void SetStartPulse(bool setStart)
    {
        startPulse = setStart;
    }


}
