using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	BulletStatus status;
	public GameObject bullet;
	public Transform spawn;
	public float speed = 8000;

	void Start(){
		status = GetComponent<BulletStatus> ();
	}
	// Update is called once per frame(毎フレーム呼ばれる)
	void Update () {

		if(Input.GetMouseButton (0)){
			Shoot();
		}
	}
	
	void Shoot () {
		if (status.Bullet > 0){

			GameObject obj = GameObject.Instantiate(bullet)as GameObject;
			obj.transform.position = spawn.position;
			Vector3 force;
			force = this.gameObject.transform.forward * speed;
			obj.GetComponent<Rigidbody>().AddForce (force);

			status.Bullet -= 1;

			if(status.Bullet == 0){
				Invoke("charge",8);
			}
		}

	}

	void charge(){
		status.Bullet = status.MaxBullet;
	}
}