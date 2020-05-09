using UnityEngine;

//作成者：佐伯
//内容：サウンドの管理クラス
//基本的にここがサウンド関連すべてやる
//もしくはSoundUtli見たいのを作ってそこで外部からの操作を逃がす
//Managerオブジェクトにアタッチし、SoundPlayerオブジェクトを参照している

namespace Manager
{
	public class SoundManager : ManagerBase<SoundManager>
	{
		//UnityEditor側で設定されている想定（後々変えるかも）
		public AudioSource[] m_AudioSource = null;

		public enum AudioIndex:byte
		{
			NONE = 99,
			SE_1 = 0,
			SE_2 = 1,
			SE_3 = 2,
			BGM = 3,
		}
		private void Awake ()
		{
			instance = this;
		}
		private void Start ()
		{
			//セットアップ系（使用するようになってからメソッドに分けていく）
			m_AudioSource[(int)AudioIndex.SE_1].loop = false;
			m_AudioSource[(int)AudioIndex.SE_2].loop = false;
			m_AudioSource[(int)AudioIndex.SE_3].loop = false;
			m_AudioSource[(int)AudioIndex.BGM].loop = true;
		}

		/// <summary>
		/// SEの再生
		/// </summary>
		/// <param name="index">再生するプレイヤーの選択</param>
		public void PlaySE (AudioIndex index = 0)
		{
			m_AudioSource[(int)index].Play ();
		}
		/// <summary>
		/// ループSEの作成（いる？って聞かれたら自身がない）
		/// </summary>
		/// <param name="index"></param>
		public void PlayLoopSE(AudioIndex index = 0)
		{
			m_AudioSource[(int)index].Play ();
		}
		/// <summary>
		/// BGMの再生
		/// BGMは3固定でいいかなーーー
		/// </summary>
		public void PlayBGM ()
		{
			m_AudioSource[(int)AudioIndex.BGM].Play ();
		}
	}
}
