using AlQaim.Lms.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = AlQaim.Lms.Domain;

namespace sharedWebComponents.Course
{
    public partial class CourseDisplay
    {
        [Parameter]
        public List<Domain.Course> Courses { get; set; } = new List<Domain.Course>();

        JustifyContent Justification = JustifyContent.FlexStart;
        void OnBreakpointEnterHandler(GridItemSize size)
        {
            Console.WriteLine($"Page Size: {size}");
            //DemoLogger.WriteLine($"Page Size: {size}");
        }
        private void onClickHeadingHandler(EventCallback e)
        {
            // NavigationManager.NavigateTo($"courses/1");
        }
        protected override void OnInitialized()
        {
           
           
        }
    }
}
