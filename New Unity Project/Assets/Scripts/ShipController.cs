using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour 
{
    public PulseController pulseController;

    private bool selected;

	void Start () 
    {
        selected = false;
	}
	
	void FixedUpdate () 
    {
        if (Input.GetMouseButtonDown(0) && !selected)
        {
            selected = true;
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rayPos = new Vector2(mousePosition.x, mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

            if (hit)
            {
                pulseController.SetStartPulse(true);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
            pulseController.SetStartPulse(false);
        }
	}
}
