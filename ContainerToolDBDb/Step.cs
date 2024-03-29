﻿using System;
using System.Collections.Generic;

namespace ContainerToolDBDb;

public partial class Step
{
    public int Id { get; set; }

    public int StepNumber { get; set; }

    public string StepDescription { get; set; } = null!;

    public string StepName { get; set; } = null!;

    public bool IsCompleted { get; set; }

    public DateTime LastUpdated { get; set; }

    public virtual ICollection<StepChecklist> StepChecklists { get; } = new List<StepChecklist>();
}
