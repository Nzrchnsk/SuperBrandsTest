using System.Threading.Tasks;

namespace Product.Domain.Interfaces
{
    public interface IBrandClient
    {
        Task<Entities.BrandAggregate.Brand> GetBrand(int id);
        Task<Entities.BrandAggregate.Brand>  GetBrand(string name);
    }
}