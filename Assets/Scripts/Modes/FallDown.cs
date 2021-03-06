﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FallDown : MonoBehaviour {
	public Transform[] objects;
	private float time;
	private int objectToFall;
	private bool enable;
	private Rigidbody[] rigidbodies;
	void Awake(){

	}

	// Use this for initialization
	void Start () {
		/*if(PlayerPrefs.GetInt("mode") == 1){
			this.enable = true;
			Debug.Log ("Modo de juego");
		}*/
			

		this.objectToFall = 1;
		//this.enable = true;
	}
	
	// Update is called once per frame
	void Update () {
		//if(this.enable){
			this.time += Time.deltaTime;
			// Cada 5 segundos se cae uno de los muros
			if(this.time >= 4 && this.objectToFall < this.objects.Length){
				Debug.Log (this.objects[this.objectToFall]);
				this.time = 0;
				this.objects[this.objectToFall].GetComponent<Rigidbody>().isKinematic = false;
				this.rigidbodies = this.objects[this.objectToFall].GetComponentsInChildren<Rigidbody>();
				foreach(Rigidbody rigidbody in this.rigidbodies ){
					rigidbody.isKinematic = false;
				}
				// Hay que darle un toque para que se caiga despues de quitarle el kinematic
				this.objects[this.objectToFall].GetComponent<Rigidbody>().AddForce(-transform.up * 3,ForceMode.Impulse);
				this.objectToFall++;
			}
		//}
	}
}
