﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collage_ManageMent_System.Domain.ViewModels.StudentViewModels
{
    public class StudentRegister
    {
        public Student student { get; set; }
        public  List<Course> UnRegisteredCourses { get; set; }
         

    }
}
