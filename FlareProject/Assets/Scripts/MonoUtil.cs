using UnityEngine;

//作成者：佐伯
//内容：MonoBehaviourを継承したクラス、基本的にhierarchy上に配置する場合はこのクラスを継承する

public class MonoUtil : MonoBehaviour
{
	protected GameObject selfObj = null;
	protected Transform selfTrans = null;

	private void Awake ()
	{
		selfObj = this.gameObject;
		selfTrans = this.transform;
	}
	public GameObject GetGameObject()
	{
		return selfObj;
	}
	public Transform GetTransform()
	{
		return selfTrans;
	}

	//検証用
#if false
	private void Update ()
	{
		if (Input.GetKeyDown (KeyCode.A))
		{
			for (int i = 0; i < 60000; ++i)
			{
				bool a = this.gameObject;
				bool b = this.transform;
			}
		}
		if (Input.GetKeyDown (KeyCode.B))
		{
			for (int i = 0; i < 60000; ++i)
			{
				bool a = selfObj;
				bool b = selfTrans;
			}
		}
	}
#endif
}
