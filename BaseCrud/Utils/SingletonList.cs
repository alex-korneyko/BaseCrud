using System.Collections.Generic;

namespace BaseCrud.Utils
{
    public class SingletonList<T> : List<T>
    {
        public SingletonList(T element) : base(1)
        {
            this.Add(element);
        }
    }
}