namespace BiliSharp.Models.Video;

public enum BiliVideoState
{
    /// <summary>
    ///     橙色通过
    /// </summary>
    Passed = 1,

    /// <summary>
    ///     开放浏览
    /// </summary>
    Open = 0,

    /// <summary>
    ///     待审
    /// </summary>
    Pending = -1,

    /// <summary>
    ///     打回
    /// </summary>
    Returned = -2,

    /// <summary>
    ///     网警锁定
    /// </summary>
    PoliceLocked = -3,

    /// <summary>
    ///     被锁定（视频撞车了）
    /// </summary>
    Locked = -4,

    /// <summary>
    ///     管理员锁定
    /// </summary>
    AdminLocked = -5,

    /// <summary>
    ///     修复待审
    /// </summary>
    FixedPending = -6,

    /// <summary>
    ///     暂缓审核
    /// </summary>
    SuspendedPending = -7,

    /// <summary>
    ///     补档待审
    /// </summary>
    AdjustedPending = -8,

    /// <summary>
    ///     等待转码
    /// </summary>
    Transcoding = -9,

    /// <summary>
    ///     延迟审核
    /// </summary>
    DelayedPending = -10,

    /// <summary>
    ///     视频源待修
    /// </summary>
    NeedSourceFixed = -11,

    /// <summary>
    ///     转储失败
    /// </summary>
    DumpFailed = -12,

    /// <summary>
    ///     允许评论待审
    /// </summary>
    CommentAllowedPending = -13,

    /// <summary>
    ///     临时回收站
    /// </summary>
    TemporaryRecycled = -14,

    /// <summary>
    ///     分发中
    /// </summary>
    Distributing = -15,

    /// <summary>
    ///     转码失败
    /// </summary>
    TranscodingFailed = -16,

    /// <summary>
    ///     创建未提交
    /// </summary>
    NotSubmitted = -20,

    /// <summary>
    ///     创建已提交
    /// </summary>
    Submitted = -30,

    /// <summary>
    ///     定时发布
    /// </summary>
    ScheduledPublish = -40,

    /// <summary>
    ///     用户删除
    /// </summary>
    UserDeleted = -100
}