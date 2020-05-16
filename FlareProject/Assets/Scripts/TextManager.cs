using UnityEngine;
using System.Collections.Generic;

//作成者：佐伯
//内容：ゲーム内で使用するテキストの設定

namespace Manager
{
	public class TextManager : ManagerBase<TextManager>
	{
		private Dictionary<string, string> textMaster = new Dictionary<string, string> ();
		private void Awake ()
		{
			instance = this;
			//以下に使用テキストの追加を行う（外に出したいが面倒なので後でやるかも）
			textMaster.Add ("決定系", "OK");
			textMaster.Add ("何分の何", "{0}/{1}");
		}
		public void GetText (string key, out string text)
		{
			textMaster.TryGetValue (key, out text);
		}

		//テスト、使用例
#if false
		private void Update ()
		{
			if (Input.anyKeyDown)
			{
				test ();
			}
		}
		//使用例
		void test ()
		{
			{
				//単純に呼び出しUIに貼るだけ
				//入れ物用意
				string text = string.Empty;
				//取得
				GetText ("決定系", out text);
				//uitextはUnityのTMPココンポーネントの想定
				//なので正しくはuitext.text = text になる
				var uitext = text;
				Debug.Log (uitext);
			}
			{
				//入れ物用意
				string text = string.Empty;
				//取得
				GetText ("何分の何", out text);
				var uitext = string.Format (text, 3, 4);
				Debug.Log (uitext);
			}
		}
#endif
	}
}
