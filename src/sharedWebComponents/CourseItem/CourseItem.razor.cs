using Domain = AlQaim.Lms.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using AlQaim.Lms.Domain;
using Microsoft.FluentUI.AspNetCore.Components;

namespace sharedWebComponents.CourseItem
{
    public partial class CourseItem
    {
        [Parameter]
        public Domain.Course Course { get; set; } = null!;



        string activeId = "accordion-1";
        FluentAccordionItem? changed;

        private void HandleOnAccordionItemChange(FluentAccordionItem item)
        {
            changed = item;
        }
        protected override void OnInitialized()
        {
            Course.Poster = "\"https://rafflegames.blob.core.windows.net/publicvideos/BeAWinner.jpg\"";
            Course.VideoUrl = "\"https://rafflegames.blob.core.windows.net/publicvideos/BeAWinner.mp4\"";
        }
    }
}
