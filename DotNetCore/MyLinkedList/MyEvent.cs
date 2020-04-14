using System;
using System.Collections.Generic;
using System.Text;

namespace ClrViaDotNet
{
    class MyEvent
    {
        //public event EventHandler<NewMailEventArgs> NewMail;

        //// 1. A PRIVATE delegate field that is initialized to null
        //private EventHandler<NewMailEventArgs> NewMail = null;
        //// 2. A PUBLIC add_Xxx method (where Xxx is the Event name) Allows methods to register interest in the event.
        //public void add_NewMail(EventHandler<NewMailEventArgs> value)
        //{
        //    // The loop and the call to CompareExchange is all just a fancy way of adding a delegate to the event in a thread-safe way
        //    EventHandler<NewMailEventArgs> prevHandler;
        //    EventHandler<NewMailEventArgs> newMail = this.NewMail;
        //    do
        //    {
        //        prevHandler = newMail;
        //        var newHandler = (EventHandler<NewMailEventArgs>)Delegate.Combine(prevHandler, value);
        //        newMail = Interlocked.CompareExchange<EventHandler<NewMailEventArgs>>(ref this.NewMail, newHandler, prevHandler);
        //    } while (newMail != prevHandler);
        //}
        //// 3. A PUBLIC remove_Xxx method (where Xxx is the Event name) Allows methods to unregister interest in the event.
        //public void remove_NewMail(EventHandler<NewMailEventArgs> value)
        //{
        //    // The loop and the call to CompareExchange is all just a fancy way of removing a delegate from the event in a thread-safe way
        //    EventHandler<NewMailEventArgs> prevHandler;
        //    EventHandler<NewMailEventArgs> newMail = this.NewMail;
        //    do
        //    {
        //        prevHandler = newMail;
        //        var newHandler = (EventHandler<NewMailEventArgs>)Delegate.Remove(prevHandler, value);
        //        newMail = Interlocked.CompareExchange<EventHandler<NewMailEventArgs>>(ref this.NewMail, newHandler, prevHandler);
        //    } while (newMail != prevHandler);
        //}
    }
}
