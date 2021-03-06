﻿using System;
using CrystalQuartz.Core.Contracts;

namespace CrystalQuartz.Application.Comands
{
    using CrystalQuartz.Application.Comands.Inputs;
    using CrystalQuartz.Core.Timeline;

    public class PauseGroupCommand : AbstractOperationCommand<GroupInput>
    {
        public PauseGroupCommand(Func<SchedulerHost> schedulerHostProvider) : base(schedulerHostProvider)
        {
        }

        protected override void PerformOperation(GroupInput input)
        {
            SchedulerHost.Commander.PauseJobGroup(input.Group);

            RiseEvent(new SchedulerEvent(SchedulerEventScope.Group, SchedulerEventType.Paused, input.Group, null));
        }
    }
}