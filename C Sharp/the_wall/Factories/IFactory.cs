using the_wall.Models;
using System.Collections.Generic;
namespace the_wall.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}