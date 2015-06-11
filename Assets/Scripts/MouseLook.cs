using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
	
	public Texture2D crosshairImage;
	public Transform BodyBone;                  //BODYのBONEを指定
	public Transform TargetObject;              //MouseTraget(位置要調整）
	public Ray ray;                             //Ray
	public Camera TPCamera;                    //Mainカメラ
	private Vector3 LookAtPos;
	private float xMin;
	private float yMin;
	private float RotationX;                //TargetObjectの回転
	private float RotationY;                //TargetObjectの回転
	private float RotationZ;                //TargetObjectの回転
	private LayerMask layerMask;
	
	void Start () {
		
		//LayerMask Player 以外のすべてを判定
		layerMask = 1 << LayerMask.NameToLayer("Player");
		layerMask =~ layerMask; //反転
		//TargetObject
		TargetObject = TargetObject.GetComponent<Transform> ();
		//Bodybone
		BodyBone = BodyBone.GetComponent<Transform> ();
		
		Cursor.lockState = CursorLockMode.Confined; //はみ出さないモード
		Debug.Log("DEBUG:Cursor is confined");
		Cursor.visible = false; //OSカーソル非表示
		
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))   //ESCでマウスカーソル表示
		{
			Cursor.lockState = CursorLockMode.None; //標準モード
			Debug.Log("DEBUG:Cursor is normal");
			Cursor.visible = true; //OSカーソル表示        
		}
	}
	
	void FixedUpdate () {
		
	}
	
	void LateUpdate ()
	{
		//Raycast output storage variable
		RaycastHit hit;
		
		//Raycast at mouse position
		ray = TPCamera.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 300.0f, layerMask))
		{
			LookAtPos = hit.point;      //Player以外のObjectを見つけた時
		}
		else
		{
			LookAtPos = ray.GetPoint(300f);     //何もないとき
		}
		// Bodyと腕をマウスターゲットと連動
		if (Input.GetMouseButton (1)) 
		{
		}else{
			TargetObject.LookAt(LookAtPos);         //ダミーターゲットをLookAT
			RotationX = TargetObject.eulerAngles.x;
			RotationY = TargetObject.eulerAngles.y;
			RotationZ = TargetObject.eulerAngles.z;
			BodyBone.eulerAngles = new Vector3(RotationX, RotationY, RotationZ);    //Body回転
		}

	}
	
	void OnGUI() //crosshair
	{
		xMin = Screen.width - (Screen.width - Input.mousePosition.x) - (crosshairImage.width / 2);
		yMin = (Screen.height - Input.mousePosition.y) - (crosshairImage.height / 2);
		GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
	}
}