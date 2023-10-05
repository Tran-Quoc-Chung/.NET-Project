using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace server.DTO.StatusActive
{
    public class GetStatusActiveDTO
    {
       public int StatusID { get; set; }
        public string StatusName { get; set; } = string.Empty;
    }


}
