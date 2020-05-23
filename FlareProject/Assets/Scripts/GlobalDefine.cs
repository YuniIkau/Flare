using UnityEngine;

//作成者：佐伯
//内容：共通の定義箇所
//各Managerなどの定義をここに逃がす

namespace Define
{
	/// <summary>
	/// 各シーケンスごとの読み込みを行うための定義
	/// </summary>
	public enum SequenceType
	{
		None,
		Menu,
		Battle,
	}
	public enum LoadType
	{
		None,
		Sprite,
		Sound,
	}
}
