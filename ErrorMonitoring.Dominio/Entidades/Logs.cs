﻿using System;
using System.Collections.Generic;

namespace ErrorMonitoring.Dominio.Entidades
{
    public class Logs
    {
        public int Id { get; set; }
        public int Project { get; set; }
        public int EventType { get; set; }
        public bool? Archived { get; set; }

        public virtual Events EventTypeNavigation { get; set; }
        public virtual Projects ProjectNavigation { get; set; }
    }
}
