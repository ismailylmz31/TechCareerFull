﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer.Models.Dtos.Events;



public sealed class CreateEventRequestDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? ParticipationText { get; set; }
    public int CategoryId { get; set; }

};

