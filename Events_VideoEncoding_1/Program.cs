using System;
using System.Threading;

namespace Events_VideoEncoding_1 {
    class Program {
        static void Main ( string [] args ) {
            var video = new Video () { Title = "Video 1" };

            var videoEncoder = new VideoEncoder ();  // publisher
            var mailService = new MailService ();    // subscriber

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;

            videoEncoder.Encode ( video );

            Console.ReadLine ();
        }
    }   // end program


    public class Video {
        public string Title { get; set; }
    }



    public class MailService {
        public void OnVideoEncoded ( object source, EventArgs e ) {
            Console.WriteLine ( "Mailservice: Sending an email ..." );
        }
    }



    public class VideoEncoder {
        // 1. define a delegate
        // 2. Define an event on the delegate
        // 3. Raise the event	

        public delegate void VideoEncodedEventHandler ( object source, EventArgs args );
        public event VideoEncodedEventHandler VideoEncoded;

        public void Encode ( Video video ) {
            Console.WriteLine ( "Encoding Video" );
            Thread.Sleep ( 1000 );

            OnVideoEncoded ();
        }

        protected virtual void OnVideoEncoded () {
            if ( VideoEncoded != null ) {
                VideoEncoded ( this, EventArgs.Empty );
            }
        }

    } // videoencoder

}
