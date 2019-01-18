// <copyright file="IPasvPortPool.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <copyright file="IPasvPortPool.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <copyright file="IPasvPortPool.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System.Threading.Tasks;

namespace FubarDev.FtpServer
{
    public interface IPasvPortPool
    {
        /// <summary>
        /// Return a random free passive port.
        /// </summary>
        /// <param name="port">If set to != 0, get this specific port, not the next free one</param>
        /// <returns>A free port, or 0 if any port can be chosen, or -1 if there is no free port</returns>
        Task<int> LeasePasvPort(int port = 0);

        /// <summary>
        /// Return the port to the pool of available ports.
        /// </summary>
        /// <param name="port"></param>
        Task ReturnPasvPort(int port);
    }
}