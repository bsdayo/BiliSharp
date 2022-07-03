<div align="center">

# BiliSharp

哔哩哔哩 API 的实用包装

</div>

## 特性
- 视频操作
  - 基本信息
  - 点赞/投币/收藏
  - 一键三连

更多功能正在开发中...

## 示例

查询视频 av810872 的信息

```csharp
using BiliSharp;
using BiliSharp.Models;

// 使用 av 号初始化视频实例
var video = new BiliVideo(810872);

Console.WriteLine($"BV号：{video.BvId}");

// 获取视频信息
var info = video.GetInfo();

Console.WriteLine($"标题：{info.Title}");
Console.WriteLine($"UP：{info.Owner.Name}");
Console.WriteLine($"简介：{info.Description}");
```

输出：
```text
BV号：BV1Js411o76u
标题：【炮姐/AMV】我永远都会守护在你的身边！
UP：暗猫の祝福
简介：自制 本人的第二个AMV作品，从妹妹篇结束后便开始构思了，具体九月开始挖的坑，于2013年10月26日完稿。
顺便联动一下我的魔禁/超炮AMV：av4545451
记得让弹幕多样化一些噢~喜欢的话点个关注，大感谢~
```

三连视频：  
首先[获取认证信息](./docs/GetCredential.md)，
```csharp
var credential = new BiliCredential
{
    SessData = "<SESSDATA 值>",
    BiliJct = "<bili_jct> 值",
    Buvid3 = "<buvid3 值>",
};

var video = new BiliVideo(170001, credential);

video.SetTriple();
```

## 许可证
本项目遵循 [MIT 许可证](./LICENSE)开源，欢迎参与贡献。
