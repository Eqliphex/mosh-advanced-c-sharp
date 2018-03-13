using System;

namespace EventsAndDelegates
{
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e) // Implements the delegate defined in VideoEncoder
        {
            Console.WriteLine("MailService: Sending an email..." + e.Video.Title);
        }
    }
}
