using UnityEngine;
using System.Collections;
#if UNITY_WEBPLAYER
public class MyAudioSource : MonoBehaviour
{	
	private AudioSource _Mysource;
	public void Awake()
	{
		if(_Mysource == null){
			_Mysource = gameObject.AddComponent<AudioSource>();			
			source.rolloffMode = AudioRolloffMode.Linear;	//3Dポジション時に音が小さくなるのを軽減
		}
	}	
	public AudioSource source 
	{
		get
		{
			return _Mysource;
		}
	}	
	public AudioClip clip{
		get{return _Mysource.clip;}
		set{_Mysource.clip = value;}
	}
	public bool isPlaying
	{
		get
		{
			return _Mysource.isPlaying;
		}
	}
	public float timeSamples
	{
		get
		{
			return _Mysource.timeSamples;
		}
	}
	public float pitch
	{
		get
		{
			return  _Mysource.pitch;
		}
		set
		{
			_Mysource.pitch = value;
		}
	}
	public void Play()
	{
		_Mysource.Play();
	}
	public void Stop()
	{
		_Mysource.Stop();
	}
	public bool loop
	{
		get{return _Mysource.loop;}
		set{ _Mysource.loop = value;}
	}
	
}
#else
public class MyAudioSource : MonoBehaviour
	{	
		private CriAtomSource _Mysource;
		public void Awake()
		{
			if(_Mysource == null){
				_Mysource = gameObject.AddComponent<CriAtomSource>();			
			}
		}	
		public CriAtomSource source { 
			get
			{
				return _Mysource;
			}
		}
		public AudioClip clip{
			set
			{
				_Mysource.cueName = value.name;
			}
			//#if UNITY_WEBPLAYER
			//	if(audioSource.clip.name != clip.name) 
			//#else
			//	if(audioSource.cueName != clip.name) 
			//#endif
		}
		public bool isPlaying
		{
			get
			{
				if(_Mysource.status == CriAtomSource.Status.Playing)return true;
				return false;
			}
		}
		public float timeSamples
		{
			get
			{
				return _Mysource.time / 1000.0f * 44100f;
			}
		}
		public float pitch
		{
			get
			{
				return  Mathf.Pow(2,_Mysource.pitch/1200.0f);
			}
			set
			{
				_Mysource.pitch = 1200.0f*Mathf.Log(value)/Mathf.Log(2.0f);
			}
		}
		public void Play()
		{
			_Mysource.Play();
		}
		public void Stop()
		{
			_Mysource.Stop();
		}
		public string cueName
		{
			get{return _Mysource.cueName;}
			set{ _Mysource.cueName = value;}
		}
		public bool loop
		{
			get{return _Mysource.loop;}
			set{ _Mysource.loop = value;}
		}
	}

#endif		
