namespace GenericSequenceGenerator.Interfaces
{
    public interface ISequenceGenerator<T>
    {
        T Previous { get; set; }

        T Current { get; set; }

        T Next { get; set; }
    }
}
