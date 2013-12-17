Yahoo! KeyKey
===
[Yahoo! Keykey](http://tw.media.yahoo.com/keykey/) is a customized Chinese input methods tool based on an open source project [Openvanilla](http://openvanilla.org/). Yahoo! had decided to make Yahoo! Keykey as a open source projecet and under new BSD licene.

Some external dependency information are list here:

1. SinicaCorpus: You could reach http://www.sinica.edu.tw/ for the license.
2. BPMFMappings was created based on SinicaCorpus.
3. YahooSearchTerms: You could grabe hot keyword from http://tw.yahoo.com.
4. sqlite-cerod-see: Commerical SQLite Compressed and Encrypted Read-Only Database (CEROD) Extension, please check http://www.hwaci.com/sw/sqlite/cerod.html
5. DotMacKit.framework and PackageMaker.app: You can get it from Apple development kit.
6. CTGradient is licensed under http://creativecommons.org/licenses/by/2.5/ .

Installation on Windows
===

1. 用 Visual Studio 開啟 Takao.sln 然後編完
2. 進入 Visual Studio command line tool，然後執行以下指令

   ```
   cd [project root]\Distributions\Takao\Installer-Windows
   makesetup
   ```
3. 完成的新版 Windows installer 就會放在同一個目錄中，檔名為
   `YahooKeyKey-Windows-VERSION-zh-TW.exe`
4. 將 VERSION 部分更改為正確檔名
5. Windows 版本完成，請拷貝至一個集中目錄中

Installation on OSX Leopard/Tiger
===

1. 回到 OS X 機器上，進到以下目錄執行以下指令：

   ```
   cd ./Distributions/Takao/Installer-OSX-IMK
   perl makedmg.pl
   cd ./Distributions/Takao/Installer-OSX-TSM
   perl makedmg.pl
   ```
2. 編好的檔案會放在 `./build/Release` 中，有兩個 `.dmg` 檔，版號已經編好，格式為：
   `YahooKeyKey-OSX-{Leopard|Tiger}-x.y.zzzz.dmg`
3. 將兩個 .dmg 檔拷貝至集中目錄中
