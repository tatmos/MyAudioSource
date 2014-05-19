MyAudioSource
=============
Unity標準サウンド再生のAudioSourceをラッパーし、<br>
ADX2LEでの再生をとりあえず行う用の互換クラスです。<br>
互換のために制限があります。<br>
<br>
すべての機能を網羅してはいない。<br>
強引に変換している部分もあります。<br>
<br>
AudioClip名はキュー名。<br>
clip指定された場合、clip名のキューとして扱われます。<br>
あらかじめキューを用意しておく必要があります。<br>
<br>
キューシートは１つ。<br>
キュシートの呼び分けはしない。<br>
<br>
auido.Play()とか書いている場合は、<br>
まず、AudioSourceコンポーネントを削除して、<br>
public MyAudioSource audioSource;<br>
void Start () {<br>
		audioSource = gameObject.AddComponent<MyAudioSource>();<br>
}<br>
void Test()<br>
{<br>
  audioSource.Play();<br>
}<br>
というようにスクリプトから追加するように置き換える。<br>
<br>
This software is released under the MIT License, see LICENSE.txt.
