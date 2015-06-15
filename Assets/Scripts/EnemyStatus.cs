using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour {
	GameSystem gamesystem;

	public int hp = 400;
	public int maxhp = 400;

	void Start(){
		gamesystem = FindObjectOfType<GameSystem> ();
	}

	void Update () {

	}

	void OnCollisionEnter(Collision c){
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		if (layerName != "Bullet") return;
		hp -= 1;
		if (hp == 0) {
			gamesystem.SystemChange();
		}
	}
}
