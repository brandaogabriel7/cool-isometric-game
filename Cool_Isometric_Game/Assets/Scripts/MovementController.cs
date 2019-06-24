using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
	public float movementSpeed = 1f;

    // IsometricCharacterRenderer isoRenderer;
    Rigidbody2D rbody;
    Vector2 currPosition;
    Vector2 targetPosition;

    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        // isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        targetPosition = GetComponent<Transform>().position;
    }

    // FixedUpdate is called once every two frames
    void FixedUpdate()
    {
        Camera cam = Camera.main;
        currPosition = GetComponent<Transform>().position;
        if(Math.Ceiling(currPosition.x) != Math.Ceiling(targetPosition.x) || Math.Ceiling(currPosition.y) != Math.Ceiling(targetPosition.y)) {
            Vector2 direction = (targetPosition - currPosition).normalized;
            direction = Vector2.ClampMagnitude(direction, 1);
            Vector2 movement = direction * movementSpeed;
            Vector2 newPos = currPosition + movement * Time.fixedDeltaTime;
            rbody.MovePosition(newPos);
        }
		if(Input.GetMouseButtonUp(0)) {
			Vector2 click = cam.ScreenToWorldPoint(Input.mousePosition);
			targetPosition = click;
		}
        if(Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Ended) {
                targetPosition = cam.ScreenToWorldPoint(touch.position);
            }
        }
    }
}
