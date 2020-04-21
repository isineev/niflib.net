namespace Niflib
{
    #if OpenTK
    using OpenTK;
    using OpenTK.Graphics;
    using Matrix = OpenTK.Matrix4;
    using Color3 = OpenTK.Graphics.Color4;
    #elif SharpDX
	using SharpDX;
    #elif MonoGame
	using Microsoft.Xna.Framework;
	using Color3 = Microsoft.Xna.Framework.Color;
	using Color4 = Microsoft.Xna.Framework.Color;
    #endif
    using System;
    using System.IO;

    /// <summary>
    /// Class WriterExtensions.
    /// </summary>
    public static class WriterExtensions
    {
        /// <summary>
        /// Write a Boolean from the Stream Depending on Nif Version
        /// </summary>
        /// <param name="writer">Writer</param>
        /// <param name="version">Nif Object Version</param>
        /// <param name="value">Bool value to write.</param>
        public static void WriteBoolean(this BinaryWriter writer, bool value, eNifVersion version)
        {
            if (version < eNifVersion.VER_4_1_0_1)
                writer.Write(Convert.ToUInt32(value));
            else writer.Write(value);
        }

        /// <summary>
        /// Writes the float array.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="array">Float array to write.</param>
        public static void WriteFloatArray(this BinaryWriter writer, float[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                writer.Write(array[i]);
            }
        }

        /// <summary>
        /// Writes the uint32 array.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="array">Uint32 array to write.</param>
        public static void WriteUInt32Array(this BinaryWriter writer, uint[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                writer.Write(array[i]);
            }
        }

        /// <summary>
        /// Writes the uint16 array.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="array">UInt16 array to write.</param>
        public static void WriteUInt16Array(this BinaryWriter writer, ushort[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                writer.Write(array[i]);
            }
        }

        /// <summary>
        /// Writes the vector2.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">Vector2 value to write.</param>
        public static void WriteVector2(this BinaryWriter writer, Vector2 value)
        {
            writer.Write(value.X);
            writer.Write(value.Y);
        }

        /// <summary>
        /// Writes the vector3.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">Vector3 value to write.</param>
        public static void WriteVector3(this BinaryWriter writer, Vector3 value)
        {
            writer.Write(value.X);
            writer.Write(value.Y);
            writer.Write(value.Z);
        }

        /// <summary>
        /// Writes the vector4.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">Vector4 value to write.</param>
        public static void WriteVector4(this BinaryWriter writer, Vector4 value)
        {
            writer.Write(value.X);
            writer.Write(value.Y);
            writer.Write(value.Z);
            writer.Write(value.W);
        }

        /// <summary>
        /// Writes the color3.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">Color3 value to write.</param>
        public static void WriteColor3(this BinaryWriter writer, Color3 value)
        {
            writer.Write(value.R);
            writer.Write(value.G);
            writer.Write(value.B);
        }

        /// <summary>
        /// Writes the color4.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">Color4 value to write.</param>
        public static void WriteColor4(this BinaryWriter writer, Color4 value)
        {
            writer.Write(value.R);
            writer.Write(value.G);
            writer.Write(value.B);
            writer.Write(value.A);
        }

        /// <summary>
        /// Writes the color4 byte.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">Color4 value to write.</param>
        public static void WriteColor4Byte(this BinaryWriter writer, Color4 value)
        {
            writer.Write((byte)(value.R * 255));
            writer.Write((byte)(value.G * 255));
            writer.Write((byte)(value.B * 255));
            writer.Write((byte)(value.A * 255));
        }

        /// <summary>
        /// Writes the matrix33.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">Matrix value to write.</param>
        public static void WriteMatrix33(this BinaryWriter writer, Matrix value)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    writer.Write(value[i,j]);
                }
            }
        }
    }
}
