using System.IO;
using System.Threading.Tasks;

namespace AMS.Web.Services
{
    public interface IPdfService<T> where T : class
    {
        public Task<MemoryStream> GetPdfStreamAsync(T entity);
    }
}