using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library.Object_Classes {
    public class Message {
        public string MessageText { get; private set; }
        public DateTime MessageDate { get; private set; }

        public Message(string messageText) {
            this.MessageText = messageText;
            this.MessageDate = DateTime.Today;
        }
        public Message(string messageText, DateTime messageDate) {
            this.MessageText = messageText;
            this.MessageDate = messageDate;
        }
    }
}
