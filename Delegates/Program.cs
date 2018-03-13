/*
 * WHAT:
 * Is a pointer to a function, or to be more precise, an object that knows
 * how to call a method or multiple methods.
 * 
 * WHY:
 * To the effect 
 * of having the possibility to extend the framework without changing the underlying
 * programs.
 * 
 * WHEN:
 * When eventing design pattern is used.
 * or if the caller doesn't need to access other properties or methods in the object 
 * implementing the method 
 */

using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();

            // Adds methods to the delegate, note that they all must have the same signature as defined in the delegate.
            // PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness; // With custom delegate
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += RemoveRedEyeFilter; 

            processor.Process("photo.jpg", filterHandler);
        }

        // A new method to show that the underlying code, isn't changed but that we can just add more to filterhandler.
        static void RemoveRedEyeFilter(Photo photo) // Must match delegate signature
        {
            System.Console.WriteLine("Apply RemoveRedEye");
        }
    }
}
