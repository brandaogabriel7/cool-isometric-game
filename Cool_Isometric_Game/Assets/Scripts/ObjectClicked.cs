using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicked : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
		Camera cam = Camera.main;
        if(Input.GetMouseButtonUp(0)) {
			Vector2 click = cam.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(click, Vector2.zero);
			if(hit.collider) Debug.Log(hit.collider);
		}
    }
}
