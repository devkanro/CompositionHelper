using System;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using Windows.Security.Cryptography;
using Windows.UI;

namespace CompositionHelper.Helper
{
    public static class NumericsConvertHelper
    {
        public static float ToScalar(this String value)
        {
            return float.Parse(value);
        }

        public static Vector2 ToVector2(this String value)
        {
            var data = value.Split(',').Select(s => float.Parse(s)).ToList();
            switch (data.Count)
            {
                case 1:
                    return new Vector2(data[0], data[0]);

                case 2:
                    return new Vector2(data[0], data[1]);

                default:
                    throw new FormatException("输入值格式错误，无法转换为 Vector2。应为 \"x\" 或 \"x,y\"");
            }
        }

        public static String ToStringEx(this Vector2 value)
        {
            return $"{value.X},{value.Y}";
        }

        public static Vector3 ToVector3(this String value)
        {
            var data = value.Split(',').Select(s => float.Parse(s)).ToList();
            switch (data.Count)
            {
                case 1:
                    return new Vector3(data[0], data[0], data[0]);

                case 3:
                    return new Vector3(data[0], data[1], data[2]);

                default:
                    throw new FormatException("输入值格式错误，无法转换为 Vector3。应为 \"x\" 或 \"x,y,z\"");
            }
        }

        public static String ToStringEx(this Vector3 value)
        {
            return $"{value.X},{value.Y},{value.Z}";
        }

        public static Vector4 ToVector4(this String value)
        {
            var data = value.Split(',').Select(s => float.Parse(s)).ToList();
            switch (data.Count)
            {
                case 1:
                    return new Vector4(data[0], data[0], data[0], data[0]);

                case 2:
                    return new Vector4(data[0], data[0], data[1], data[1]);

                case 4:
                    return new Vector4(data[0], data[1], data[2], data[3]);

                default:
                    throw new FormatException("输入值格式错误，无法转换为 Vector4。应为 \"x\"，\"x,y\" 或 \"w,x,y,z\"");
            }
        }

        public static String ToStringEx(this Vector4 value)
        {
            return $"{value.X},{value.Y},{value.Z},{value.W}";
        }

        public static Matrix3x2 ToMatrix3x2(this String value)
        {
            try
            {
                var values = value.Split(';').Select(str => str.Split(',').Select(d => float.Parse(d)).ToList()).ToList();
                return new Matrix3x2(values[0][0], values[0][1],
                                     values[1][0], values[1][1],
                                     values[2][0], values[2][1]);
            }
            catch (Exception ex)
            {
                throw new FormatException("输入值格式错误，无法转换为 Matrix3x2。矩阵类型每行用 \";\" 间隔，每元素用 \",\"间隔，元素类型为 float。", ex);
            }
        }

        public static String ToStringEx(this Matrix3x2 value)
        {
            return $"{value.M11},{value.M12};{value.M21},{value.M22};{value.M31},{value.M32}";
        }

        public static Matrix4x4 ToMatrix4x4(this String value)
        {
            try
            {
                var values = value.Split(';').Select(str => str.Split(',').Select(d => float.Parse(d)).ToList()).ToList();
                return new Matrix4x4(values[0][0], values[0][1], values[0][2], values[0][3],
                                     values[1][0], values[1][1], values[1][2], values[1][3],
                                     values[2][0], values[2][1], values[2][2], values[2][3],
                                     values[3][0], values[3][1], values[3][2], values[3][3]);
            }
            catch (Exception ex)
            {
                throw new FormatException("输入值格式错误，无法转换为 Matrix4x4。矩阵类型每行用 \";\" 间隔，每元素用 \",\"间隔，元素类型为 float。", ex);
            }
        }

        public static String ToStringEx(this Matrix4x4 value)
        {
            return $"{value.M11},{value.M12},{value.M13},{value.M14};{value.M21},{value.M22},{value.M23},{value.M24};{value.M31},{value.M32},{value.M33},{value.M34};{value.M41},{value.M42},{value.M43},{value.M44}";
        }

        public static Quaternion ToQuaternion(this String value)
        {
            var data = value.Split(',').Select(s => float.Parse(s)).ToList();
            switch (data.Count)
            {
                case 1:
                    return new Quaternion(data[0], data[0], data[0], data[0]);

                case 3:
                    return new Quaternion(data[0], data[1], data[2], data[3]);

                default:
                    throw new FormatException("输入值格式错误，无法转换为 Quaternion。应为 \"x\" 或 \"x,y,z,w\"");
            }
        }

        public static String ToStringEx(this Quaternion value)
        {
            return $"{value.X},{value.Y},{value.Z},{value.W}";
        }

        /// <summary>
        /// 将 HexString 转换为 Byte 数组数据
        /// </summary>
        /// <param name="hexString">需要转换的 HexString </param>
        /// <returns>转换完成的 Byte 数组</returns>
        public static Byte[] DecodeFromHexString(String hexString)
        {
            var buff = CryptographicBuffer.DecodeFromHexString(hexString);
            Byte[] data = new Byte[buff.Length];
            CryptographicBuffer.CopyToByteArray(buff, out data);
            return data;
        }

        public static Color ToColor(this String value)
        {
            value = value.ToUpper();
            String colorString = String.Empty;
            var match = Regex.Match(value, @"#([0-9A-F]+)");
            if (match.Success)
            {
                var code = match.Groups[1].Value;
                switch (code.Length)
                {
                    case 3:
                        colorString = String.Format("FF{0}{0}{1}{1}{2}{2}", code[0], code[1], code[2]);
                        break;

                    case 4:
                        colorString = String.Format("{0}{0}{1}{1}{2}{2}{3}{3}", code[0], code[1], code[2], code[3]);
                        break;

                    case 6:
                        colorString = String.Concat("FF", code);
                        break;

                    case 8:
                        colorString = code;
                        break;
                }
            }

            if (colorString != String.Empty)
            {
                var colorData = DecodeFromHexString(colorString);
                return Color.FromArgb(colorData[0], colorData[1], colorData[2], colorData[3]);
            }
            else
            {
                throw new FormatException("ColorCode不符合规范,应该以#开头,加上3,4,6或8位的16进制颜色值(ARGB顺序).\r\n#123(#FF112233),#1234(11223344),#123456(#FF123456),#12345678(#12345678),都是合法的颜色代码格式.\r\n");
            }
        }

        public static Quaternion ToQuaternion(this Vector4 value)
        {
            return new Quaternion(value.X, value.Y, value.Z, value.W);
        }

        public static Vector4 ToVector4(this Quaternion value)
        {
            return new Vector4(value.X, value.Y, value.Z, value.W);
        }
    }
}