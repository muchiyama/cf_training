---
marp: true
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
---

# front
###  クライアントサイドのソースです
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

# webApi/SoundServiceApi
###  サーバーサイドのソースです
* /SoundServiceApi
    * /Common
    共通クラスのクラスライブラリ
    * /DataAccess
    DBとのやりとりをするクラスライブラリ
    * /SoundBatch
    サーバー上のコンテンツ情報を更新するバッチ
    * /SoundServiceApi
    コンテンツ情報を返すRestApi
---

# その他
###  研修での説明資料とddl
* /ddl
テキストファイルにsqlが入っているので、コピペして使ってください

* /doc
ハンズオン資料が入ってます

