﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovement : MonoBehaviour
{
	public float MovementSpeed;

	public Rigidbody2D Rb;
	public Collider2D Collider;
	public LayerMask GroundMask;

	protected virtual void Reset()
	{
		Rb = GetComponent<Rigidbody2D>();
		Collider = GetComponent<Collider2D>();
	}

	protected bool IsGrounded()
	{
		return Collider.IsTouchingLayers(GroundMask.value);
	}
}
