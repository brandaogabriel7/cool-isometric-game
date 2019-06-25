using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathTilemapCollisionIgnore : MonoBehaviour
{
    void Start()
    {
        Tilemap[] tilemaps = FindObjectsOfType<Tilemap>();
		GameObject pathGO = new GameObject();
		for(int i = 0; i < tilemaps.Length; i++) {
			if(tilemaps[i].gameObject.layer == 8) 
				pathGO = tilemaps[i].gameObject;
		}
		Physics2D.IgnoreCollision(pathGO.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
