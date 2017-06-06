using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyType{
	smallEnemy,
	normalEnemy,
	bigEnemy
	}

public class Enemy : MonoBehaviour {
	public int hp = 1;

	public float speed=2;

	public int score=100;

	public EnemyType type=EnemyType.smallEnemy;

	public bool isDeath = false;

	public Sprite[] explosionSprite;

	private float timer = 0;

	public int explosionAnimationFrame=10;

	private SpriteRenderer render;

	public float hitTimer = 0.2f;
	private float resetHitTime;

	public Sprite[] hitSpirites;

	// Use this for initialization
	void Start () {
		render = this.GetComponent<SpriteRenderer>();

		resetHitTime = hitTimer;
		hitTimer = 0;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.Translate (Vector3.down*speed*Time.deltaTime);
		if (this.transform.position.y<-6f) 
		{
			Destroy (this.gameObject);
		}
		if (isDeath) {
			
				
			
			timer += Time.deltaTime;
			int frameIndex = (int)(timer / (1f / explosionAnimationFrame));
			if (frameIndex >= explosionSprite.Length) {
				Destroy (this.gameObject);
				
			} else
				render.sprite = explosionSprite [frameIndex];
			
		} else {if	(type==EnemyType.normalEnemy||type==EnemyType.bigEnemy){
			if (hitTimer>=0) {
				hitTimer -= Time.deltaTime;
				int frameindex = (int) ((resetHitTime - hitTimer) / (1f / explosionAnimationFrame));
				frameindex %= 2;
				render.sprite = hitSpirites [frameindex];
				}}
		}	
	}
	public void BeHit()
	{	hp -= 1;
		
			
		if (hp <= 0) {
			isDeath = true;
		} else {
			hitTimer = resetHitTime;
		
		}

	}
}
