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
		/// 直接読み込み(ほぼ使わない想定)
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

#region 各シーケンス開始時の初期ロード
		public void SequenceTypeLoad(Define.SequenceType sequenceType)
		{
			//=ロード処理準備=
			//キャッシュを全て消す
			SoundManager.instance.CacheClear ();

			//=ロード処理開始=
			string path = string.Empty;
			switch (sequenceType)
			{
				case Define.SequenceType.Menu:
					path = "Menu/";
					break;
				case Define.SequenceType.Battle:
					path = "Battle/";
					break;
			}
			SequenceSoundLoad (string.Format ("{0}Sound", path));
			//SequenceSoundLoad (string.Format ("{0}Sprite", path));
		}
		private void SequenceSoundLoad(string path)
		{
			var temp = Resources.LoadAll<AudioClip> (path);
			for(int i = 0;i<temp.Length;++i)
			{
				SoundManager.instance.AddCacheAudio (temp[i]);
			}
		}
#endregion 各シーケンス開始時の初期ロード

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
			//キャッシュされていなければキャッシュする
			SoundManager.instance.AddCacheAudio (request.asset as AudioClip);
			SoundManager.instance.SetAudio (audioIndex, request.asset as AudioClip);
			yield break;
		}
	}
}
