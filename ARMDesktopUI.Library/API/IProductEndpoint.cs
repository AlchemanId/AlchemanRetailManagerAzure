using ARMDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARMDesktopUI.Library.API
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}