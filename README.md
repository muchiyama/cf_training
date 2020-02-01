---
marp: true

---

# サバクラApp実装研修

<!-- footer: createed by masatomo.uchiyama@jbs.com -->
![bg right 100%](https://livedoor.blogimg.jp/kita_asu/imgs/f/3/f3798470.png)

---

# 自己紹介
### かる～く自己紹介

- 名前: うちやま
2年目エンジニアです

- 趣味: 音楽
ギターもちょろっと弾きます
軽音部はいっとります

- 言語: C#
勉強中
まだちゃんと書けません

![bg right 100%](https://pbs.twimg.com/media/CKm3tfvUwAA1XBT.png)

---

# Directory構成
###  Rootのディレクトリ構成
* front
    クライアントサイドのソースコード
* webApi
    サーバーサイドのソースコード
* doc
    研修にて使用する資料
* ddl
    DB作成の為のDDL
![bg right 70%](https://stickershop.line-scdn.net/stickershop/v1/product/1448302/LINEStorePC/main.png;compress=true)
---

#  クライアントサイドのソースです
### front
* /front
    * /assert
画像ファイルや音楽ファイルを置くためのディレクトリ
    * /conf
    使用ライブラリに読ませるための定義ファイルが入ってます
    * /modules
    使用ライブラリのソースが入ってます
    * /src
    ソースコードが入ってます
    * /template
    ライブラリが使用するhtmlのテンプレートファイルが入ってます
---

#  サーバーサイドのソースです
### webApi/SoundServiceApi
* /SoundServiceApi
    * /Common
    共通クラスのクラスライブラリ
    * /DataAccess
    DBとのやりとりをするクラスライブラリ
    * /SoundBatch
    サーバー上のコンテンツ情報を更新するバッチ
    * /SoundServiceApi
    コンテンツ情報を返すRestApi

<!-- ![bg right 70%](https://blog-imgs-55.fc2.com/m/i/y/miyamoseminar5/By-H5wGCcAAy7-q.png) -->


---

# その他
###  研修での説明資料とddl

* /ddl
ddlコピペして使ってください

* /doc
ハンズオン資料
概要 / フロント(モック編) / サーバーサイド / API疎通と4セクションです

[gitリンク(privateだけど)](https://github.com/muchiyama/cf_training)

以上:exclamation:
![bg right 70%](https://pbs.twimg.com/profile_images/1109130191220011009/deItWDi7_400x400.jpg)
