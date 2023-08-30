﻿using Klipboard.Utils;
using Kusto.Cloud.Platform.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klipboard.Workers
{
    public class QuickActionsWorker : WorkerBase
    {
        public QuickActionsWorker(WorkerCategory category, object? icon)
            : base(category, icon, ClipboardContent.None)
        {
        }

        public override string GetMenuText(ClipboardContent content)
        {
            return "{cluster}-{database} Quick Actions";
        }

        public override string GetToolTipText(ClipboardContent content)
        {
            return "Click to set the default cluster and database for Quick Actions";
        }
    }
}
