using UnityEngine;

//作成者：佐伯
//内容：各Managerクラスの親クラス

public class ManagerBase<Type> : MonoUtil where Type : MonoUtil
{
	public static Type instance = null;
}
