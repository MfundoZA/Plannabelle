﻿using PlannabelleClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannabelleClassLibrary.ViewModels
{
    public class DashboardViewModel : ViewModel
    {
        public DoublyLinkedList<Semester>? Semesters { get; set; } = new DoublyLinkedList<Semester>();
    }
}
