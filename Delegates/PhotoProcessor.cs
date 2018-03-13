using System;

namespace Delegates
{
    public class PhotoProcessor
    {
        //public delegate void PhotoFilterHandler(Photo photo); // Responsible for calling the method/methods with this signature. Custom delegate
        
        
        // public void Process(string path, PhotoFilterHandler filterHandler)
        public void Process(string path, Action<Photo> filterHandler)
        {
            // Difference between Action and Func, is that Func points to methods that return a value, 
            // whereas Action points at methods who returns void..

            //System.Action<>
            //System.Func<>
            var photo = Photo.Load(path);

            filterHandler(photo);

            photo.Save();
        }
    }
}
