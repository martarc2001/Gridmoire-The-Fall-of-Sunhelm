using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{

	private Color basicColor = Color.white;
	private Color hoverColor = new Color(171,0,255);
	private Renderer renderer;

	void Start()
	{
		renderer = GetComponentInChildren<SpriteRenderer>();
		renderer.material.color = basicColor;
	}

	void OnMouseEnter()
	{
		renderer.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		renderer.material.color = basicColor;
	}


}
