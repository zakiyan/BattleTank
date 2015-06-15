using UnityEngine;
using System.Collections;

public class GameSystem : MonoBehaviour {
	public EnemyStatus status;
	public GameObject player;
	public GameObject kwk38;
	public Camera main;
	public Camera ucamera;
	public GameObject uc;
	public Transform Uspawn;
	// Use this for initialization
	void Start () {
		status = GetComponent<EnemyStatus> ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void SystemChange(){
		player.GetComponent<Move>().enabled = false;
		player.GetComponent<MouseLook>().enabled = false;
		kwk38.GetComponent<BulletController>().enabled = false;

		GameObject obj = GameObject.Instantiate(uc)as GameObject;
		obj.transform.position = Uspawn.position;
		main.enabled = false;
		Instantiate (ucamera);

	}
}
