using UnityEngine;
using System.Collections.Generic;

//作成者：佐伯
//内容：マスターの定義、Utilクラス

public class MasterData
{
	#region マスターデータのセットアップ
	/// <summary>
	/// マスターデータの初期化のエントリーポイント
	/// true:全て正常に完了
	/// false:どこかで失敗（失敗した箇所のログだし必須）
	/// </summary>
	/// <returns></returns>
	public static bool MasterDataSetup()
	{
		if(!CharaMasterSetup())
		{
			return false;
		}
		return true;
	}
	#endregion マスターデータのセットアップ

	#region キャラマスター
	private static Dictionary<int, CharaMaster> dic_CharaMaster = new Dictionary<int, CharaMaster> ();
	public class CharaMaster
	{
		int ID;
		int LV;
		int EXP;
		int HP;
		int ATK;
		int DEF;
		int AGI;
		int LUK;
	}

	/// <summary>
	/// キャラマスターの初期化
	/// true：成功
	/// false：失敗（失敗した箇所のログだし必須）
	/// 基本的にMasterDateSetupでのみ呼び出す想定のためprivateとする
	/// 今後単体でセットする必要が出た場合変更する
	/// </summary>
	/// <returns></returns>
	private static bool CharaMasterSetup()
	{

		return true;
	}

	public static CharaMaster GetCharaMaster (int id)
	{
		if (dic_CharaMaster.ContainsKey (id))
		{
			return dic_CharaMaster[id];
		}
		Debug.LogError ("キャラマスタの取得に失敗しました。");
		return null;
	}
	#endregion キャラマスター

}
