using AlQaim.Lms.Application.Course.GetAll;
using AlQaim.Lms.Domain;
using AlQaim.Lms.SharedKernel;
using Domain = AlQaim.Lms.Domain;

namespace AlQaim.Lms.Application.Course
{
    public class GetAllQueryHandler(IRepository<Domain.Course> _repository) : 
    IQueryHandler<GetAllCoursesQuery, IEnumerable<Domain.Course>>
    {
        public Task<IEnumerable<Domain.Course>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            return _repository.ListAsync(cancellationToken);
        }
    }
}

