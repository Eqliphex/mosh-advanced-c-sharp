using System;
using System.Threading;

namespace EventsAndDelegates
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }

    public class VideoEncoder
    {
        // To publish event:
        // 1) Define a delegate, contract between subscriber and publisher
        // 2) Define event based on the delegate
        // 3) Raise the event

        // 1: Holds a reference to a function that looks like this signature:
        //public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args); // Subscriber implements this with this signature

        // 2: Creating an event based on delegate:
        public event EventHandler<VideoEventArgs> VideoEncoded; // The same as making an delegate - For Custom eventargs (object source, VideoEventArgs args)
        public event EventHandler VideoEncoding; // For generic eventhandling with source and EventArgs

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        // Convention: protected virtual void On[methodname] Is called in the program
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null) // If there is any subscribers subscribed
                VideoEncoded(this, new VideoEventArgs() {Video = video });
            
        }
    }
}
