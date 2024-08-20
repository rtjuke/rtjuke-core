using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Plugins.Communication
{
    /// <summary>
    /// message bus to exchange messages between plugin host and plugins
    /// </summary>
    public interface IMessageBus
    {
        /// <summary>
        /// Send a message to the message bus
        /// </summary>
        /// <param name="message"></param>
        /// <returns>true if the message has been handled</returns>
        Task<bool> PublishAsync(IPluginMessage message);

        /// <summary>
        /// Publish a request and return the reponse message
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<T> PublishRequestAsync<T>(RequestMessage<T> request)
            where T : ResponseMessage;

        /// <summary>
        /// Register a handler for a message type
        /// </summary>
        /// <param name="handler"></param>
        void Register(IPlugin owner, Guid id, Action<IPluginMessage> handler);

        void Register<T>(IPlugin owner, Action<T> handler)
            where T : IPluginMessage;

        /// <summary>
        /// Deregister a handler for a message type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler"></param>
        void Deregister(IPlugin owner, Guid? id, Action<IPluginMessage> handler);

        void Deregister<T>(IPlugin owner, Action<T> handler)
            where T : IPluginMessage;
    }
}
