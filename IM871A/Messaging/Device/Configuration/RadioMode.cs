// <copyright file="RadioMode.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FosterBuster.IM871A.Messaging.Device.Configuration
{
    /// <summary>
    /// Indicates which radio mode the device is operating in.
    /// </summary>
    public enum RadioMode : byte
    {
        /// <summary>
        /// Transmit only; transmits a number of times per day to a stationary receiving point. Transmits in the 1 % duty cycle frequency band. Due to long header, it is suitable also for battery economised receiver.
        /// </summary>
        S1 = 0x00,

        /// <summary>
        /// Transmit only; transmits with a duty cycle limitation of 0,02 % per hour to a mobile or stationary receiving point. Transmits in the 1 % duty cycle frequency band. Requires a continuously enabled receiver.
        /// </summary>
        S1m = 0x01,

        /// <summary>
        /// Meter unit with a receiver either continuously enabled or synchronised requiring no extended preamble for wakeup. Also usable for node transponders or concentrators. A long header is optional.
        /// </summary>
        S2 = 0x02,

        /// <summary>
        /// Transmit only with short data bursts typically 3 ms to 8 ms every few seconds, operates in the 0,1 % duty cycle frequency band.
        /// </summary>
        T1 = 0x03,

        /// <summary>
        /// Meter unit transmits on a regular basis like Type T1 and its receiver is enabled for a short period after the end of each transmission and locks on, if an acknowledge (at 32,768 kcps) is received.
        /// Further bidirectional communication in the 0,1 %-frequency band using 100 kcps (meter transmit) and 32,768 kcps (meter receive) may follow.
        /// Note that the communication from the meter to the "other" component uses the physical layer of the T1 mode, while the physical layer parameters for the reverse direction are identical to the S2-mode.
        /// </summary>
        T2 = 0x04,

        /// <summary>
        /// Meter receiver with possible battery economiser, requiring extended preamble for wake-up. Optionally, it may have up to 10 frequency channels with a high precision frequency division multiplexing.
        /// Meter response with 4,8 kcps wake-up followed by a 4,8 kcps header.
        /// </summary>
        R2 = 0x05,

        /// <summary>
        /// Frame format A. Transmit only, on a regular basis, with short data bursts < 22 ms, operates in the 0,1 % duty cycle frequency band.
        /// </summary>
        C1FormatA = 0x06,

        /// <summary>
        /// Frame format B. Transmit only, on a regular basis, with short data bursts < 22 ms, operates in the 0,1 % duty cycle frequency band.
        /// </summary>
        C1FormatB = 0x07,

        /// <summary>
        /// Frame Format A. Meter unit transmits on a regular basis like Type C1 and its receiver is enabled for a short period after the end of each transmission and locks on if a proper preamble and synchronisation word is detected. Data frames received by the meter are used for protocol updates and commands.
        /// </summary>
        C2FormatA = 0x08,

        /// <summary>
        /// Frame Format B. Meter unit transmits on a regular basis like Type C1 and its receiver is enabled for a short period after the end of each transmission and locks on if a proper preamble and synchronisation word is detected. Data frames received by the meter are used for protocol updates and commands.
        /// </summary>
        C2FormatB = 0x09,
    }
}