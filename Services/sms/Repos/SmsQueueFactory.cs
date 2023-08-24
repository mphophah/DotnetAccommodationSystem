using AMS.Data;
using AutoMapper;
using Microsoft.Extensions.Configuration;


namespace AMS
{
	public partial class SmsQueueFactory
  {
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    public SmsQueueFactory(ApplicationDbContext context, IConfiguration config, IMapper mapper)
    {
      _config = config;
      _mapper = mapper;
      _context = context;
    }
  }
}
