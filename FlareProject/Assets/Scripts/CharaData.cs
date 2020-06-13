using UnityEngine;

//作成者：佐伯
//内容：キャラのデータクラス
//jsonから読み込んでくる
//各キャラがこのクラスを保持する

public class CharaData
{
	//攻撃力、防御力、素早さ、体力、運
	int ID;
	int LV;
	int EXP;
	int HP;
	int ATK;
	int DEF;
	int AGI;
	int LUK;

	/// <summary>
	/// 初期化
	/// </summary>
	public void Initialize()
	{
		LV = 1;
		EXP = 0;
		//以下はマスタから値を設定

	}
}
