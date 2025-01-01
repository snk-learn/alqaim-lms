using AlQaim.Lms.Domain;
using AlQaim.Lms.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlQaim.Lms.Application.Course.GetAll
{
    public record GetAllCoursesQuery : IQuery<IEnumerable<Domain.Course>>;
}
