using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Invoke("BulletDestroy",2);
	}

	void OnCollisionEnter(){
		BulletDestroy ();
//		print ("hello");
	}

	void BulletDestroy(){
		Destroy(gameObject);
	}
}
