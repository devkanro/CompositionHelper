using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionHelper.Effects
{
    /// <summary>
    /// 特效重绘等级。
    /// </summary>
    [Flags]
    public enum EffectRedrawLevel
    {
        /// <summary>
        /// 无需重绘。
        /// </summary>
        NoRequest,
        /// <summary>
        /// 仅需要重定位特效。
        /// </summary>
        Offset = 0x01,
        /// <summary>
        /// 仅需要重绘内容。
        /// </summary>
        Content = 0x02,
        /// <summary>
        /// 全部请求重绘。
        /// </summary>
        All = Offset | Content
    }
}
