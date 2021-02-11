==============================================================================
作品名　：corocoro - racing
開発環境：Windows10 + Unity2019.3.15 + Visual Studio 2019
動作環境：Windows10
          / PCのWebブラウザー(Google Chrome / Firefox / Edge / Safari)
開発期間：2020年12月14日～2021年12月27日(14日間)
開発人数：一人
担　　当：企画、プログラム、画像作成(一部)
==============================================================================


■概要
球体がコロコロ走って、ゴールまで目指すだけのゲームです。


------------------------------------------------------------------------------
■起動方法
- Web版を以下のサイトで公開
  - https://unityroom.com/games/manbo-ga-takusann-rashii

- 手元で起動する場合、10-sugita3/CR01/
を、UnityHubのリストに追加し、起動する。

<<注意>>
unityroomに投稿したものと、
使用が少し異なる場合があります、なので、お手数おかけしますが、
その部分は個人間で調節するようにおねがいします。
------------------------------------------------------------------------------
■操作方法
- 操作方法
- 画面クリック：マウス
- 移動：十字キー
- ＜はまった場合：U＞
- スピードアップ：C
- キャラの周りを見る：V
- ブレーキ：Z

- できるだけ早くゴールに着く程、ランキングの順位が上がっていきます。


------------------------------------------------------------------------------
■プロジェクトフォルダー構成
- `CR01`フォルダー
  - Unityのプロジェクトフォルダー
  - `10-sugita3/CR01/Assets/Scenes/Title`シーンが起動用のシーン
  - 再配布が禁止されている素材は削除しています。
  ＜削除したアセットと同種類のアセットを、正確な位置に入れないとエラーが起きるため注意してください＞削除したデータの場所は後述
- APIキーを削除しているので、ネットランキングは動作しません
（ネットランキングの使用方法は後述、##組み込みアセットのライセンス　内に記載）
・README.txt
  - このファイル


------------------------------------------------------------------------------
■スクリプトファイル概要
　本ゲーム用のプログラムは`10_sugita3/CR01/Assets/Scripts`フォルダーにまとめてある。

```
|- Assets/Scripts
  |- Scripts ゲーム内のオブジェクトに影響を与えるスクリプト
    |- ClickToNextScene　クリックをして、シーンを切り替えるスクリプト
    |- FirstMove　操作キャラクターのスクリプト
    |- GameManager　ゲームの各イベントや、テキスト表示に関与するスクリプト
    |- HomeButton　ホームボタンを押したときに実行されるスクリプト
    |- TextEnabled　Titleの中で、Textの表示、非表示を操作するスクリプト
    |- TinyAudio　BGMやSE（効果音）を操作するスクリプト

その他のスクリプトは、ネットランキング（下記に記載）や、ニフクラ
（ネットランキングを使用するうえで入れる必要のあるスクリプト）
などに含まれるスクリプトです。
（音量が小さい場合は、Assets/Scripts/TinyAudio/
内にあるPlayOneShotの第二引数（数字が記入されているところ、0～1）の間で調節してください）
------------------------------------------------------------------------------
■組み込みアセットのライセンス
　以下のアセットを規約に従った上でプロジェクトに組み込んいます。

・WebGL Native Input Field https://github.com/unity3d-jp/WebGLNativeInputField/
  - ランキングの名前入力で日本語を使えるようにするために利用
The MIT License (MIT)
Copyright (c) 2016 Unity Technologies Japan
https://github.com/unity3d-jp/WebGLNativeInputField/blob/master/LICENSE

・魔王魂
  - ダミーの効果音として利用
https://maoudamashii.jokersounds.com/music_rule.html

------------------------------------------------------------------------------
■公開版で使用しているアセット
-パワーチャージ
()ダッシュの音
https://soundeffect-lab.info/sound/battle/

どんどんパフパフ
()ゴールの音
https://soundeffect-lab.info/sound/search.php?searchtext=%E3%83%91%E3%83%95%E3%83%91%E3%83%95&x=0&y=0

Cartoon FX Free
()水に落ちた時のエフェクト
https://assetstore.unity.com/packages/vfx/particles/cartoon-fx-free-109565

Future Girl written by FLASH☆BEAT
()ゲーム音
https://dova-s.jp/bgm/play13695.html

Grass Road Race
()風景・地面など
https://assetstore.unity.com/packages/3d/environments/roadways/grass-road-race-46974?locale=ja-JP

Ultimate Design　written by FLASH☆BEAT
()タイトル音
https://dova-s.jp/bgm/play13716.html

war FX
()爆発エフェクト、ダッシュエフェクト、ブレーキエフェクト
https://assetstore.unity.com/packages/vfx/particles/war-fx-5669

大勢で拍手２
()ゴールの音
http://soundeffect-lab.info/sound/search.php?searchtext=%E7%A5%9D%E3%81%84&x=0&y=0

スタジアムの完成１
()ゴールの音
https://soundeffect-lab.info/sound/voice/people.html

ドア・強く開ける
()クリック音
https://on-jin.com/sound/sei.php?bunr=%E3%83%89%E3%82%A2&kate=%E5%AE%B6%E5%85%B7%E3%83%BB%E5%BB%BA%E5%85%B7

水ドボン
()水に入ったときの音
https://soundeffect-lab.info/sound/search.php?searchtext=%E6%B0%B4&x=0&y=0

爆発2、大爆発
()オブジェクト破壊の音
https://soundeffect-lab.info/sound/battle/battle2.html

破裂/バースト音 パン/バン１
()スタート音
https://vsq.co.jp/special/se_sfx/

車のブレーキ、扇風機の弱回転、中回転、強回転
()ダッシュ中の音 ブレーキ音
https://soundeffect-lab.info/sound/machine/machine2.html

軽いパンチ１
()ぶつかったときの音
https://soundeffect-lab.info/sound/battle/

------------------------------------------------------------------------------
■公開版とプロジェクトの素材
本プロジェクトに含まれる素材のうち、再配布が禁止されているものは削除している。
また、置き換える必要のあるものは置き換えている、

＜ダミーで使用した音はすべて「魔王魂」の音源から借りています＞
＜エフェクト系に関しては、通常のエフェクトの代わりに、白いエフェクトが
出るようにしてあります＞

削除したデータ、置き換えたデータの対応は以下の通り。


パワーチャージ
（ダッシュの音で使用）
- Assets/Scenes/Game/TinyAudio/TinyAudio(Script)/Se ListのElement2
ｘダミー
チャイム01
https://maoudamashii.jokersounds.com/list/se4.html


どんどんパフパフ
（ゴールの音で使用）
- Assets/Scenes/Game/TinyAudio/TinyAudio(Script)/Se List/Element6
ｘダミー
チャイム02
https://maoudamashii.jokersounds.com/list/se4.html


Cartoon FX Free
（水に落ちた時のエフェクトで使用）
CFX2_Big_Splash
- Assets/Scene/Game/Player/First Move/Particle Sea

（ゴール時のエフェクトで使用）
CFX_MagicPoof
- Assets/Scene/Game/GameManager/GameManager(Script)/ParticleGoal


Future Girl written by FLASH☆BEAT
（ゲーム音で使用）
- Assets/Scenes/Game/TinyAudio/TinyAudio(Script)/Bgm List/Element1
xダミー
サイバー41
https://maoudamashii.jokersounds.com/list/bgm5.html


Grass Road Race
（風景・地面などで使用）
Mat_Sky
- Assets/Scenes/Game/シーンを開く
Windowを開いて、Rendering　の、　LightingSettings/Skybox Material

Track(アセットのDemoシーン内から拝借します)
- Assets/Scenes/Game/Ground/
（Trackは複数持ってくる必要があります）
（Ground内にあるCubeに合わせて配置してください）
（サイズも好みに合わせて調節してください）


Ultimate Design　written by FLASH☆BEAT
（タイトル音で使用）
- Assets/Scenes/Title/TinyAudio/AudoiSource/AudioClip
xダミー
サイバー44
http://maoudamashii.jokersounds.com/list/bgm5.html


war FX
（爆発エフェクト、ダッシュエフェクト、ブレーキエフェクトで使用）
WFX_Explosion
- Assets/Scenes/Game/Player/First Move/ParticlePrefab
WFX_FlameThrower1
- Assets/Scenes/Game/Player/First Move/ParticleDash
CFX_Poof
- Assets/Scenes/Game/Player/First Move/Particle Collider
WFX_Fire SmallFlame
- Assets/Scenes/Game/Player/First Move/Particleblaki1


大勢で拍手２
（ゴールの音で使用）
- Assets/Scenes/Game/TinyAudio/TinyAudio(Script)/Se List/Element8
ｘダミー
チャイム06
https://maoudamashii.jokersounds.com/list/se4.html


スタジアムの歓声１
（ゴールの音で使用）
- Assets/Scenes/Game/TinyAudio/TinyAudio(Script)/Se List/Element1
ｘダミー
チャイム07
https://maoudamashii.jokersounds.com/list/se4.html


ドア・強く開ける
（クリック音で使用）
- Assets/Scenes/Title/TinyAudio/TinyAudio(Script)/Se List/Element0
- Assets/Scenes/Game/TinyAudio/TinyAudio(Script)/Se List/Element0
ｘダミー
チャイム09
https://maoudamashii.jokersounds.com/list/se4.html


水ドボン
(水に入ったときの音で使用)
- Assets/Scenes/Game/TinyAudio/TinyAudio(Script)/Se List/Element14
ｘダミー
チャイム１１
https://maoudamashii.jokersounds.com/list/se4.html


爆発2
(オブジェクト破壊の音で使用)
- Assets/Scenes/Game/TinyAudio/TinyAudio(Script)/Se List/Element11
ｘダミー
チャイム13
https://maoudamashii.jokersounds.com/list/se4.html


破裂/バースト音 パン/バン１
(スタート音で使用)
- Assets/Scenes/Game/TinyAudio/TinyAudio(Script)/Se List/Element13
ｘダミー
逃げる
https://maoudamashii.jokersounds.com/list/se5.html


車のブレーキ
(ブレーキ音で使用)
- Assets/Scenes/Game/TinyAudio/TinyAudio(Script)/Se List/Element10
ｘダミー
車03
https://maoudamashii.jokersounds.com/list/se5.html


（ダッシュ中の音で使用）
扇風機の中回転
- Assets/Scenes/Game/TinyAudio/TinyAudio(Script)/Se List/Element4
ｘダミー
車06
https://maoudamashii.jokersounds.com/list/se5.html


扇風機の強回転
- Assets/Scenes/Game/TinyAudio/TinyAudio(Script)/Se List/Element5
ｘダミー
ジッパー
https://maoudamashii.jokersounds.com/list/se5.html


衝突音
- Assets/Scenes/Game/TinyAudio/TinyAudio(Script)/Se List/Element15
xダミー
システム47
https://maoudamashii.jokersounds.com/list/se6.html


公開版の素材をダウンロードして、直接該当フォルダーに上書きコピーすると公開版と同じ状態で実行可能。

------------------------------------------------------------------------------
■関連URL

------------------------------------------------------------------------------
■連絡先
- Name  : Sugita3（開発者名）
- Email : sanntatotonakai3@gmail.com
- Web   :https://sugita3.github.io/portfolio/


[EOF]
