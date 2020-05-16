using System;
using System.Collections;
using UnityEngine;

//作成者：
//内容：

namespace Manager
{
	public class ResourceManager : ManagerBase<ResourceManager>
	{
		private void Awake ()
		{
			instance = this;
		}

		/// <summary>
		/// 直接読み込み
		/// </summary>
		/// <param name="name"></param>
		/// <param name="loadType"></param>
		/// <returns></returns>
		public (Sprite, AudioClip) Load (string name, Define.LoadType loadType)
		{
			switch(loadType)
			{
				case Define.LoadType.Sprite:
					return (Resources.Load ("name") as Sprite, null);
				case Define.LoadType.Sound:
					return (null, Resources.Load ("name") as AudioClip);
			}
			return (null, null);
			
		}
		public void SoundLoadAsync (string name, SoundManager.AudioIndex audioIndex)
		{
			StartCoroutine (InnerSoundLoadAsync (name, audioIndex));
		}
		private IEnumerator InnerSoundLoadAsync (string name, SoundManager.AudioIndex audioIndex)
		{
			ResourceRequest request = Resources.LoadAsync (name);
			while (!request.isDone)
			{
				yield return null;
			}
			SoundManager.instance.SetAudio (audioIndex, request.asset as AudioClip);
			yield break;
		}


	}
}
