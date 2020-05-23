using UnityEngine;

//作成者：佐伯
//内容：テスト用コード置き場

public class Test : MonoUtil
{

	void Start()
	{

	}
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.A))
		{
			Manager.ResourceManager.instance.SequenceTypeLoad (Define.SequenceType.Menu);
		}
		if(Input.GetKeyDown (KeyCode.S))
		{
			Manager.SoundManager.instance.SetAudio (Manager.SoundManager.AudioIndex.SE_1, "SE1");
			Manager.SoundManager.instance.PlaySE (Manager.SoundManager.AudioIndex.SE_1);
		}
		if (Input.GetKeyDown (KeyCode.D))
		{
			{
				//単純に呼び出しUIに貼るだけ
				//入れ物用意
				string text = string.Empty;
				//取得
				Manager.TextManager.instance.GetText ("決定系", out text);
				//uitextはUnityのTMPココンポーネントの想定
				//なので正しくはuitext.text = text になる
				var uitext = text;
				Debug.Log (uitext);
			}
			{
				//入れ物用意
				string text = string.Empty;
				//取得
				Manager.TextManager.instance.GetText ("何分の何", out text);
				var uitext = string.Format (text, 3, 4);
				Debug.Log (uitext);
			}
		}
	}
}
