/*
 * This is an example on how to implement delgates in your program, to the effect 
 * of having the possibility to extend the framework without changing the underlying
 * programs.
 */

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();

            // Adds methods to the delegate, note that they all must have the same signature as defined in the delegate.
            PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += RemoveRedEyeFilter;

            processor.Process("photo.jpg", filterHandler);
        }

        static void RemoveRedEyeFilter(Photo photo) // Must match delegate signature
        {
            System.Console.WriteLine("Apply RemoveRedEye");
        }
    }
}
