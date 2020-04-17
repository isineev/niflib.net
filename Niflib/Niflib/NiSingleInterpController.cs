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
    /// Class NiSingleInterpController.
    /// </summary>
    public class NiSingleInterpController : NiInterpController
	{
        /// <summary>
        /// The interpolator
        /// </summary>
        public NiRef<NiInterpolator> Interpolator;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiSingleInterpController"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public NiSingleInterpController(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version >= eNifVersion.VER_10_2_0_0)
			{
				this.Interpolator = new NiRef<NiInterpolator>(reader);
			}
		}
	}
}
