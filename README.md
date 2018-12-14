# Gomoku

基于C#的GUI五子棋

  - 电脑AI和单机双人对战双模式
  - 支持禁手
  - 支持随时保存/导入棋局
  - 支持随时复盘
  - 有简单直播功能


### 禁手

禁手功能默认开启，支持判断三三，四四和长连禁手


### 保存/导入棋局

菜单栏`棋局`中可以选择`导入棋局`或者`保存棋局`来实现棋局的导入和保存

棋局数据将被序列化为`json`格式进行保存，支持`.json`和`.txt`两张文件后缀


### 复盘

棋局进行到任意时刻都可以进行复盘，按下棋的时间顺序进行复盘。目前Timer设置为1s，所以下棋时间间隔小于1s的情况的时候，棋子会连续出现。


### 直播

如需要启用直播功能，请在`Config.cs`文件中配置服务器的IP或域名

服务端使用Python3编写，请用如下命令安装Python3：


```sh
sudo apt-get install python3 python3-pip
```

并安装相应依赖包`falcon`：

```sh
pip3 install falcon 
pip3 install gunicorn
```

安装完成后在`Server`路径下执行以下命令就可以了

```sh
bash run.sh
```


### 参考

[ztxz16/renju]


[在Github中打开此项目]



----

[ztxz16/renju]:<https://github.com/ztxz16/renju>
[在Github中打开此项目]:<https://github.com/HLNN/Gomoku>
