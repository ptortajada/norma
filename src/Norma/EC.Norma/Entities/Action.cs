﻿using System.Collections.Generic;

namespace EC.Norma.Entities
{
    public class Action
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ActionsPolicy> ActionPolicies { get; set; }
    }
}
