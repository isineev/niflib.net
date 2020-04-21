/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */

namespace Niflib
{
	using System;
	using System.IO;

    /// <summary>
    /// Class NiString.
    /// </summary>
    public class NiString
	{
        /// <summary>
        /// The value
        /// </summary>
        public string Value;

        /// <summary>
        /// Initializes a new instance of the NiSting class.
        /// </summary>
        /// <param name="value">String value.</param>
        public NiString(string value)
        {
            this.Value = value;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="NiString"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public NiString(NiFile file, BinaryReader reader)
		{
        	var count = reader.ReadUInt32();
        	if (count > 16384)
        		throw new NotSupportedException("String too long. Not a NIF file or unsupported format?");
        	this.Value = new string(reader.ReadChars((int)count));
		}

        /// <summary>
        /// Writes NiString to binary stream.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public void WriteNiString(BinaryWriter writer)
        {
            writer.Write((uint)this.Value.Length);
            writer.Write(this.Value.ToCharArray());
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
		{
			return this.Value;
		}
    }
}
