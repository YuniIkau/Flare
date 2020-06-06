﻿using UnityEngine;

//作成者：佐伯
//内容：キャラのデータクラス
//jsonから読み込んでくる
//各キャラがこのクラスを保持する

public class CharaDate
{
	//攻撃力、防御力、素早さ、体力、運
	int ID;
	int Lv;
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
		Lv = 1;
		EXP = 0;
		//以下はマスタから値を設定

	}
}