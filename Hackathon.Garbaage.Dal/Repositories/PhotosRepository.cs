using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hackathon.Garbage.Dal.DbContexts;

namespace Hackathon.Garbage.Dal.Repositories
{
    public class PhotosRepository : BaseRepository, IPhotosRepository
    {
        public PhotosRepository(FloraDbContext floraDbContext) : base(floraDbContext)
        {
        }
        public string[] GetByOrder(int orderId)
        {
            try
            {
                var photos = _floraDbContext.Photos.Where(x => x.OrderId == orderId).Select(x => x.Path).ToArray();
                return photos;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
