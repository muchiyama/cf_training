---
marp: true

---
<!-- page_number: true -->

# サバクラApp実装研修
### サウンドプレーヤーアプリです
![bg right 100%](https://github.com/muchiyama/cf_training/blob/master/other/すっくしょ.png)


---

# 自己紹介
### かる～く自己紹介

- 名前: うてやま
    - 年次:
    2年目エンジニアです

    - 趣味:
    音楽好きですギターもちょろっと弾きます
    軽音部はいっとります

    - 言語:
    C#を勉強中

![bg right 100%](https://pbs.twimg.com/media/CKm3tfvUwAA1XBT.png)

---

# Directory構成
###  Rootのディレクトリ構成
- root/
    - front:
    クライアントサイド
    - webApi:
    サーバーサイド
    - doc:
    研修にて使用する資料
    - ddl:
    DB作成の為のDDL

![bg right 100%](https://stickershop.line-scdn.net/stickershop/v1/product/1448302/LINEStorePC/main.png;compress=true)


---

#  クライアントサイドのソースです
### front
- /front
    - /assert:
画像ファイルや音楽ファイルを置くためのディレクトリ
    - /modules:
    ライブラリのソースが入ってます
    - /src:
    ソースコードが入ってます
    - /template:
    htmlのテンプレートファイルが入ってます

---

#  サーバーサイドのソースです
### webApi/SoundServiceApi
- /SoundServiceApi
    - /Common:
    共通クラスのクラスライブラリ
    - /DataAccess:
    DBとのやりとりをするクラスライブラリ
    - /SoundBatch:
    サーバー上のコンテンツ情報を更新するバッチ
    - /SoundServiceApi:
    コンテンツ情報を返すRestApi

---

# その他
###  研修での説明資料とddl
- /
    - /ddl:
    ddlコピペして使ってください

    - /doc:
    ハンズオン資料
    概要 / フロント(モック編) / サーバーサイド / API疎通と4セクションです
![bg right 100%](https://www.omg-ox.org/wp-content/uploads/2018/05/20160808195558-1.png)
<!-- ![bg right 70%](https://static.comic-walker.com/sp/uploadimage/characters/2252.jpg) -->


---
# おーしまい


![bg right 70%](https://pbs.twimg.com/profile_images/1109130191220011009/deItWDi7_400x400.jpg)
[gitリンク(privateだけど)](https://github.com/muchiyama/cf_training)


