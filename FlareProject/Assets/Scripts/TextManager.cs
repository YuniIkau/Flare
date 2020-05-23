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
	}
}
