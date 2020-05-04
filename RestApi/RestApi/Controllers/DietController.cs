namespace RestApi.Controllers
{   
    [ApiController]
    public class DietController : ControllerBase
    {
        private readonly IMapper _mapper;

        public DietController(IRepositoryManager repository, IMapper mapper, IPhotoService photoService)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}