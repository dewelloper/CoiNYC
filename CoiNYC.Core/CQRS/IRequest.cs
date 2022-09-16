using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Core.CQRS
{
    public interface IRequest : IRequest<Unit> { }

    /// <summary>
    /// Marker interface to represent an asynchronous request with a void response
    /// </summary>
    public interface IAsyncRequest : IAsyncRequest<Unit>{ }

    /// <summary>
    /// Marker interface to represent a request with a response
    /// </summary>
    /// <typeparam name="TResponse">Response type</typeparam>
    public interface IRequest<out TResponse>{ }

    /// <summary>
    /// Marker interface to represent an asynchronous request with a response
    /// </summary>
    /// <typeparam name="TResponse">Response type</typeparam>
    public interface IAsyncRequest<out TResponse> { }

    /// <summary>
    /// Marker interface to represent a notification
    /// </summary>
    public interface INotification { }

    /// <summary>
    /// Marker interface to represent an asynchronous notification
    /// </summary>
    public interface IAsyncNotification  { }

    public interface ICount<TResponse>
    {
        int Count { get; }
    }

    public class ItemCount<TResponse> : ICount<TResponse>
    {
        public int Count { get; set; }
    }

}
