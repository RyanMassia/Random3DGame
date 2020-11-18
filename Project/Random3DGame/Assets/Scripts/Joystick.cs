using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	private Vector3 offset;
	private float maxOffset;
	private Vector3 initPos;
	private Vector2 formattedInput;

	public void OnBeginDrag(PointerEventData eventData)
	{
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		offset = Input.mousePosition - initPos;

		if (offset.magnitude > maxOffset)
		{
			offset.Normalize();
			offset *= maxOffset;
		}
		transform.position = initPos + offset;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		transform.position = initPos;
		offset = Vector3.zero;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public Vector2 GetInput()
	{
		return offset.normalized;
	}

	public void Start()
	{
		initPos = transform.position;
		maxOffset = 50.0f;
	}
}
