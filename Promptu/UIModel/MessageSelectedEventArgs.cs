using System;

namespace ZachJohnson.Promptu.UIModel
{
    internal class MessageSelectedEventArgs : EventArgs
    {
        private FeedbackMessage message;

        public MessageSelectedEventArgs(FeedbackMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            this.message = message;
        }

        public FeedbackMessage Message
        {
            get { return this.message; }
        }
    }
}
